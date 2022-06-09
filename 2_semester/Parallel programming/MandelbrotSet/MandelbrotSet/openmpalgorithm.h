#ifndef OPENMPALGORITHM_H
#define OPENMPALGORITHM_H
#include "mandelbrotsetframealgorithm.h"


class OpenMPAlgorithm : public MandelbrotSetFrameAlgorithm
{
public:

    OpenMPAlgorithm(const MandelbrotSetFrameData& data) : MandelbrotSetFrameAlgorithm(data) {}
    const PixelMatrix& evaluate() override;
};

#endif
