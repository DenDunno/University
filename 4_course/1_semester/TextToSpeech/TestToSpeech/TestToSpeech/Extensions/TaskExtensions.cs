
public static class TaskExtensions
{
    public static async Task WaitWhile(Func<bool> predicate)
    {
        await Task.Run(async () =>
        {
            const int frequency = 25;

            while (predicate())
            {
                await Task.Delay(frequency);
            }
        });
    }
}