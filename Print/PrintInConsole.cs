namespace GameOfGoose.Print
{
    public class PrintInConsole : IPrint
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}