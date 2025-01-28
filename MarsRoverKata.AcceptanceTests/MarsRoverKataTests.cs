namespace MarsRoverKata.AcceptanceTests
{
    public class MarsRoverKataTests
    {
        [Fact]
        public Task Program_Output_AcceptanceTest()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.Main([]);

            // Assert
            return Verify(stringWriter.ToString());
        }
    }
}