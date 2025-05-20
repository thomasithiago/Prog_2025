using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            isValid =
                (Product != null) &&
                (Id > 0) &&
                (Quantity > 0); &&
                (PurchasePrice > 0);

            return isValid;

        }

        public OrderItem Retrieve(int orderId)
        {
            return new OrderItem();
        }

        public void Save(OrderItem orderItem)
        {

        }
    }
}