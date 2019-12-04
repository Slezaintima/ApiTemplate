using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ValuePerDollar { get; set; }
        public DateTime? Date { get; set; }
        public Char Sign { get; set; }
        public decimal? Amount { get; set; }
    }
}
