using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI
{
    public class PaymentPerMonth
    {
        public int SL { get; set; }
        public double BeginningBalance { get; set; }
        public double MonthlyInstallment { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
        public double Balence { get; set; }
    }
}
