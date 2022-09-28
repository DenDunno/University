#include "mandelbrotsetframe.h"
#include <qimage.h>
#include <complex>
#include <omp.h>

int evaluateIterationsForPoint(double x, double y, int maxIterations);

MandelbrotSetFrame::MandelbrotSetFrame(const MandelbrotSetFrameData &data)
    : data_(data), frame_(QImage(data.width(), data.height(), QImage::Format_ARGB32)), height_(width_ * data.height() / data.width())
{   
}


MandelbrotSetFrameResult MandelbrotSetFrame::evaluate(EvaluationMethod evaluationMethod)
{
    const clock_t start = clock();    

    const double elapsed_time = double( clock () - start ) /  CLOCKS_PER_SEC;

    return MandelbrotSetFrameResult(frame_, elapsed_time);
}


void MandelbrotSetFrame::run_CPU()
{
    for (int i = 0; i < frame_.height(); ++i)
        for (int j = 0; j < frame_.width(); ++j)
            frame_.setPixelColor(j, i, evaluateColorForPoint(j, i));
}


void MandelbrotSetFrame::run_OPENMP()
{
    #pragma omp parallel for
    for (int i = 0; i < frame_.height(); ++i)
        for (int j = 0; j < frame_.width(); ++j)
            frame_.setPixelColor(j, i, evaluateColorForPoint(j, i));
}



