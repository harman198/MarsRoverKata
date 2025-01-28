using System.Collections;

internal static class RoverMover
{
    public static int IPtX = 0;
    public static int IPtY = 0;
    public static string SDirection = "";
    private readonly static string _validDirections = "NSEW";
    private readonly static string _northDirection = "N";
    private readonly static string _southDirection = "S";
    private readonly static string _eastDirection = "E";
    private readonly static string _westDirection = "W";
    private readonly static string _validCommands = "LRM";
    private readonly static string _leftCommand = "L";
    private readonly static string _rightCommand = "R";
    private readonly static string _moveCommand = "M";

    private static bool _isDebugChecked = false;

    public static bool IsDebugChecked { get => _isDebugChecked; set => _isDebugChecked = value; }

    private static void DebugOut(string msg)
    {
        if (IsDebugChecked)
        {
            Console.WriteLine(msg);
        }
    }

    private static void DoCommand(string c)
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

    private static void DoSpin(string d)
    {
        SDirection = ((_validDirections.IndexOf(d) > -1) || (_validCommands.IndexOf(d) > -1)) ? d : SDirection;
        DebugOut("doSpin().1 --> d=" + d + ", s_direction=" + SDirection);
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

    public static string ParseCommand(string c)
    {
        Stack items = new();
        string[] tokens = c.Split(' ');
        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i];
            DebugOut("parseCommand().1 aTok=" + token);
            if (token.Length > 1)
            {
                for (var j = 0; j < token.Length; j++)
                {
                    string aCmd = token.Substring(j, 1);
                    DebugOut("parseCommand().2 aCmd=" + aCmd);
                    DoCommand(aCmd);
                }
            }
            else
            {
                bool b = IsInteger(token);
                DebugOut("parseCommand().3 --> b=" + b);
                if (b)
                {
                    items.Push(token);
                    DebugOut("parseCommand().4 items.Count=" + items.Count);
                    if (items.Count == 2)
                    {
                        IPtY = Convert.ToInt32(items.Pop());
                        IPtX = Convert.ToInt32(items.Pop());
                    }
                }
                else if (_validDirections.IndexOf(token) > -1)
                {
                    SDirection = token;
                    DebugOut("parseCommand().5 s_direction=" + SDirection);
                }
                else if (_validCommands.IndexOf(token) > -1)
                {
                    DebugOut("parseCommand().6 doCommand(" + token + ")");
                    DoCommand(token);
                }
            }
        }
        return publish_values();
    }

    private static string publish_values()
    {
        string s = IPtX + " " + IPtY + " " + SDirection;
        Console.WriteLine(s);
        return s;
    }
}