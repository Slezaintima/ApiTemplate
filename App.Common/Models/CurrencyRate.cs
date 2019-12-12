using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class CurrencyRate
    {
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public decimal ValuePerDollar { get; set; }
    }
}
