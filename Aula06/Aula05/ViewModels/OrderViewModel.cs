using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo;
using SeuProjeto.ViewModels;

namespace Aula05.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Selecione um cliente.")]
        public int SelectedCustomerId { get; set; }

        
        public IEnumerable<SelectListItem> Clientes { get; set; } = [];

     
        public List<Customer> Customers { get; set; } = [];

        
        public List<SelectedItem> SelectedItems { get; set; } = [];
    }

    public class SelectedItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe uma quantidade válida")]
        public int Quantity { get; set; }

        public bool Selected { get; set; }
        public OrderItemViewModel OrderItem { get; internal set; }
    }
}
