using iStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using iStore.Infrastructure;

namespace iStore.Pages;

public class CartModel : PageModel
{
    private IStoreRepository _repository;
    public Cart Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";
    public CartModel(IStoreRepository repo, Cart cartService)
    {
        _repository = repo;
        Cart = cartService;
    }

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult OnPost(long productId, string returnUrl)
    {
        Product? product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart.AddItem(product, 1);
        }
        return RedirectToPage(new { returnUrl = returnUrl });
    }

    public IActionResult OnPostRemove(long productId,string returnUrl)
    {
        Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
        return RedirectToPage(new { returnUrl = returnUrl });
    }
}
