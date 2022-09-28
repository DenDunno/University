#ifndef MANDELBROTSETFRAMEPIECE_H
#define MANDELBROTSETFRAMEPIECE_H
#include "bitmap.h"

class MandelbrotSetFramePiece
{
public:

    MandelbrotSetFramePiece(const PixelMatrix& piece, const int start, const int end) : piece_(piece), start_(start), end_(end) {}
    const PixelMatrix& data() { return piece_; }
    int start() { return start_; }
    int end() { return end_; }

private:
    const PixelMatrix piece_;
    const int start_;
    const int end_;
};

#endif
