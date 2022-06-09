#include "cpualgorithm.h"

const PixelMatrix& CPUAlgorithm::evaluate()
{
    for(int i = 0; i < data_.height(); ++i)
    {
        for(int j = 0; j < data_.width(); ++j)
        {
            frame_[i][j] = evaluatePixel(j, i);
        }
    }

    return frame_;
}
