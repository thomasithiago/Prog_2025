
using System.ComponentModel.DataAnnotations;

namespace Aula05.ViewModels 
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; } 

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantity { get; set; }

        public bool IsSelected { get; set; } 

        public decimal TotalItemValue => Price * Quantity; 
    }
}