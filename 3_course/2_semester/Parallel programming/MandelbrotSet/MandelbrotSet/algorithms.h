#ifndef ALGORITHMS_H
#define ALGORITHMS_H
#include "cpualgorithm.h"
#include "mandelbrotsetframedata.h"
#include "openmpalgorithm.h"


class Algorithms
{
public:
    Algorithms(const MandelbrotSetFrameData& data);
    void startCPU();
    void startOpenMP();
    void startMPI();

private:
    CPUAlgorithm cpuAlgorithm_;
    OpenMPAlgorithm openMpAlgorithm_;
    const MandelbrotSetFrameData& data_;
};

#endif
