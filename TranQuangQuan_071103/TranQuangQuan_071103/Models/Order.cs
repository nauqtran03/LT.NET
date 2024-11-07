﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranQuangQuan_071103.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}