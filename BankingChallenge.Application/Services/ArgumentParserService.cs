using System;

namespace BankingChallenge.Application.Services
{
    public class ArgumentParserService : IArgumentParserService
    {
        public decimal GetArgumentValue(string[] args, int argumentIndex, string argumentName = "variable", decimal defaultValue = 0)
        {
            if (args.Length <= argumentIndex)
            {
                Console.WriteLine($"Argument {argumentIndex}, was not provided, using default value for {argumentName}");
                return defaultValue;
            }

            var parseSuccessful = decimal.TryParse(args[argumentIndex], out decimal argValue);

            if (!parseSuccessful)
            {
                Console.WriteLine($"Could not parse argument: {argumentIndex}; value, all arguments must be of decimal type");
                return defaultValue;
            }

            return argValue;
        }
    }
}
