using MarsRoverKata;
using System.Collections;

internal static class RoverMover
{
    private static readonly Rover _rover = new();
    private readonly static string _validDirections = "NSEW";
    private readonly static string _northDirection = "N";
    private readonly static string _southDirection = "S";
    private readonly static string _eastDirection = "E";
    private readonly static string _westDirection = "W";
    private readonly static string _validCommands = "LRM";
    private readonly static string _leftCommand = "L";
    private readonly static string _rightCommand = "R";
    private readonly static string _moveCommand = "M";

    public static bool IsDebugChecked { get; set; } = false;

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
                switch (_rover.SDirection)
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
                switch (_rover.SDirection)
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
        switch (_rover.SDirection)
        {
            case "N":
                DebugOut("doMove().1 --> (s_direction == northDirection)");
                _rover.IPtY = _rover.IPtY + 1;
                break;
            case "E":
                DebugOut("doMove().2 --> (s_direction == eastDirection)");
                _rover.IPtX = _rover.IPtX + 1;
                break;
            case "S":
                DebugOut("doMove().3 --> (s_direction == southDirection)");
                _rover.IPtY = _rover.IPtY - 1;
                break;
            case "W":
                DebugOut("doMove().4 --> (s_direction == westDirection)");
                _rover.IPtX = _rover.IPtX - 1;
                break;
        }
    }

    private static void DoSpin(string d)
    {
        _rover.SDirection = ((_validDirections.IndexOf(d) > -1) || (_validCommands.IndexOf(d) > -1)) ? d : _rover.SDirection;
        DebugOut("doSpin().1 --> d=" + d + ", s_direction=" + _rover.SDirection);
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
                bool b = Rover.IsInteger(token);
                DebugOut("parseCommand().3 --> b=" + b);
                if (b)
                {
                    items.Push(token);
                    DebugOut("parseCommand().4 items.Count=" + items.Count);
                    if (items.Count == 2)
                    {
                        _rover.IPtY = Convert.ToInt32(items.Pop());
                        _rover.IPtX = Convert.ToInt32(items.Pop());
                    }
                }
                else if (_validDirections.IndexOf(token) > -1)
                {
                    _rover.SDirection = token;
                    DebugOut("parseCommand().5 s_direction=" + _rover.SDirection);
                }
                else if (_validCommands.IndexOf(token) > -1)
                {
                    DebugOut("parseCommand().6 doCommand(" + token + ")");
                    DoCommand(token);
                }
            }
        }
        return _rover.publish_values();
    }

}