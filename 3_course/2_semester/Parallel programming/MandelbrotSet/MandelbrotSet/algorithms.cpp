#include "algorithms.h"
#include "mpi.h"
#include <iostream>

int* allocate(int size);
void clear(int* array);
void evaluate(MandelbrotSetFrameAlgorithm& algorithm);

Algorithms::Algorithms(const MandelbrotSetFrameData& data) : cpuAlgorithm_(CPUAlgorithm(data)), openMpAlgorithm_(data), data_(data)
{
}

void Algorithms::startCPU()
{
    evaluate(cpuAlgorithm_);
}

void Algorithms::startOpenMP()
{
    evaluate(openMpAlgorithm_);
}

void Algorithms::startMPI()
{
    PixelMatrix pixels = PixelMatrix(data_.height(), std::vector<Pixel>(data_.width(), Pixel()));
    CPUAlgorithm algprithm = CPUAlgorithm(data_);

    int partition;
    int processes;
    int rank;
    int* pixelMatrix = allocate(3 * data_.height() * data_.width());

    MPI_Init(NULL, NULL);
    auto begin = MPI_Wtime();

    MPI_Comm_size(MPI_COMM_WORLD, &processes);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    partition = data_.width() / processes;
    int bufferSize = 3 * data_.height() * partition;
    int* pixelBuffer = allocate(bufferSize);

    MPI_Scatter(pixelMatrix, partition, MPI_INT, pixelBuffer, partition, MPI_INT, 0, MPI_COMM_WORLD);

    for (int y = 0 ; y < data_.height() ; ++y)
    {
        for (int x = 0; x < partition; ++x)
        {
            Pixel pixel = algprithm.evaluatePixel(x + partition * rank, y);

            pixelBuffer[0 * data_.height() * partition + partition * y + x] = pixel.red;
            pixelBuffer[1 * data_.height() * partition + partition * y + x] = pixel.green;
            pixelBuffer[2 * data_.height() * partition + partition * y + x] = pixel.blue;
        }
    }

     if(rank == 0)
     {
         MPI_Gather(pixelBuffer, bufferSize, MPI_INT, pixelMatrix, bufferSize, MPI_INT, 0, MPI_COMM_WORLD);

         for (int y = 0 ; y < data_.height() ; ++y)
         {
             for (int x = 0 ; x < data_.width(); ++x)
             {
                 int r = pixelMatrix[0 * data_.height() * partition + partition * y + x];
                 int g = pixelMatrix[1 * data_.height() * partition + partition * y + x];
                 int b = pixelMatrix[2 * data_.height() * partition + partition * y + x];

                 pixels[y][x] = Pixel(r, g, b);
             }
         }

         std::cout << MPI_Wtime() - begin << std::endl;

         Bitmap bitmap = Bitmap(pixels);
         bitmap.save("D:/Business/MandelbrotSet/mandelbrotSetFrame.bmp");
         system("D:/Business/MandelbrotSet/mandelbrotSetFrame.bmp");
     }
     else
     {
         MPI_Gather(pixelBuffer, bufferSize, MPI_INT, NULL, 0, MPI_INT, 0, MPI_COMM_WORLD);
     }


    clear(pixelBuffer);
    clear(pixelMatrix);

    MPI_Finalize();
}

void evaluate(MandelbrotSetFrameAlgorithm& algorithm)
{
    const clock_t begin_time = clock();
    PixelMatrix pixelMatrix = algorithm.evaluate();
    const float elapsed_time = float(clock() - begin_time) /  CLOCKS_PER_SEC;

    Bitmap bitmap = Bitmap(pixelMatrix);
    bitmap.save("D:/Business/MandelbrotSet/mandelbrotSetFrame.bmp");
    printf("Elapsed time = %f \n", elapsed_time);

    system ("D:/Business/MandelbrotSet/mandelbrotSetFrame.bmp");
}

int* allocate(int size)
{
    return new int[size];
}

void clear(int* array)
{
    delete[] array;
}
