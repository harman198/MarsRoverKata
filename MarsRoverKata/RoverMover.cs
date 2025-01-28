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


    private static void DoCommand(string c)
    {
        _rover.DebugOut("doCommand().1 --> c=" + c, IsDebugChecked);
        switch (c)
        {
            case "L":
                _rover.DebugOut("doCommand().2 --> (c == leftCommand)", IsDebugChecked);
                switch (_rover.SDirection)
                {
                    case "N":
                        _rover.DebugOut("doCommand().3 --> doSpin(westDirection)", IsDebugChecked);
                        DoSpin(_westDirection);
                        break;
                    case "W":
                        _rover.DebugOut("doCommand().4 --> doSpin(southDirection)", IsDebugChecked);
                        DoSpin(_southDirection);
                        break;
                    case "S":
                        _rover.DebugOut("doCommand().5 --> doSpin(eastDirection)", IsDebugChecked);
                        DoSpin(_eastDirection);
                        break;
                    case "E":
                        _rover.DebugOut("doCommand().6 --> doSpin(northDirection)", IsDebugChecked);
                        DoSpin(_northDirection);
                        break;
                }
                break;
            case "R":
                _rover.DebugOut("doCommand().7 --> (c == rightCommand)", IsDebugChecked);
                switch (_rover.SDirection)
                {
                    case "N":
                        _rover.DebugOut("doCommand().8 --> doSpin(eastDirection)", IsDebugChecked);
                        DoSpin(_eastDirection);
                        break;
                    case "E":
                        _rover.DebugOut("doCommand().9 --> doSpin(southDirection)", IsDebugChecked);
                        DoSpin(_southDirection);
                        break;
                    case "S":
                        _rover.DebugOut("doCommand().10 --> doSpin(westDirection)", IsDebugChecked);
                        DoSpin(_westDirection);
                        break;
                    case "W":
                        _rover.DebugOut("doCommand().11 --> doSpin(northDirection)", IsDebugChecked);
                        DoSpin(_northDirection);
                        break;
                }
                break;
            case "M":
                _rover.DebugOut("doCommand().12 --> (c == moveCommand)", IsDebugChecked);
                _rover.DoMove(IsDebugChecked);
                break;
        }
    }

    private static void DoSpin(string d)
    {
        _rover.DoSpin(d, IsDebugChecked);
    }

    public static string ParseCommand(string c)
    {
        Stack items = new();
        string[] tokens = c.Split(' ');
        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i];
            _rover.DebugOut("parseCommand().1 aTok=" + token, IsDebugChecked);
            if (token.Length > 1)
            {
                for (var j = 0; j < token.Length; j++)
                {
                    string aCmd = token.Substring(j, 1);
                    _rover.DebugOut("parseCommand().2 aCmd=" + aCmd, IsDebugChecked);
                    DoCommand(aCmd);
                }
            }
            else
            {
                bool b = Rover.IsInteger(token);
                _rover.DebugOut("parseCommand().3 --> b=" + b, IsDebugChecked);
                if (b)
                {
                    items.Push(token);
                    _rover.DebugOut("parseCommand().4 items.Count=" + items.Count, IsDebugChecked);
                    if (items.Count == 2)
                    {
                        _rover.IPtY = Convert.ToInt32(items.Pop());
                        _rover.IPtX = Convert.ToInt32(items.Pop());
                    }
                }
                else if (_validDirections.IndexOf(token) > -1)
                {
                    _rover.SDirection = token;
                    _rover.DebugOut("parseCommand().5 s_direction=" + _rover.SDirection, IsDebugChecked);
                }
                else if (_validCommands.IndexOf(token) > -1)
                {
                    _rover.DebugOut("parseCommand().6 doCommand(" + token + ")", IsDebugChecked);
                    DoCommand(token);
                }
            }
        }
        return _rover.publish_values();
    }

}