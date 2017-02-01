# Game Escape From Dynamic Labyrinth  <img src="https://cloud.githubusercontent.com/assets/24522089/21962098/41a510c8-db36-11e6-95ef-eb392a0a1919.png" align="right" width="130px" height="130px" /> 

> Level 1

![small](https://cloud.githubusercontent.com/assets/24522089/22444148/38f63502-e75b-11e6-89eb-fb46962836d3.gif)


> Level 2

![looser](https://cloud.githubusercontent.com/assets/24522089/22404958/977d82ae-e654-11e6-9fdf-7adbfcf2be93.gif)


> Level 3

![big](https://cloud.githubusercontent.com/assets/24522089/22444224/76859ba6-e75b-11e6-83b4-f52756d64ebe.gif)


### About Threads

The advantage of threading is the ability to create applications that use more than one thread of execution. For example, a process can have a user interface thread that manages interactions with the user and worker threads that perform other tasks while the user interface thread waits for user input.
This game - example demonstrates how to create and start a thread, and shows the interaction between two threads running simultaneously within the same process. Note that you don't have to stop or free the thread. This is done automatically by the .NET Framework common language runtime.


[Reed more about threads] (https://msdn.microsoft.com/en-us/library/aa645740(v=vs.71).aspx)

```c#
static void Main(string[] args)
{
    Console.CursorVisible = false;
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    do
    {
        Console.Clear();
        Console.WriteLine("Select Level 1, 2, or 3");
        string level = Console.ReadLine();
        Game lab;
        switch (level)
        {
            case "1":
                lab = new Game(LabirinthSize.Small);
                break;
            case "2":
                lab = new Game(LabirinthSize.Medium);
                break;
            case "3":
                lab = new Game(LabirinthSize.Large);
                break;
            default:
                lab = new Game(LabirinthSize.Medium);
                break;
        }
        Console.Clear();
        lab.DrawLife();

        ThreadStart Player = new ThreadStart(lab.DrawPlayer);
        Thread thread = new Thread(Player);
        thread.Start();
        lab.DrawLabirinth();

        do
        {
            Console.SetCursorPosition(22, 5);
            Console.WriteLine("Press Enter for Menu");
        }
        while (Console.ReadKey().Key != ConsoleKey.Enter);

        Console.Clear();
        Console.WriteLine("Press ENTER for NEW GAME, or  ESC to extit game"); 
    } while (Console.ReadKey().Key == ConsoleKey.Enter);


}
```

Special Thanks to [Hayk Harutyunyan] (https://github.com/harutyunyanhayk) and [Hovo Nalbandyan] (https://github.com/HovoNalbandyan) for the valuable advice.


> This game is written on C# 6.0, .NET Framework 4.6 Visual Studio 2015 Comunity Edition
