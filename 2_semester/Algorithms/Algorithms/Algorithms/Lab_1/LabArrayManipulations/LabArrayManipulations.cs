
public class LabArrayManipulations : ILab
{
    void ILab.Start()
    {
        var array1 = ConstructAndShowList();
        var array2 = ConstructAndShowList();

        Console.WriteLine();
        
        Console.Write("Union: "); array1.Union(array2).ShowAll();
        Console.Write("Intersect: "); array1.Intersect(array2).ShowAll();
        Console.Write("Except: "); array1.Except(array2).ShowAll();
        Console.Write("Complementary : "); array1.Union(array2).Except(array1).ShowAll();
        Console.Write("Symmetric difference : "); array1.Except(array2).Union(array2.Except(array1)).ShowAll();
    }

    private List<int> ConstructAndShowList()
    {
        var list = new List<int>(10);
        list.FillWithRandom(10, 100);
        list.ShowAll();

        return list;
    }
}