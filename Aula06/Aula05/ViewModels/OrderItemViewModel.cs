using Modelo;

namespace SeuProjeto.ViewModels
{
    public class OrderItemViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Selecionado { get; set; }
        public int Quantidade { get; set; }
        public Product Product { get; internal set; }
        public int Quantity { get; internal set; }
        public bool Selected { get; internal set; }
    }
}
