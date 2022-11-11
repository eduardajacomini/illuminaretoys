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

        [HttpGet("Details/{id:guid}")]
        public async Task<ActionResult> Details([FromRoute] Guid id, [FromServices] IGetProductByIdUseCase _getProductByIdUseCase, CancellationToken cancellationToken)
        {
            var output = await _getProductByIdUseCase.ExecuteAsync(id, cancellationToken);

            if (output is null)
            {
                _toastNotification.AddErrorToastMessage("Produto não encontrado.");

                return RedirectToAction(nameof(Index));
            }

            return View(output);
        }

        [HttpGet("AssociateTags/{productId:guid}")]
        public async Task<ActionResult> AssociateTags([FromRoute] Guid productId,
                                                     [FromServices] IAssociateTagUseCase associateTagUseCase,
                                                     CancellationToken cancellationToken)
        {
            var output = await associateTagUseCase.ExecuteAsync(productId, cancellationToken);

            return View(output);
        }
    }
}
