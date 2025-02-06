namespace MarsRoverKata;

public class Printer(bool isDebugChecked)
{
    private bool IsDebugChecked { get; } = isDebugChecked;

    public void DebugOut(string msg)
    {
        if (IsDebugChecked)
        {
            Console.WriteLine(msg);
        }
    }

    public void Out(string msg)
    {
        Console.WriteLine(msg);
    }
}
