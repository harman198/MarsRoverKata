namespace MarsRoverKata.AcceptanceTests
{
    public class MarsRoverKataTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public Task Program_Output_AcceptanceTest(bool debug)
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            (string Command, string Expected)[] inputs = [("1 2 N", "1 2 N"),
                                                        ("L", "1 2 W"),
                                                        ("M", "0 2 W"),
                                                        ("L", "0 2 S"),
                                                        ("M", "0 1 S"),
                                                        ("L", "0 1 E"),
                                                        ("M", "1 1 E"),
                                                        ("L", "1 1 N"),
                                                        ("M", "1 2 N"),
                                                        ("M", "1 3 N"),
                                                        ("3 3 E", "3 3 E"),
                                                        ("M", "4 3 E"),
                                                        ("M", "5 3 E"),
                                                        ("R", "5 3 S"),
                                                        ("M", "5 2 S"),
                                                        ("M", "5 1 S"),
                                                        ("R", "5 1 W"),
                                                        ("M", "4 1 W"),
                                                        ("R", "4 1 N"),
                                                        ("R", "4 1 E"),
                                                        ("M", "5 1 E"),
                                                        ("1 2 N", "1 2 N"),
                                                        ("LMLMLMLMM", "1 3 N"),
                                                        ("3 3 E", "3 3 E"),
                                                        ("MMRMMRMRRM", "5 1 E")];
            // Act
            Program.RunRover(inputs, debug);

            // Assert
            return Verify(stringWriter.ToString()).UseParameters(debug);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public Task Program_OutputInvalid_AcceptanceTest(bool debug)
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            (string Command, string Expected)[] inputs = [("1 2 N", "1 5 N"),
                                                          ("L 3 R", "1 6 W"),
                                                          ("M 3 R", "0 6 W"),
                                                          ("L 3 R", "0 6 S"),
                                                          ("M 3 R", "0 6 S"),
                                                          ("L 3 R", "0 6 E"),
                                                          ("M 3 R", "1 6 E"),
                                                          ("L 3 R", "1 6 N"),
                                                          ("M 3 R", "1 6 N"),
                                                          ("M 3 R", "1 6 N"),
                                                          ("3 3 E", "3 6 E"),
                                                          ("M 2", "4 6 E"),
                                                          ("M 2", "5 6 E"),
                                                          ("R 2", "5 6 S"),
                                                          ("M 2", "5 6 S"),
                                                          ("M 2", "5 6 S"),
                                                          ("R 2", "5 6 W"),
                                                          ("M 2", "4 6 W"),
                                                          ("R 2", "4 6 N"),
                                                          ("R 2", "4 6 E"),
                                                          ("M 2", "5 6 E"),
                                                          ("1 2 N", "1 6 N"),
                                                          ("LMLMLMLMMLLMM", "1 6 N"),
                                                          ("3 3 EEE 2", "3 6 E"),
                                                          ("MMRMMRMRRMMMRR", "5 7 E")];
            // Act
            Program.RunRover(inputs, debug);

            // Assert
            return Verify(stringWriter.ToString()).UseParameters(debug);
        }
    }
}