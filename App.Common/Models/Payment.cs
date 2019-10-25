using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Payment
    {
        public Payment(int PaymentNumber, string status)
        {
            p_number = PaymentNumber;
            Status = status;
        }

        public int p_number { get; set; }
        public string Status { get; set; }
    }
}
