using System;
using Withdraw;
using System.Linq;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double total;
            double pay;
            double[] allWithdrawSet = new double[] { 1000, 500, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25 };
            WithdrawService svc = new WithdrawService();

            Console.Write("Input total : ");
            var inputTotal = Console.ReadLine();
            if (!Double.TryParse(inputTotal, out total))
            {
                Console.WriteLine("Please input number!!");
                return;
            }
            
            if((total % 1) != 0 && (total % 1) != 0.25  && (total % 1) != 0.5 && (total % 1) != 0.75 )
            {
                Console.WriteLine("Wrong total!!");
                return;
            }

            Console.Write("Input pay : ");
            var inputPay = Console.ReadLine();
            if (!Double.TryParse(inputPay, out pay))
            {
                Console.WriteLine("Please input number!!");
                return;
            }

            if (pay < total)
            {
                Console.WriteLine("Not enough money to pay");
                return;
            }
            
            var withdraw = pay - total;
            
            var result = svc.GetAllBank(withdraw);

            Console.WriteLine($"Total withdraw :  {withdraw}");
            
            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i] == 0) continue;
                Console.WriteLine($"Bank {allWithdrawSet[i]} : {result[i]}");
            }
        }
    }
}
