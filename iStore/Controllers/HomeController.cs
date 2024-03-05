using iStore.Models;
using iStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace iStore.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;

        private readonly IStoreRepository _repository;

        public HomeController(IStoreRepository repository)
        {
            _repository = repository;
        }

        [Route("/")]
        [Route("Products/Page{productPage:int}")]
        public IActionResult Index(int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = _repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
