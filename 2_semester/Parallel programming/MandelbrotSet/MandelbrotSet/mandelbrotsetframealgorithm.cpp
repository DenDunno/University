#include "mandelbrotsetframealgorithm.h"
#include <complex>

MandelbrotSetFrameAlgorithm::MandelbrotSetFrameAlgorithm(const MandelbrotSetFrameData& data)
    : frame_(PixelMatrix(data.height(), std::vector<Pixel>(data.width(), Pixel()))), data_(data), height_(width_ * data.height() / data.width())
{
}


Pixel MandelbrotSetFrameAlgorithm::evaluatePixel(int x, int y)
{
    Pixel pixel(0, 0, 0);

    double width = width_ / data_.zoom();
    double height = height_ / data_.zoom();

    double xStart = xStart_ + (width_ - width) / 2;
    double yStart = yStart_ + (height_ - height) / 2;

    double newX = xStart + (double)x / data_.width() * width + data_.location().X();
    double newY = yStart + (double)y / data_.height() * height + data_.location().Y();

    int iterationsForPoint = evaluateIterationsForPoint(newX, newY);

    if (iterationsForPoint != data_.iterations())
        pixel = colors_.at(iterationsForPoint % 16);

    return pixel;
}


int MandelbrotSetFrameAlgorithm::evaluateIterationsForPoint(double x, double y)
{
    int iterations = 0;
    std::complex<double> z = 0;

    for (int i = 0; i < data_.iterations(); i++)
    {
        z = z * z +  std::complex<double>(x, y);

        if (std::abs(z) > 2)
            break;

        ++iterations;
    }

    return iterations;
}
