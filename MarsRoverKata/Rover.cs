using System.Collections;

namespace MarsRoverKata
{
    public class Rover(bool isDebugChecked)
    {
        private readonly static string _validDirections = "NSEW";
        private readonly static string _northDirection = "N";
        private readonly static string _southDirection = "S";
        private readonly static string _eastDirection = "E";
        private readonly static string _westDirection = "W";

        private readonly static string _validCommands = "LRM";

        public int X_Position { get; set; } = 0;
        public int Y_Position { get; set; } = 0;
        public string Direction { get; set; } = "";

        private bool IsDebugChecked { get; init; } = isDebugChecked;

        public void DebugOut(string msg)
        {
            if (IsDebugChecked)
            {
                Console.WriteLine(msg);
            }
        }

        public string ParseCommand(string c)
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
                            Y_Position = Convert.ToInt32(items.Pop());
                            X_Position = Convert.ToInt32(items.Pop());
                        }
                    }
                    else if (_validDirections.IndexOf(token) > -1)
                    {
                        Direction = token;
                        DebugOut("parseCommand().5 s_direction=" + Direction);
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

        public void DoCommand(string c)
        {
            DebugOut("doCommand().1 --> c=" + c);
            switch (c)
            {
                case "L":
                    DebugOut("doCommand().2 --> (c == leftCommand)");
                    switch (Direction)
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
                    switch (Direction)
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

        public void DoMove()
        {
            switch (Direction)
            {
                case "N":
                    DebugOut("doMove().1 --> (s_direction == northDirection)");
                    Y_Position = Y_Position + 1;
                    break;
                case "E":
                    DebugOut("doMove().2 --> (s_direction == eastDirection)");
                    X_Position = X_Position + 1;
                    break;
                case "S":
                    DebugOut("doMove().3 --> (s_direction == southDirection)");
                    Y_Position = Y_Position - 1;
                    break;
                case "W":
                    DebugOut("doMove().4 --> (s_direction == westDirection)");
                    X_Position = X_Position - 1;
                    break;
            }
        }

        public void DoSpin(string d)
        {
            Direction = ((_validDirections.IndexOf(d) > -1) || (_validCommands.IndexOf(d) > -1)) ? d : Direction;
            DebugOut("doSpin().1 --> d=" + d + ", s_direction=" + Direction);
        }

        public string publish_values()
        {
            string s = X_Position + " " + Y_Position + " " + Direction;
            Console.WriteLine(s);
            return s;
        }

        public static bool IsInteger(string theValue)
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
    }
}
