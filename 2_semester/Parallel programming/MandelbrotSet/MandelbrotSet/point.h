#ifndef POINT_H
#define POINT_H

class Point
{
public:

    Point(float x, float y) : x_(x), y_(y) {}
    float X() const { return x_; }
    float Y() const { return y_; }

private:
    const float x_;
    const float y_;
};

#endif
