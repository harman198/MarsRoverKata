namespace MarsRoverKata;

public class Program
{
    public static void Main(string[] args)
    {
        RunRover();
    }

    public static void RunRover(bool debug = false)
    {
        (string Command, string Expected)[] inputs = [("1 2 N", "1 2 N"),
                                                        ("L", "1 2 W"),
                                                        ("M", "0 2 W"),
                                                        ("L", "0 2 S"),
                                                        ("M", "0 1 S"),
                                                        ("L", "0 1 E"),
                                                        ("M", "1 1 E"),
                                                        ("L", "1 1 N"),
                                                        ("M", "1 2 N"),
                                                        ("M", "1 3 N"),
                                                        ("3 3 E", "3 3 E"),
                                                        ("M", "4 3 E"),
                                                        ("M", "5 3 E"),
                                                        ("R", "5 3 S"),
                                                        ("M", "5 2 S"),
                                                        ("M", "5 1 S"),
                                                        ("R", "5 1 W"),
                                                        ("M", "4 1 W"),
                                                        ("R", "4 1 N"),
                                                        ("R", "4 1 E"),
                                                        ("M", "5 1 E"),
                                                        ("1 2 N", "1 2 N"),
                                                        ("LMLMLMLMM", "1 3 N"),
                                                        ("3 3 E", "3 3 E"),
                                                        ("MMRMMRMRRM", "5 1 E")];

        RoverMover.IsDebugChecked = debug;

        foreach (var (cmd, expected) in inputs)
        {
            string x = RoverMover.ParseCommand(cmd);
            if (x != expected)
            {
                Console.WriteLine("ERROR #1");
            }
        }
    }
}