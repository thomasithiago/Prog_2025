using Modelo;

namespace Aula05.ViewsModels

{
    public class OrderViewModel
    {
        public List<Customer> Customers { get; set; } = [];

        public Customer? CustomerId { get; set; } 

        public List<OrderItem>? SelectedItems { get; set; }
        public List<SelectedItem> Items { get; internal set; }
    }

    public class SelectedItem
    {
        public bool IsSelected { get; set; } = false;
        public OrderItem OrderItem { get; set; } = null;

    }
}
