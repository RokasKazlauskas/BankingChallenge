using System;

namespace BankingChallenge.Application.Services
{
    public class CalculusService : ICalculusService
    {
        public decimal CalculateAdminFee(decimal totalAmount, decimal feePercentage, decimal feeMaxValue)
        {
            var adminFee = totalAmount * feePercentage / 100;

            if (adminFee > feeMaxValue)
                adminFee = feeMaxValue;

            return adminFee;
        }

        public decimal CalculateSinglePaymentAmount(decimal duration, decimal interval, decimal interest, decimal amount)
        {
            var paymentCount = 12 * duration / interval;
            var interestRateDuringTimeFrame = (interest / 100) / (12 / interval);
            var tempFormulaCalculus = (decimal)Math.Pow((double)(1 + interestRateDuringTimeFrame), (double)paymentCount);

            return (amount * interestRateDuringTimeFrame * tempFormulaCalculus) / (tempFormulaCalculus - 1);
        }

        public decimal CalculateTotalAmount(decimal singlePayment, decimal duration, decimal interval)
        {
            return singlePayment * 12 * duration / interval;
        }

        public decimal CalculateTotalInterestAmount(decimal totalAmount, decimal amount)
        {
            return totalAmount - amount;
        }
    }
}
