#ifndef MANDELBROTSETFRAMEDATA_H
#define MANDELBROTSETFRAMEDATA_H
#include "Point.h"

class MandelbrotSetFrameData
{
public:
    MandelbrotSetFrameData(Point size, Point location, int zoom, int iterations) :
        size_(size), location_(location), zoom_(zoom), iterations_(iterations) {}

    int width() const { return size_.X(); }
    int height() const { return size_.Y(); }
    Point location() const { return location_; }
    int zoom() const { return zoom_; }
    int iterations() const { return iterations_; }

private:

    const Point size_;
    const Point location_;
    const int zoom_;
    const int iterations_;
};

#endif
