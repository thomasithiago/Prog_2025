using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class OrderItem
    {
        public int Id { get; set; } 
        public Product Product { get; set; }

        public double Price { get; set; }

        public double PruchasePrice { get; set; }
    }
     public bool Validate()
        {
            return true;
        }

        public OrderItem Retrieve()
        {
            return new OrderItem();
        }

        public void Save(OrderItem corderItem)
        {

        }
    }
}

