using BankingChallenge.Application.Services;
using NUnit.Framework;

namespace BankingChallenge.Tests
{
    public class ArgumentParserServiceTest
    {
        [Test]
        public void ParseArgument_ReturnsDefaultValue_WrongArgumentFormat()
        {
            var argumentParserService = new ArgumentParserService();
            var args = new[] {"abc", "def"};
            var argIndex = 0;
            var defaultValue = 10;

            var argumentValue = argumentParserService.GetArgumentValue(args, argIndex, "Arg", defaultValue);

            Assert.That(argumentValue == defaultValue, "ArgumentValue is not set to default");
        }

        [Test]
        public void ParseArgument_ReturnsDefaultValue_IndexOutOfRange()
        {
            var argumentParserService = new ArgumentParserService();
            var args = new[] { "100", "1000" };
            var argIndex = 10;
            var defaultValue = 10;

            var argumentValue = argumentParserService.GetArgumentValue(args, argIndex, "Arg", defaultValue);

            Assert.That(argumentValue == defaultValue, "ArgumentValue is not set to default");
        }

        [Test]
        public void ParseArgument_ReturnsCorrectValue_ArgumentDecimalValues()
        {
            var argumentParserService = new ArgumentParserService();
            var args = new[] { "100", "1000" };
            var argIndex = 0;

            var argumentValue = argumentParserService.GetArgumentValue(args, argIndex);

            Assert.That(argumentValue == 100, "ArgumentValue is not selected properly");
        }
    }
}