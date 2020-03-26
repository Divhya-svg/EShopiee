using System;
using System.Collections.Generic;
using System.Text;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVV { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfPayment { get; set; }

    }
}
