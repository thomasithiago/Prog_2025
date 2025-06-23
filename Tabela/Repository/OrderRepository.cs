
using Modelo; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository 
{
    public class OrderRepository
    {
        public Order GetOrderById(int id)
        {
            return CustomerData.Orders.FirstOrDefault(c => c.Id == id);
        }

        public List<Order> RetrieveByName(string name)
        {
            List<Order> ret = new List<Order>();

            foreach (Order o in CustomerData.Orders)
                if (o.Customer?.Name?.ToLower().Contains(name.ToLower()) == true) 
                    ret.Add(o);

            return ret;
        }

        public List<Order> RetrieveAll()
        {
            return CustomerData.Orders;
        }

        public void AddOrder(Order order)
        {
            order.Id = (CustomerData.Orders.Any() ? CustomerData.Orders.Max(o => o.Id) : 0) + 1;
            CustomerData.Orders.Add(order);

            if (order.CustomerId > 0 && order.Customer == null)
            {

                order.Customer = CustomerData.Customers.FirstOrDefault(c => c.Id == order.CustomerId);
            }

            foreach (var item in order.OrderItems)
            {
                if (item.ProductId > 0 && item.Product == null)
                {
                    item.Product = CustomerData.Products.FirstOrDefault(p => p.Id == item.ProductId);
                }
            }
        }

        public bool Delete(Order order)
        {
            return CustomerData.Orders.Remove(order);
        }

        public bool DeleteById(int id)
        {
            Order order = GetOrderById(id);
            if (order != null)
                return Delete(order);
            return false;
        }

        public void Update(Order newOrder)
        {
            Order oldOrder = GetOrderById(newOrder.Id);
            if (oldOrder != null)
            {
                oldOrder.CustomerId = newOrder.CustomerId; 
                oldOrder.Customer = newOrder.Customer; 
                oldOrder.OrderDate = newOrder.OrderDate;
                oldOrder.ShippingAddress = newOrder.ShippingAddress; 
                oldOrder.TotalAmount = newOrder.TotalAmount;
                oldOrder.OrderItems = newOrder.OrderItems; 
            }
        }

        public int GetCount() => CustomerData.Orders.Count;
    }
}