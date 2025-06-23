using System.Collections.Generic;

namespace SeuProjeto.ViewModels
{
    public class PedidoViewModel
    {
        public required string ClienteSelecionado { get; set; }
        public List<string> Clientes { get; set; } = new();
        public List<OrderItemViewModel> Produtos { get; set; } = new();
    }
}
