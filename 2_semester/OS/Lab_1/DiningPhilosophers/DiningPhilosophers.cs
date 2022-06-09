namespace DiningPhilosophers
{
    internal static class Configuration
    {
        public static int PhilosophersCount => 5;
        public static int FoodCount => 5;
        public static int MaxAttempts => 100;
    }

    internal class Philosopher
    {
        public Philosopher(int index, Chopstick leftChopstick, Chopstick rightChopstick)
        {
            Index = index;
            Food = Configuration.FoodCount;
            LeftChopstick = leftChopstick;
            RightChopstick = rightChopstick;
            Log = new List<string> { $"{DateTime.Now}: Philosopher {index} sat down" };
        }

        public int Index { get; }
        public int Food { get; set; }
        public Chopstick LeftChopstick { get; set; }
        public Chopstick RightChopstick { get; set; }
        public List<string> Log { get; set; }

        public void EatUntilDone()
        {
            int attempts = 1;
            while (Food > 0 && attempts < Configuration.MaxAttempts)
            {
                Thread.Sleep(100);
                Log.Add(@$"{DateTime.Now}: Philosopher {Index} is trying to eat with {attempts} attempts");
                if (PickUpChopstics())
                {
                    Log.Add(@$"{DateTime.Now}: Philosopher {Index} put up chopsticks.");
                    this.Eat();
                    Log.Add(@$"{DateTime.Now}: Philosopher {Index} finish eating.");
                    this.PutDownLeftChopstick();
                    this.PutDownRightChopstick();
                    Log.Add(@$"{DateTime.Now}: Philosopher {Index} put down chopsticks.");
                    Console.WriteLine(@$"{DateTime.Now}: Philosopher {Index} put down chopsticks.");
                }
                else
                {
                    Console.WriteLine($"Philosopher {Index} could not put up chopsticks.");
                    Log.Add(@$"{DateTime.Now}: Philosopher {Index} could not put up chopsticks.");
                }
                attempts++;
            }

            if (Food == 0)
            {
                Console.WriteLine($"{DateTime.Now}: Philosopher {Index} finish eating for {attempts} attempts.");
                Log.Add($"{DateTime.Now}: Philosopher {Index} finish eating for {attempts} attempts.");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now}: Philosopher {Index} died.");
                Log.Add($"{DateTime.Now}: Philosopher {Index} died.");
            }
        }

        private bool PickUpChopstics()
        {
            if (Monitor.TryEnter(LeftChopstick))
            {
                if (Monitor.TryEnter(RightChopstick))
                {
                    Console.WriteLine($"Philosopher {Index} put up chopsticks.");
                    return true;
                }
                else
                {
                    PutDownLeftChopstick();
                }
            }
            
            return false;
        }

        private void PutDownLeftChopstick()
        {
            Monitor.Exit(this.LeftChopstick);
        }

        private void PutDownRightChopstick()
        {
            Monitor.Exit(this.RightChopstick);
        }
        
        private void Eat()
        {
            Console.WriteLine($"Philosopher {Index} start eating.");
            Thread.Sleep(100);
            Food--;
        }
    }


    internal class Chopstick
    {
        public Chopstick(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }

    internal class Table
    {
        public Table()
        {
            Philosophers = new Dictionary<int, Philosopher>();
            Chopsticks = new Dictionary<int, Chopstick>();

            for (int i = 1; i <= Configuration.PhilosophersCount; i++)
            {
                Chopsticks.Add(i, new Chopstick(i));
            }

            for (int i = 1; i <= Configuration.PhilosophersCount; i++)
            {
                var leftChopstick = Chopsticks[i];
                var rightChopstick = Chopsticks[i + 1 <= Configuration.PhilosophersCount ? i + 1 : 1];
                Philosophers.Add(i, new Philosopher(i, leftChopstick, rightChopstick));
            }
        }

        public Dictionary<int, Philosopher> Philosophers { get; private set; }
        public Dictionary<int, Chopstick> Chopsticks { get; private set; }

        public void Log()
        {
            Console.WriteLine($"======================================================");
            foreach ((var key, var value) in Philosophers)
            {
                Console.WriteLine($"Philosopher {key} | food {value.Food}");
            }
            Console.WriteLine($"======================================================");

        }

        public void LogPhilosophers()
        {
            foreach ((var key, var value) in Philosophers)
            {
                Console.WriteLine($"======================================================");
                Console.WriteLine($"Philosopher supper history  {key}");
                foreach (var record in value.Log)
                {
                    Console.WriteLine(record);
                }
                Console.WriteLine($"======================================================");
            }
            foreach ((var key, var value) in Philosophers)
            {
                Console.WriteLine(value.Log.Last());
            }
        }
    }
}
