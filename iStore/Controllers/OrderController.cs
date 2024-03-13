using iStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace iStore.Controllers;

public class OrderController : Controller
{
    private IOrderRepository _repository;
    private Cart cart;

    public OrderController(IOrderRepository repository, Cart cart)
    {
        _repository = repository;
        this.cart = cart;
    }

    public IActionResult Checkout()
    {
        return View(new Order());
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (cart.Lines.Count() == 0)
        {
            ModelState.AddModelError("", "Sorry, your cart is empty!");
        }
        if (ModelState.IsValid)
        {
            order.Lines = cart.Lines.ToArray();
            _repository.SaveOrder(order);
            cart.Clear();
            return RedirectToPage("/Completed", new { orderId = order.OrderID });
        }
        else
        {
            return View();
        }
    }
}