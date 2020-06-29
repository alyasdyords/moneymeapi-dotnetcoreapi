using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyme_api.Models
{
    public class CustomerRequestLoan
    {
        public long id { get; set; }
        public decimal amountRequired { get; set; }
        public int term { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string mobile { get; set; }
        public string email { get; set; }

        public decimal termPayment { get; set; }
        public decimal totalInterest { get; set; }
        public decimal establishementFee {get;set;}

        public DateTime createDate { get; set; }
    }
}
