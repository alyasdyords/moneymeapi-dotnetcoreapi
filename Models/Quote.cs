using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyme_api.Models
{
    public class Quote
    {
        public long id { get; set; }
        public decimal amountRequired { get; set; }
        public int term { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string mobile { get; set; }
        public string email { get; set; }
        public DateTime createDate { get; set; }
    }
}
