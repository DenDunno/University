
ILab[] labs = 
{
    new ArraysLab(new ArraySortingFromCentreByAscending()),
    new ArraysLab(new ArraySortingFromCentreByDescending()),
    new ArraysLab(new WaveArraySorting()),
    new ArraysLab(new EvenIndexArraySorting()),
    
    new MatrixLab(new AMatrixSortingOrder()),
    new MatrixLab(new BMatrixSortingOrder()),
    new MatrixLab(new CMatrixSortingOrder()),
    new MatrixLab(new DMatrixSortingOrder()),
    new MatrixLab(new EMatrixSortingOrder()),
};


labs.ForEach(lab => lab.Start());