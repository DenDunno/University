
public static class TaskExtensions
{
    public static async Task WaitWhile(Func<bool> predicate)
    {
        await Task.Run(async () =>
        {
            const int frequency = 1;

            while (predicate())
            {
                await Task.Delay(frequency);
            }
        });
    }
}