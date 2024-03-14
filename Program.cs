namespace Stopwatch;

class Program
{
    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("s = segundos => 10s = 10 segundos");
        Console.WriteLine("m = minutos => 1m = 1 minunto");
        Console.WriteLine("0 = sair");
        Console.Write("Quanto tempo deseja contar: ");

        string data = Console.ReadLine().ToLower();
        if (data == "0")
            Environment.Exit(0);
        char type = char.Parse(data.Substring(data.Length - 1, 1));
        // data[..^1]; // equivalente a data.Substring(0, data.Length -1);
        int time = int.Parse(data[..^1]);
        int multiplier = 1;

        if (type == 'm')
            multiplier = 60;
        if (time == 0)
            Environment.Exit(0);
        PreStart(time * multiplier);
    }

    static void PreStart(int time)
    {
        Console.Clear();
        Console.WriteLine("Ready...");
        Thread.Sleep(1000);
        Console.WriteLine("Set...");
        Thread.Sleep(1000);
        Console.WriteLine("Go...");
        Thread.Sleep(1500);
        Start(time);
    }

    static void Start(int time)
    {
        int currentTime = 0;
        int seconds = 0;
        int minutes = 0;

        while (currentTime != time)
        {
            Console.Clear();
            currentTime++;
            seconds++;
            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }
            Console.WriteLine($"{minutes}:{seconds}");
            // wait 1 second to repeat
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Finished");
        Thread.Sleep(2500);
        MainMenu();
    }
}