using URLShortener.Services;

namespace URLShortenerTests
{
    public class StringConvertTests
    {
        [Theory]
        [InlineData("https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022",
                    "aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL2VuLXVzL3Zpc3VhbHN0dWRpby90ZXN0L3dhbGt0aHJvdWdoLWNyZWF0aW5nLWFuZC1ydW5uaW5nLXVuaXQtdGVzdHMtZm9yLW1hbmFnZWQtY29kZT92aWV3PXZzLTIwMjI=")]
        [InlineData("https://www.youtube.com/", "aHR0cHM6Ly93d3cueW91dHViZS5jb20v")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void Should_Encode_String_Or_Return_Empty(string input, string expected)
        {
            // Arrange
            var Arrange = new StringConvert();

            // Act
            string Act = Arrange.EncodeString(input);

            // Assert
            Assert.Equal(expected, Act);
        }

        [Theory]
        [InlineData("aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL2VuLXVzL3Zpc3VhbHN0dWRpby90ZXN0L3dhbGt0aHJvdWdoLWNyZWF0aW5nLWFuZC1ydW5uaW5nLXVuaXQtdGVzdHMtZm9yLW1hbmFnZWQtY29kZT92aWV3PXZzLTIwMjI=",
                    "https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022")]
        [InlineData("aHR0cHM6Ly93d3cueW91dHViZS5jb20v", "https://www.youtube.com/")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void Should_Decode_String_Or_Return_Empty(string input, string expected)
        {
            // Arrange
            var Arrange = new StringConvert();

            // Act
            string Act = Arrange.DecodeString(input);

            // Assert
            Assert.Equal(expected, Act);
        }

    }
}
