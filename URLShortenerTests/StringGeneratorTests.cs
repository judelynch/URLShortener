using URLShortener.Services;

namespace URLShortenerTests
{
    public class StringGeneratorTests
    {
        [Theory]
        [InlineData("aHR0cHM6Ly93d3cuYmFzZTY0ZW5jb2RlLm9yZy8=")]
        [InlineData("aHR0cHM6Ly93d3cueW91dHViZS5jb20v")]
        [InlineData("aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL2VuLXVzL3Zpc3VhbHN0dWRpby90ZXN0L3dhbGt0aHJvdWdoLWNyZWF0aW5nLWFuZC1ydW5uaW5nLXVuaXQtdGVzdHMtZm9yLW1hbmFnZWQtY29kZT92aWV3PXZzLTIwMjI=")]
        public void Should_Return_String_Length_5(string input)
        {
            // Arrange
            // Act
            string Act = StringGenerator.Create(input);
            // Assert
            Assert.Equal(5, Act.Length);
        }

        [Fact]
        public void Should_Return_Same_String()
        {
            // Arrange
            string Arrange1 = "aHR0cHM6Ly93d3cueW91dHViZS5jb20v";
            string Arrange2 = "aHR0cHM6Ly93d3cueW91dHViZS5jb20v";

            // Act
            string Act1 = StringGenerator.Create(Arrange1);
            string Act2 = StringGenerator.Create(Arrange2);

            // Assert
            Assert.Equal(Act1, Act2);
        }

        [Fact]
        public void Should_Return_Different_String()
        {
            // Arrange
            string Arrange1 = "aHR0cHM6Ly93d3cueW91dHViZS5jb20v";
            string Arrange2 = "aHR0cHM6Ly93d3cuYmFzZTY0ZW5jb2RlLm9yZy8=";

            // Act
            string Act1 = StringGenerator.Create(Arrange1);
            string Act2 = StringGenerator.Create(Arrange2);

            // Assert
            Assert.NotEqual(Act1, Act2);
        }
    }
}