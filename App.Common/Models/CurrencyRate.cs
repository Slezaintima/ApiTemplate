using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class CurrencyRate
    {

        public int CurrencyRateId { get; set; }
        public DateTime Date { get; set; }
        public decimal ValuePerDollar { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
