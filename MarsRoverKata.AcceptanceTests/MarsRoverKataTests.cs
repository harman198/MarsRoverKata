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

            // Act
            Program.RunRover(debug);

            // Assert
            return Verify(stringWriter.ToString()).UseParameters(debug);
        }
    }
}