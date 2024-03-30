using URLShortener.Services;

namespace URLShortenerTests
{
    public class ValidateURLTests
    {
        [Theory]
        [InlineData("https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022", true)]
        [InlineData("http://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022", true)]
        [InlineData("https://www.microsoft.com/?", true)]
        public void Should_Return_True(string input, bool expected)
        {
            // Arrange
            var Arrange = new ValidateURL();

            // Act
            bool Act = Arrange.IsValid(input);

            // Assert
            Assert.Equal(expected, Act);
        }

        [Theory]
        [InlineData("ssss://sss.ssssssssss.sss", false)]
        [InlineData("www.youtube.com", false)]
        [InlineData("example.com", false)]
        [InlineData("http://", false)]
        [InlineData("https://", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Should_Return_False(string input, bool expected)
        {
            // Arrange
            var Arrange = new ValidateURL();

            // Act
            bool Act = Arrange.IsValid(input);

            // Assert
            Assert.Equal(expected, Act);
        }
    }
}