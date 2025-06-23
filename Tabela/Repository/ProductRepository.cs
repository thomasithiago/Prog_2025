

using Modelo; 
using System.Collections.Generic;
using System.Linq;

namespace Repository 
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts()
        {
            return CustomerData.Products;
        }

        public Product GetProductById(int id)
        {
            return CustomerData.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.Id = (CustomerData.Products.Any() ? CustomerData.Products.Max(p => p.Id) : 0) + 1;
            CustomerData.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.CurrentPrice = product.CurrentPrice;
            }
        }

        public void DeleteProduct(int id)
        {
            var productToRemove = GetProductById(id);
            if (productToRemove != null)
            {
                CustomerData.Products.Remove(productToRemove);
            }
        }
    }
}