namespace BankingChallenge.Application.Services
{
    public interface ICalculusService
    {
        decimal CalculateAdminFee(decimal totalAmount, decimal feePercentage, decimal feeMaxValue);
        decimal CalculateSinglePaymentAmount(decimal duration, decimal interval, decimal interest, decimal amount);
        decimal CalculateTotalAmount(decimal singlePayment, decimal duration, decimal interval);
        decimal CalculateTotalInterestAmount(decimal totalAmount, decimal amount);
    }
}
