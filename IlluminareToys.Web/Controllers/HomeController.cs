using IlluminareToys.Application.ViewModels;
using IlluminareToys.Domain.UseCases.Product;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IlluminareToys.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IGetProductsUseCase getProductsUseCase, CancellationToken cancellationToken)
        {
            var output = await getProductsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
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
