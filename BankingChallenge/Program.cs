using System;
using BankingChallenge.Application.Services;

namespace BankingChallenge
{
    class Program
    {
        private static readonly IArgumentParserService ArgumentParser = new ArgumentParserService();
        private static readonly ICalculusService Calculus = new CalculusService();

        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                Console.WriteLine("Please enter loan amount and duration of the loan (interest and administration fee percentage/maximum value are optional parameters)");

                return;
            }

            var amount = ArgumentParser.GetArgumentValue(args, 0, "total amount");
            var duration = ArgumentParser.GetArgumentValue(args, 1, "duration in years");

            if (amount == 0 || duration == 0)
            {
                Console.WriteLine("Loan amount and duration of the loan must be provided with positive decimal values, please check provided arguments");
                return;
            }

            var interest = ArgumentParser.GetArgumentValue(args, 2, "interest rate", 5);
            var adminFeePercentage = ArgumentParser.GetArgumentValue(args, 3, "admin fee percentage", 1);
            var adminFeeMaxValue = ArgumentParser.GetArgumentValue(args, 4, "admin fee maximum value", 10000);
            var interval = ArgumentParser.GetArgumentValue(args, 5,"interest interval", 1);

            if (amount < 0 || duration < 0 || interest < 0 || adminFeePercentage < 0 || adminFeeMaxValue < 0)
            {
                Console.WriteLine("All arguments must be positive values, please check provided arguments");
                return;
            }

            var adminFee = Calculus.CalculateAdminFee(amount, adminFeePercentage, adminFeeMaxValue);
            var singlePayment = Calculus.CalculateSinglePaymentAmount(duration, interval, interest, amount);
            var totalAmount = Calculus.CalculateTotalAmount(singlePayment, duration, interval);
            var totalInterestAmount = Calculus.CalculateTotalInterestAmount(totalAmount, amount);
            
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Loan amount: {amount} kr.; Loan duration: {duration} year(s); interest rate: {interest}%; Administration fee: {adminFee} kr.");
            Console.WriteLine($"Interest rate is calculated and payments are conducted every: {interval} month(s)");
            Console.WriteLine($"Single payment amount: {Math.Round(singlePayment, 2)} kr.");
            Console.WriteLine($"Total interest: {Math.Round(totalInterestAmount, 2)} kr.");
            Console.WriteLine($"Total amount (without administration fee): {Math.Round(totalAmount, 2)} kr.");
            Console.Read();
        }
    }
}
