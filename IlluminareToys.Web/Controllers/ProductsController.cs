using IlluminareToys.Domain.UseCases.Product;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public ProductsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<ActionResult> Index([FromServices] IGetProductsUseCase getProductsUseCase, CancellationToken cancellationToken)
        {

            var output = await getProductsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }
    }
}
