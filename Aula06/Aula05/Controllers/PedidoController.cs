using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;
using System;
using System.Collections.Generic;

namespace SeuProjeto.Controllers
{
    public class PedidoController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PedidoViewModel
            {
                Clientes = new List<string> { "João", "Maria", "Pedro" },
                ClienteSelecionado = "", 
                Produtos = new List<OrderItemViewModel>
                {
                    new OrderItemViewModel { Nome = "Produto 1", Valor = 10 },
                    new OrderItemViewModel { Nome = "Produto 2", Valor = 20 },
                    new OrderItemViewModel { Nome = "Produto 3", Valor = 30 },
                    new OrderItemViewModel { Nome = "Produto 4", Valor = 40 },
                    new OrderItemViewModel { Nome = "Produto 5", Valor = 50 },
                }
            };

            return View(model);
        }

        
        [HttpPost]
        public IActionResult Create(PedidoViewModel model)
        {
            if (!ModelState.IsValid)
            {
             
                model.Clientes = new List<string> { "João", "Maria", "Pedro" };
                return View(model);
            }

            
            return RedirectToAction("Index");
        }
    }
}
