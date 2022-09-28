#ifndef CPUALGORITHM_H
#define CPUALGORITHM_H
#include "mandelbrotsetframealgorithm.h"


class CPUAlgorithm : public MandelbrotSetFrameAlgorithm
{
public:

    CPUAlgorithm(const MandelbrotSetFrameData& data) : MandelbrotSetFrameAlgorithm(data) {}
    const PixelMatrix& evaluate() override;
};

#endif
