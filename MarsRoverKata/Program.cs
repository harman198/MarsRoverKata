using System.Collections;

namespace MarsRoverKata;

public class Program
{
    public static int IPtX = 0;
    public static int IPtY = 0;
    public static String SDirection = "";
    private static String _validDirections = "NSEW";
    private static String _northDirection = "N";
    private static String _southDirection = "S";
    private static String _eastDirection = "E";
    private static String _westDirection = "W";
    private static String _validCommands = "LRM";
    private static String _leftCommand = "L";
    private static String _rightCommand = "R";
    private static String _moveCommand = "M";

    private static Boolean _isDebugChecked = false;

    private static void DebugOut(String msg)
    {
        if (_isDebugChecked)
        {
            Console.WriteLine(msg);
        }
    }

    private static String publish_values()
    {
        String s = IPtX + " " + IPtY + " " + SDirection;
        Console.WriteLine(s);
        return s;
    }

    private static void DoMove()
    {
        switch (SDirection)
        {
            case "N":
                DebugOut("doMove().1 --> (s_direction == northDirection)");
                IPtY = IPtY + 1;
                break;
            case "E":
                DebugOut("doMove().2 --> (s_direction == eastDirection)");
                IPtX = IPtX + 1;
                break;
            case "S":
                DebugOut("doMove().3 --> (s_direction == southDirection)");
                IPtY = IPtY - 1;
                break;
            case "W":
                DebugOut("doMove().4 --> (s_direction == westDirection)");
                IPtX = IPtX - 1;
                break;
        }
    }

    private static void DoSpin(String d)
    {
        SDirection = ((_validDirections.IndexOf(d) > -1) || (_validCommands.IndexOf(d) > -1)) ? d : SDirection;
        DebugOut("doSpin().1 --> d=" + d + ", s_direction=" + SDirection);
    }

    private static void DoCommand(String c)
    {
        DebugOut("doCommand().1 --> c=" + c);
        switch (c)
        {
            case "L":
                DebugOut("doCommand().2 --> (c == leftCommand)");
                switch (SDirection)
                {
                    case "N":
                        DebugOut("doCommand().3 --> doSpin(westDirection)");
                        DoSpin(_westDirection);
                        break;
                    case "W":
                        DebugOut("doCommand().4 --> doSpin(southDirection)");
                        DoSpin(_southDirection);
                        break;
                    case "S":
                        DebugOut("doCommand().5 --> doSpin(eastDirection)");
                        DoSpin(_eastDirection);
                        break;
                    case "E":
                        DebugOut("doCommand().6 --> doSpin(northDirection)");
                        DoSpin(_northDirection);
                        break;
                }
                break;
            case "R":
                DebugOut("doCommand().7 --> (c == rightCommand)");
                switch (SDirection)
                {
                    case "N":
                        DebugOut("doCommand().8 --> doSpin(eastDirection)");
                        DoSpin(_eastDirection);
                        break;
                    case "E":
                        DebugOut("doCommand().9 --> doSpin(southDirection)");
                        DoSpin(_southDirection);
                        break;
                    case "S":
                        DebugOut("doCommand().10 --> doSpin(westDirection)");
                        DoSpin(_westDirection);
                        break;
                    case "W":
                        DebugOut("doCommand().11 --> doSpin(northDirection)");
                        DoSpin(_northDirection);
                        break;
                }
                break;
            case "M":
                DebugOut("doCommand().12 --> (c == moveCommand)");
                DoMove();
                break;
        }
    }

    private static bool IsInteger(string theValue)
    {
        try
        {
            Convert.ToInt32(theValue);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static String ParseCommand(String c)
    {
        String aTok;
        String aCmd;
        Boolean b;
        Stack items = new Stack();
        String[] toks = c.Split(' ');
        for (int i = 0; i < toks.Length; i++)
        {
            aTok = toks[i];
            DebugOut("parseCommand().1 aTok=" + aTok);
            if (aTok.Length > 1)
            {
                for (var j = 0; j < aTok.Length; j++)
                {
                    aCmd = aTok.Substring(j, 1);
                    DebugOut("parseCommand().2 aCmd=" + aCmd);
                    DoCommand(aCmd);
                }
            }
            else
            {
                b = IsInteger(aTok);
                DebugOut("parseCommand().3 --> b=" + b);
                if (b)
                {
                    items.Push(aTok);
                    DebugOut("parseCommand().4 items.Count=" + items.Count);
                    if (items.Count == 2)
                    {
                        IPtY = Convert.ToInt32(items.Pop());
                        IPtX = Convert.ToInt32(items.Pop());
                    }
                }
                else if (_validDirections.IndexOf(aTok) > -1)
                {
                    SDirection = aTok;
                    DebugOut("parseCommand().5 s_direction=" + SDirection);
                }
                else if (_validCommands.IndexOf(aTok) > -1)
                {
                    DebugOut("parseCommand().6 doCommand(" + aTok + ")");
                    DoCommand(aTok);
                }
            }
        }
        return publish_values();
    }

    public static void Main(string[] args)
    {
        String cmd = "1 2 N";
        String expected = "1 2 N";
        String x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #1");
        }

        cmd = "L";
        expected = "1 2 W";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #2");
        }

        cmd = "M";
        expected = "0 2 W";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #3");
        }

        cmd = "L";
        expected = "0 2 S";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #4");
        }

        cmd = "M";
        expected = "0 1 S";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #5");
        }

        cmd = "L";
        expected = "0 1 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #6");
        }

        cmd = "M";
        expected = "1 1 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #7");
        }

        cmd = "L";
        expected = "1 1 N";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #8");
        }

        cmd = "M";
        expected = "1 2 N";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #9");
        }

        cmd = "M";
        expected = "1 3 N";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #10");
        }

        cmd = "3 3 E";
        expected = "3 3 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #11");
        }

        cmd = "M";
        expected = "4 3 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #12");
        }

        cmd = "M";
        expected = "5 3 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #13");
        }

        cmd = "R";
        expected = "5 3 S";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #14");
        }

        cmd = "M";
        expected = "5 2 S";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #15");
        }

        cmd = "M";
        expected = "5 1 S";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #16");
        }

        cmd = "R";
        expected = "5 1 W";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #17");
        }

        cmd = "M";
        expected = "4 1 W";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #18");
        }

        cmd = "R";
        expected = "4 1 N";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #19");
        }

        cmd = "R";
        expected = "4 1 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #20");
        }

        cmd = "M";
        expected = "5 1 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #21");
        }

        cmd = "1 2 N";
        expected = "1 2 N";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #22");
        }

        cmd = "LMLMLMLMM";
        expected = "1 3 N";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #23");
        }

        cmd = "3 3 E";
        expected = "3 3 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #24");
        }

        cmd = "MMRMMRMRRM";
        expected = "5 1 E";
        x = ParseCommand(cmd);
        if (x != expected)
        {
            Console.WriteLine("ERROR #25");
        }
    }
}