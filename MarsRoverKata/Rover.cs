namespace MarsRoverKata
{
    public class Rover
    {
        public int IPtX { get; set; } = 0;
        public int IPtY { get; set; } = 0;
        public string SDirection { get; set; } = "";

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
