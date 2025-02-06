namespace MarsRoverKata
{
    public class Rover(bool isDebugChecked, CommandParser commandParser, Printer printer)
    {
        private readonly static string _validDirections = "NSEW";
        private readonly static string _northDirection = "N";
        private readonly static string _southDirection = "S";
        private readonly static string _eastDirection = "E";
        private readonly static string _westDirection = "W";

        private readonly static string _validCommands = "LRM";
        private readonly CommandParser _commandParser = commandParser;
        private readonly Printer _printer = printer;

        private int X_Position { get; set; } = 0;
        private int Y_Position { get; set; } = 0;
        private DirectionEnum Direction { get; set; }

        private bool IsDebugChecked { get; init; } = isDebugChecked;

        public string ParseCommand(string c)
        {
            Stack<int> items = new();
            string[] tokens = c.Split(' ');
            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                _printer.DebugOut("parseCommand().1 aTok=" + token);
                if (token.Length > 1)
                {
                    for (var j = 0; j < token.Length; j++)
                    {
                        string aCmd = token.Substring(j, 1);
                        _printer.DebugOut("parseCommand().2 aCmd=" + aCmd);
                        DoCommand(aCmd);
                    }
                }
                else
                {
                    bool isInteger = int.TryParse(token, out int intValue);
                    _printer.DebugOut("parseCommand().3 --> b=" + isInteger);
                    if (isInteger)
                    {
                        items.Push(intValue);
                        _printer.DebugOut("parseCommand().4 items.Count=" + items.Count);
                        if (items.Count == 2)
                        {
                            Y_Position = items.Pop();
                            X_Position = items.Pop();
                        }
                    }
                    else if (_validDirections.IndexOf(token) > -1)
                    {
                        Direction = CommandParser.ParseDirectionToken(token);
                        _printer.DebugOut("parseCommand().5 s_direction=" + CommandParser.DirectionEnumToString(Direction));
                    }
                    else if (_validCommands.IndexOf(token) > -1)
                    {
                        _printer.DebugOut("parseCommand().6 doCommand(" + token + ")");
                        DoCommand(token);
                    }
                }
            }
            return PublishValues();
        }

        private void DoCommand(string c)
        {
            _printer.DebugOut("doCommand().1 --> c=" + c);
            switch (c)
            {
                case "L":
                    _printer.DebugOut("doCommand().2 --> (c == leftCommand)");
                    switch (Direction)
                    {
                        case DirectionEnum.North:
                            _printer.DebugOut("doCommand().3 --> doSpin(westDirection)");
                            DoSpin(_westDirection);
                            break;
                        case DirectionEnum.West:
                            _printer.DebugOut("doCommand().4 --> doSpin(southDirection)");
                            DoSpin(_southDirection);
                            break;
                        case DirectionEnum.South:
                            _printer.DebugOut("doCommand().5 --> doSpin(eastDirection)");
                            DoSpin(_eastDirection);
                            break;
                        case DirectionEnum.East:
                            _printer.DebugOut("doCommand().6 --> doSpin(northDirection)");
                            DoSpin(_northDirection);
                            break;
                    }
                    break;
                case "R":
                    _printer.DebugOut("doCommand().7 --> (c == rightCommand)");
                    switch (Direction)
                    {
                        case DirectionEnum.North:
                            _printer.DebugOut("doCommand().8 --> doSpin(eastDirection)");
                            DoSpin(_eastDirection);
                            break;
                        case DirectionEnum.East:
                            _printer.DebugOut("doCommand().9 --> doSpin(southDirection)");
                            DoSpin(_southDirection);
                            break;
                        case DirectionEnum.South:
                            _printer.DebugOut("doCommand().10 --> doSpin(westDirection)");
                            DoSpin(_westDirection);
                            break;
                        case DirectionEnum.West:
                            _printer.DebugOut("doCommand().11 --> doSpin(northDirection)");
                            DoSpin(_northDirection);
                            break;
                    }
                    break;
                case "M":
                    _printer.DebugOut("doCommand().12 --> (c == moveCommand)");
                    DoMove();
                    break;
            }
        }

        private void DoMove()
        {
            switch (Direction)
            {
                case DirectionEnum.North:
                    _printer.DebugOut("doMove().1 --> (s_direction == northDirection)");
                    Y_Position++;
                    break;
                case DirectionEnum.East:
                    _printer.DebugOut("doMove().2 --> (s_direction == eastDirection)");
                    X_Position++;
                    break;
                case DirectionEnum.South:
                    _printer.DebugOut("doMove().3 --> (s_direction == southDirection)");
                    Y_Position--;
                    break;
                case DirectionEnum.West:
                    _printer.DebugOut("doMove().4 --> (s_direction == westDirection)");
                    X_Position--;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private void DoSpin(string d)
        {
            Direction = ((_validDirections.IndexOf(d) > -1) || (_validCommands.IndexOf(d) > -1)) ? CommandParser.ParseDirectionToken(d) : Direction;
            _printer.DebugOut("doSpin().1 --> d=" + d + ", s_direction=" + CommandParser.DirectionEnumToString(Direction));
        }

        private string PublishValues()
        {
            string s = X_Position + " " + Y_Position + " " + CommandParser.DirectionEnumToString(Direction);
            Console.WriteLine(s);
            return s;
        }

        public enum DirectionEnum
        {
            North,
            West,
            South,
            East
        }

    }

}
