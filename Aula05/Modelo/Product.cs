﻿namespace Modelo
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double CurrentPrice { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            isValid = 
                !string.IsNullOrEmpty(this.Name) && 
                (this.Id > 0) && 
                (this.CurrentPrice > 0);
            
            return isValid;
        }

        public Product Retrieve()
        {
            return new Product();
        }

        public void Save(Product product)
        {
        }
    }
}
