using System;
using System.Linq;

namespace Withdraw
{
    public class WithdrawService
    {
        public WithDrawResponse GetAllBank(double amount)
        {
            if (amount == 0)
            {
                  return new WithDrawResponse{BankSet = null, ResponseMessage = "No money to withdraw"};
            }
            
            if ((amount % 1) != 0 && (amount % 1) != 0.25  && (amount % 1) != 0.5 && (amount % 1) != 0.75 )
            {
                return new WithDrawResponse{BankSet = null, ResponseMessage = "Wrong withdraw"};
            }
            
            double[] allBankSet = new double[] { 1000, 500, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25 };
            double[] withdrawBank = new double[11];


            for (int i = 0; i < allBankSet.Count(); i++)
            {
                if (amount >= allBankSet[i])
                {
                    var bankCount = Math.Floor(amount / allBankSet[i]);
                    withdrawBank[i] = bankCount;
                    amount = amount % allBankSet[i];
                }
            }
            
            return new WithDrawResponse{BankSet = withdrawBank, ResponseMessage = "Success"};
        }
    }
    
    public class WithDrawResponse
    {
        public double[] BankSet {get; set;}
        public string ResponseMessage {get; set;}
    }
}
