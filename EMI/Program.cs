using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI
{
    class Program
    {
        static void Main(string[] args)
        {
            double LoanAmount = 0;
            double Payment = 0;
            double InterestRate = 0;
            int PaymentPeriods = 0;
            try
            {
                int sl=1;
                Console.WriteLine("Enter The Loan Amount");
                LoanAmount =Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter The Interest Rate");
                InterestRate =Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter The Year");
                PaymentPeriods =Convert.ToInt16(Console.ReadLine())*12; 
                 
                if (InterestRate > 1)
                {
                    InterestRate = Math.Round(InterestRate / 100, 2, MidpointRounding.AwayFromZero);
                }
                Payment =Math.Round((LoanAmount * Math.Pow((InterestRate / 12) + 1,
                    (PaymentPeriods)) * InterestRate / 12) / (Math.Pow(InterestRate / 12 + 1, (PaymentPeriods)) - 1),2);
                List<PaymentPerMonth> PaymentSchuld = new List<PaymentPerMonth>();
                EmiCalculate(LoanAmount, InterestRate, Payment, sl, PaymentSchuld);
                foreach (var item in PaymentSchuld)
                {
                    Console.WriteLine("SL={0} Beginning Balance={1} Monthly installment={2} Interest={3} Principal={4} Balence={5}",item.SL,item.BeginningBalance,item.MonthlyInstallment,item.Interest,item.Principal,item.Balence);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private static void EmiCalculate(double LoanAmount, double InterestRate, double Payment, int sl, List<PaymentPerMonth> PaymentSchuld)
        {
            
            PaymentPerMonth model = new PaymentPerMonth();
            model.SL = sl;
            model.BeginningBalance = LoanAmount;
            model.MonthlyInstallment = Payment;
            model.Interest = Math.Round(LoanAmount * InterestRate / 12, 2, MidpointRounding.AwayFromZero);
            model.Principal = Payment - model.Interest;
            model.Balence = Math.Round(LoanAmount - model.Principal, 2, MidpointRounding.AwayFromZero);
            PaymentSchuld.Add(model);
            if (model.Balence>0)
            {
                EmiCalculate(model.Balence, InterestRate, Payment, sl+1,PaymentSchuld);
            }
            else
            {
                model.Balence = 0;
            }
        }
    }
}
