using System.Collections;

namespace MarsRoverKata
{
    public class Rover
    {
        private readonly static string _validDirections = "NSEW";
        private readonly static string _northDirection = "N";
        private readonly static string _southDirection = "S";
        private readonly static string _eastDirection = "E";
        private readonly static string _westDirection = "W";

        private readonly static string _validCommands = "LRM";

        public int IPtX { get; set; } = 0;
        public int IPtY { get; set; } = 0;
        public string SDirection { get; set; } = "";

        private bool IsDebugChecked { get; set; } = false;

        public void DebugOut(string msg, bool isDebugChecked)
        {
            if (isDebugChecked)
            {
                Console.WriteLine(msg);
            }
        }

        public string ParseCommand(string c, bool IsDebugChecked)
        {
            Stack items = new();
            string[] tokens = c.Split(' ');
            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                DebugOut("parseCommand().1 aTok=" + token, IsDebugChecked);
                if (token.Length > 1)
                {
                    for (var j = 0; j < token.Length; j++)
                    {
                        string aCmd = token.Substring(j, 1);
                        DebugOut("parseCommand().2 aCmd=" + aCmd, IsDebugChecked);
                        DoCommand(aCmd, IsDebugChecked);
                    }
                }
                else
                {
                    bool b = Rover.IsInteger(token);
                    DebugOut("parseCommand().3 --> b=" + b, IsDebugChecked);
                    if (b)
                    {
                        items.Push(token);
                        DebugOut("parseCommand().4 items.Count=" + items.Count, IsDebugChecked);
                        if (items.Count == 2)
                        {
                            IPtY = Convert.ToInt32(items.Pop());
                            IPtX = Convert.ToInt32(items.Pop());
                        }
                    }
                    else if (_validDirections.IndexOf(token) > -1)
                    {
                        SDirection = token;
                        DebugOut("parseCommand().5 s_direction=" + SDirection, IsDebugChecked);
                    }
                    else if (_validCommands.IndexOf(token) > -1)
                    {
                        DebugOut("parseCommand().6 doCommand(" + token + ")", IsDebugChecked);
                        DoCommand(token, IsDebugChecked);
                    }
                }
            }
            return publish_values();
        }

        public void DoCommand(string c, bool IsDebugChecked)
        {
            DebugOut("doCommand().1 --> c=" + c, IsDebugChecked);
            switch (c)
            {
                case "L":
                    DebugOut("doCommand().2 --> (c == leftCommand)", IsDebugChecked);
                    switch (SDirection)
                    {
                        case "N":
                            DebugOut("doCommand().3 --> doSpin(westDirection)", IsDebugChecked);
                            DoSpin(_westDirection, IsDebugChecked);
                            break;
                        case "W":
                            DebugOut("doCommand().4 --> doSpin(southDirection)", IsDebugChecked);
                            DoSpin(_southDirection, IsDebugChecked);
                            break;
                        case "S":
                            DebugOut("doCommand().5 --> doSpin(eastDirection)", IsDebugChecked);
                            DoSpin(_eastDirection, IsDebugChecked);
                            break;
                        case "E":
                            DebugOut("doCommand().6 --> doSpin(northDirection)", IsDebugChecked);
                            DoSpin(_northDirection, IsDebugChecked);
                            break;
                    }
                    break;
                case "R":
                    DebugOut("doCommand().7 --> (c == rightCommand)", IsDebugChecked);
                    switch (SDirection)
                    {
                        case "N":
                            DebugOut("doCommand().8 --> doSpin(eastDirection)", IsDebugChecked);
                            DoSpin(_eastDirection, IsDebugChecked);
                            break;
                        case "E":
                            DebugOut("doCommand().9 --> doSpin(southDirection)", IsDebugChecked);
                            DoSpin(_southDirection, IsDebugChecked);
                            break;
                        case "S":
                            DebugOut("doCommand().10 --> doSpin(westDirection)", IsDebugChecked);
                            DoSpin(_westDirection, IsDebugChecked);
                            break;
                        case "W":
                            DebugOut("doCommand().11 --> doSpin(northDirection)", IsDebugChecked);
                            DoSpin(_northDirection, IsDebugChecked);
                            break;
                    }
                    break;
                case "M":
                    DebugOut("doCommand().12 --> (c == moveCommand)", IsDebugChecked);
                    DoMove(IsDebugChecked);
                    break;
            }
        }


        public void DoMove(bool isDebugChecked)
        {
            switch (SDirection)
            {
                case "N":
                    DebugOut("doMove().1 --> (s_direction == northDirection)", isDebugChecked);
                    IPtY = IPtY + 1;
                    break;
                case "E":
                    DebugOut("doMove().2 --> (s_direction == eastDirection)", isDebugChecked);
                    IPtX = IPtX + 1;
                    break;
                case "S":
                    DebugOut("doMove().3 --> (s_direction == southDirection)", isDebugChecked);
                    IPtY = IPtY - 1;
                    break;
                case "W":
                    DebugOut("doMove().4 --> (s_direction == westDirection)", isDebugChecked);
                    IPtX = IPtX - 1;
                    break;
            }
        }

        public void DoSpin(string d, bool IsDebugChecked)
        {
            SDirection = ((_validDirections.IndexOf(d) > -1) || (_validCommands.IndexOf(d) > -1)) ? d : SDirection;
            DebugOut("doSpin().1 --> d=" + d + ", s_direction=" + SDirection, IsDebugChecked);
        }

        public string publish_values()
        {
            string s = IPtX + " " + IPtY + " " + SDirection;
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
