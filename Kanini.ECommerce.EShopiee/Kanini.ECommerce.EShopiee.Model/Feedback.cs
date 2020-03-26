using System;
using System.Collections.Generic;
using System.Text;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class Feedback
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string FeedBack { get; set; }
        public decimal Rating { get; set; }

    }
}
