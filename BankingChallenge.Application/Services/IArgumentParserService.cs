namespace BankingChallenge.Application.Services
{
    public interface IArgumentParserService
    {
        decimal GetArgumentValue(string[] args, int argumentIndex, string argumentName = "variable", decimal defaultValue = 0);
    }
}
