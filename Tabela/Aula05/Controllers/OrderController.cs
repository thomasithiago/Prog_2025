
using Aula05.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula05.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;

        public OrderController(
            CustomerRepository customerRepository,
            ProductRepository productRepository,
            OrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        private void PopulateViewModelDropdowns(OrderPlacementViewModel viewModel)
        {
            var currentSelectedCustomerId = viewModel.SelectedCustomerId;

            viewModel.Customers = _customerRepository.GetAllCustomers()
                                                     .Select(c => new SelectListItem
                                                     {
                                                         Value = c.Id.ToString(),
                                                         Text = c.Name,
                                                         Selected = c.Id == currentSelectedCustomerId
                                                     }).ToList();

            viewModel.AvailableProducts = _productRepository.GetAllProducts()
                                                            .Select(p => new SelectListItem
                                                            {
                                                                Value = p.Id.ToString(),
                                                                Text = $"{p.Name} (R$ {p.CurrentPrice:F2})"
                                                            }).ToList();
        }

        public IActionResult PlaceOrder()
        {
            var viewModel = new OrderPlacementViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                ShippingAddress = string.Empty
            };
            PopulateViewModelDropdowns(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(OrderPlacementViewModel viewModel, string action)
        {
            PopulateViewModelDropdowns(viewModel);

            if (action == "AddItem")
            {
                if (viewModel.SelectedProductIdToAdd.HasValue && viewModel.SelectedProductIdToAdd.Value > 0)
                {
                    var productToAdd = _productRepository.GetProductById(viewModel.SelectedProductIdToAdd.Value);
                    if (productToAdd != null)
                    {
                        var existingItem = viewModel.OrderItems.FirstOrDefault(oi => oi.ProductId == productToAdd.Id);
                        if (existingItem != null)
                        {
                            existingItem.Quantity++;
                        }
                        else
                        {
                            viewModel.OrderItems.Add(new OrderItemViewModel
                            {
                                ProductId = productToAdd.Id,
                                ProductName = productToAdd.Name,
                                Price = productToAdd.CurrentPrice,
                                Quantity = 1
                            });
                        }
                    }
                    viewModel.SelectedProductIdToAdd = null;
                }
            }
            else if (action.StartsWith("RemoveItem_"))
            {
                if (int.TryParse(action.Replace("RemoveItem_", ""), out int itemIndexToRemove))
                {
                    if (itemIndexToRemove >= 0 && itemIndexToRemove < viewModel.OrderItems.Count)
                    {
                        viewModel.OrderItems.RemoveAt(itemIndexToRemove);
                    }
                }
            }

            viewModel.TotalOrderValue = viewModel.OrderItems.Sum(item => item.Quantity * item.Price);

            if (action == "SaveOrder")
            {
                if (!viewModel.OrderItems.Any())
                {
                    ModelState.AddModelError("", "O pedido deve conter pelo menos um item.");
                    PopulateViewModelDropdowns(viewModel);
                    return View(viewModel);
                }

                if (ModelState.IsValid)
                {
                    var order = new Order
                    {
                        CustomerId = viewModel.SelectedCustomerId,
                        OrderDate = DateTime.Now,
                        TotalAmount = viewModel.TotalOrderValue,
                        ShippingAddress = viewModel.ShippingAddress,
                        OrderItems = viewModel.OrderItems.Select(itemVm => new OrderItem
                        {
                            ProductId = itemVm.ProductId,
                            Quantity = itemVm.Quantity,
                            UnitPrice = itemVm.Price
                        }).ToList()
                    };

                    _orderRepository.AddOrder(order);

                    TempData["SuccessMessage"] = "Pedido realizado com sucesso!";
                    return RedirectToAction("OrderConfirmation", new { id = order.Id });
                }
            }

            return View(viewModel);
        }

        public IActionResult OrderConfirmation(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            order.Customer = _customerRepository.GetCustomerById(order.CustomerId);
            foreach (var item in order.OrderItems)
            {
                item.Product = _productRepository.GetProductById(item.ProductId);
            }

            return View(order);
        }
    }
}