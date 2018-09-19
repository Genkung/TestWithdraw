using System;
using Xunit;
using Withdraw;

namespace MyTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, null, "No money to withdraw")]
        [InlineData(12.23, null, "Wrong withdraw")]
        [InlineData(712.025, null, "Wrong withdraw")]
        [InlineData(385.25, new double[] {0, 0, 3, 1, 1, 1, 1, 0, 0, 0, 1}, "Success")]
        [InlineData(2898.75, new double[] {2, 1, 3, 1, 2, 0, 1, 1, 1, 1, 1}, "Success")]
        [InlineData(5000, new double[] {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, "Success")]
        public void Test1(double withdraw, double[] expectedBank, string expectedMsg)
        {
            var svc = new WithdrawService();
            var result = svc.GetAllBank(withdraw);
            Assert.Equal(expectedBank, result.BankSet);
            Assert.Equal(expectedMsg, result.ResponseMessage);
        }
    }
}
