#ifndef MANDELBROTSETFRAMEALGORITHM_H
#define MANDELBROTSETFRAMEALGORITHM_H
#include "bitmap.h"
#include "mandelbrotsetframedata.h"
#include <map>


class MandelbrotSetFrameAlgorithm
{
public:
    MandelbrotSetFrameAlgorithm(const MandelbrotSetFrameData& data);
    Pixel evaluatePixel(const int x, const int y);
    virtual const PixelMatrix& evaluate() = 0;

protected:
    PixelMatrix frame_;
    const MandelbrotSetFrameData& data_;

private:
    int evaluateIterationsForPoint(const double x, const double y);

    const double xStart_ = -3.25;
    const double yStart_ = -1.35;
    const double width_ = 5;
    const double height_;
    const std::map<int, Pixel> colors_ =
    {
        {0, Pixel(66, 30, 15)},
        {1, Pixel(25, 7, 26)},
        {2, Pixel(9, 1, 47)},
        {3, Pixel(4, 4, 73)},
        {4, Pixel(0, 7, 100)},
        {5, Pixel(12, 44, 138)},
        {6, Pixel(24, 82, 177)},
        {7, Pixel(57, 125, 209)},
        {8, Pixel(134, 181, 229)},
        {9, Pixel(211, 236, 248)},
        {10, Pixel(241, 233, 191)},
        {11, Pixel(248, 201, 95)},
        {12, Pixel(255, 170, 0)},
        {13, Pixel(204, 128, 0)},
        {14, Pixel(153, 87, 0)},
        {15, Pixel(106, 52, 3)},
    };
};

#endif
