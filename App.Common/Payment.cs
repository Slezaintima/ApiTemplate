using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class Payment
    {
        public Payment(int iD, string status)
        {
            ID = iD;
            Status = status;
        }

        public int ID { get; set; }
        public string Status { get; set; }
    }
}
