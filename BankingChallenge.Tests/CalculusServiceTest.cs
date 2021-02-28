using System;
using BankingChallenge.Application.Services;
using NUnit.Framework;

namespace BankingChallenge.Tests
{
    public class CalculusServiceTest
    {

        [Test]
        public void CalculateAdminFee_ReturnsMaximumFeeValue_CalculatedFeeOverTheLimit()
        {
            var calculusService = new CalculusService();
            var amount = 500000m;
            var feePercentage = 50m;
            var maximumFee = 10000m;

            var adminFee = calculusService.CalculateAdminFee(amount, feePercentage, maximumFee);
            
            Assert.That(adminFee == maximumFee, $"Administration fee was not set to maximum fee; Expected Value {maximumFee}; Given Value {adminFee};");
        }

        [Test]
        public void CalculateAdminFee_ReturnsCalculatedFee_CalculatedFeeBelowTheLimit()
        {
            var calculusService = new CalculusService();
            var amount = 500000m;
            var feePercentage = 3m;
            var maximumFee = 100000m;
            var expectedFee = amount * feePercentage / 100;

            var adminFee = calculusService.CalculateAdminFee(amount, feePercentage, maximumFee);

            Assert.That(adminFee == expectedFee, $"Administration fee was not set lower compared to maximum fee; Expected Value {expectedFee}; Given Value {adminFee};");
        }

        [TestCase(500000, 5, 10, 1, 5303.28)]
        [TestCase(500000, 5, 10, 6, 32073.56)]
        [TestCase(1000000, 2, 5, 3, 52666.45)]
        public void CalculateSinglePaymentAmount_ReturnsMonthlyFee_5PercentInterest_Monthly_10Years_500000Amount(decimal amount, decimal interest, decimal duration, decimal monthlyInterval, decimal expectedPayment)
        {
            var calculusService = new CalculusService();

            var monthlyPayment = Math.Round(calculusService.CalculateSinglePaymentAmount(duration, monthlyInterval, interest, amount), 2);

            Assert.That(monthlyPayment == expectedPayment, $"Monthly payment was calculated incorrectly; Expected Value {expectedPayment}; Given Value {monthlyPayment};");
        }
        
        [Test]
        public void CalculateTotalAmount()
        {
            var calculusService = new CalculusService();
            var expectedAmount = 636393.60m;
            var singlePayment = 5303.28m;
            var duration = 10m;
            var monthlyInterval = 1m;

            var totalAmount = calculusService.CalculateTotalAmount(singlePayment, duration, monthlyInterval);

            Assert.That(totalAmount == expectedAmount, $"Total amount was calculated incorrectly; Expected Value {expectedAmount}; Given Value {totalAmount};");
        }
    }
}