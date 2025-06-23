
using System;
using System.Collections.Generic;

namespace Modelo 
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string ShippingAddress { get; set; } 
    }
}