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
                            DoSpin(_westDirection);
                            break;
                        case "W":
                            DebugOut("doCommand().4 --> doSpin(southDirection)", IsDebugChecked);
                            DoSpin(_southDirection);
                            break;
                        case "S":
                            DebugOut("doCommand().5 --> doSpin(eastDirection)", IsDebugChecked);
                            DoSpin(_eastDirection);
                            break;
                        case "E":
                            DebugOut("doCommand().6 --> doSpin(northDirection)", IsDebugChecked);
                            DoSpin(_northDirection);
                            break;
                    }
                    break;
                case "R":
                    DebugOut("doCommand().7 --> (c == rightCommand)", IsDebugChecked);
                    switch (SDirection)
                    {
                        case "N":
                            DebugOut("doCommand().8 --> doSpin(eastDirection)", IsDebugChecked);
                            DoSpin(_eastDirection);
                            break;
                        case "E":
                            DebugOut("doCommand().9 --> doSpin(southDirection)", IsDebugChecked);
                            DoSpin(_southDirection);
                            break;
                        case "S":
                            DebugOut("doCommand().10 --> doSpin(westDirection)", IsDebugChecked);
                            DoSpin(_westDirection);
                            break;
                        case "W":
                            DebugOut("doCommand().11 --> doSpin(northDirection)", IsDebugChecked);
                            DoSpin(_northDirection);
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
