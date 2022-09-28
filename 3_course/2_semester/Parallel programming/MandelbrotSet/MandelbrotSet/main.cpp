#include "algorithms.h"


int main()
{
    MandelbrotSetFrameData data = MandelbrotSetFrameData(Point(1920, 1080), Point(0.045, 0.2), 200, 200);
    Algorithms algorithms = Algorithms(data);

    algorithms.startMPI();

    return 0;
}
