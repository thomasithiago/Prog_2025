using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ClasseOrder
    {
        public int Id { get; set; }

        public Customer ? Customer { get; set; }

        public DateTime ? OrderDate { get; set; }

        public string ? ShippingAddres { get; set; }

        public List<OrderItem> OrderItem { get; set; }


    }
}
