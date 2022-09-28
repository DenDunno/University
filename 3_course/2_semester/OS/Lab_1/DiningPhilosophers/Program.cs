using DiningPhilosophers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var table = new Table();

table.Log();

List<Task> tasks = new List<Task>();

foreach ((var key, var value) in table.Philosophers)
{
    Task task = Task.Run(() => value.EatUntilDone());
    tasks.Add(task);
}

Task.WaitAll(tasks.ToArray());

table.LogPhilosophers();