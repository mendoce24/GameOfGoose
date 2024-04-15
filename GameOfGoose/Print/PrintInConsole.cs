using GameOfGoose.Business.Print;

namespace GameOfGoose.Print;

public class PrintInConsole : ILogger
{
    public void Log(string text)
    {
        Console.WriteLine(text);
    }

}