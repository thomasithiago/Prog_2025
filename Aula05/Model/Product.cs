using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Product
    {
        public int Id { get; set; }

        public string ? ProductName { get; set; }

        public string? ProductDescription { get; set;

        public string? CurrentPrice { get; set; }


        public bool Validate ()
        {
            return true;
        }

        public Product Retrieve ()
        {
            return new Product();

        }

        public void Save(Product product)
    }
}
