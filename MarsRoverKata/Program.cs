namespace MarsRoverKata;

public class Program
{
    public static void Main(string[] args)
    {
        string cmd = "1 2 N";
        string expected = "1 2 N";
        string x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #1");
        }

        cmd = "L";
        expected = "1 2 W";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #2");
        }

        cmd = "M";
        expected = "0 2 W";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #3");
        }

        cmd = "L";
        expected = "0 2 S";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #4");
        }

        cmd = "M";
        expected = "0 1 S";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #5");
        }

        cmd = "L";
        expected = "0 1 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #6");
        }

        cmd = "M";
        expected = "1 1 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #7");
        }

        cmd = "L";
        expected = "1 1 N";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #8");
        }

        cmd = "M";
        expected = "1 2 N";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #9");
        }

        cmd = "M";
        expected = "1 3 N";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #10");
        }

        cmd = "3 3 E";
        expected = "3 3 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #11");
        }

        cmd = "M";
        expected = "4 3 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #12");
        }

        cmd = "M";
        expected = "5 3 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #13");
        }

        cmd = "R";
        expected = "5 3 S";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #14");
        }

        cmd = "M";
        expected = "5 2 S";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #15");
        }

        cmd = "M";
        expected = "5 1 S";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #16");
        }

        cmd = "R";
        expected = "5 1 W";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #17");
        }

        cmd = "M";
        expected = "4 1 W";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #18");
        }

        cmd = "R";
        expected = "4 1 N";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #19");
        }

        cmd = "R";
        expected = "4 1 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #20");
        }

        cmd = "M";
        expected = "5 1 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #21");
        }

        cmd = "1 2 N";
        expected = "1 2 N";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #22");
        }

        cmd = "LMLMLMLMM";
        expected = "1 3 N";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #23");
        }

        cmd = "3 3 E";
        expected = "3 3 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #24");
        }

        cmd = "MMRMMRMRRM";
        expected = "5 1 E";
        x = RoverMover.ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #25");
        }
    }
}