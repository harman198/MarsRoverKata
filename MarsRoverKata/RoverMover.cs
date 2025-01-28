using MarsRoverKata;
using System.Collections;

internal static class RoverMover
{
    private static readonly Rover _rover = new();
    private readonly static string _validDirections = "NSEW";
    private readonly static string _validCommands = "LRM";
    private readonly static string _leftCommand = "L";
    private readonly static string _rightCommand = "R";
    private readonly static string _moveCommand = "M";

    public static bool IsDebugChecked { get; set; } = false;


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
                    _rover.DoCommand(aCmd, IsDebugChecked);
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
                    _rover.DoCommand(token, IsDebugChecked);
                }
            }
        }
        return _rover.publish_values();
    }

}