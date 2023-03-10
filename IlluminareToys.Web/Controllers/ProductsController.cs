using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.UseCases;
using IlluminareToys.Domain.UseCases.Age;
using IlluminareToys.Domain.UseCases.Product;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    [Route("[controller]")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class ProductsController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public ProductsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<ActionResult> Index([FromQuery] int? page,
                                              [FromQuery] string searchTerm,
                                              [FromServices] IGetProductsUseCase getProductsUseCase,
                                              CancellationToken cancellationToken)
        {

            TempData["page"] = page ?? 1;
            TempData["searchTerm"] = searchTerm;

            var output = await getProductsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("Details/{id:guid}")]
        public async Task<ActionResult> Details([FromRoute] Guid id,
                                                [FromQuery] int? page,
                                                [FromQuery] string searchTerm,
                                                [FromServices] IGetProductByIdUseCase _getProductByIdUseCase,
                                                CancellationToken cancellationToken)
        {
            TempData["page"] = page ?? 1;
            TempData["searchTerm"] = searchTerm;

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
                                                      [FromQuery] int? page,
                                                      [FromQuery] string searchTerm,
                                                      [FromServices] IAssociateTagUseCase associateTagUseCase,
                                                      CancellationToken cancellationToken)
        {
            TempData["page"] = page ?? 1;
            TempData["searchTerm"] = searchTerm;

            var output = await associateTagUseCase.ExecuteAsync(productId, cancellationToken);

            return View(output);
        }

        [HttpPost("AssociateTags")]
        public async Task<ActionResult> AssociateTags([FromBody] AssociateTagsToProductInput input,
                                                      [FromServices] IAssociateTagsToProductUseCase associateTagUseCase,
                                                      CancellationToken cancellationToken)
        {
            var output = await associateTagUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Tags associadas com sucesso.");

            return Ok();
        }

        [HttpGet("SyncProductsBling")]
        public async Task<ActionResult> SyncProductsBling([FromServices] ISyncProductsUseCase syncProductsUseCase, CancellationToken cancellationToken)
        {
            await syncProductsUseCase.ExecuteAsync(cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Image/{productId:guid}")]
        public async Task<ActionResult> AddImage([FromRoute] Guid productId,
                                                 [FromForm] IFormFile file,
                                                 [FromServices] IAddImageProductUseCase addImageProductUseCase,
                                                 CancellationToken cancellationToken)
        {
            var output = await addImageProductUseCase.ExecuteAsync(new(file, productId), cancellationToken);

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro adicionar a imagem. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index), new
                {
                    id = productId
                });
            }

            _toastNotification.AddSuccessToastMessage("Imagem adicionada com sucesso.");

            return RedirectToAction(nameof(Index), new
            {
                id = productId
            });
        }

        [HttpGet("AssociateAges/{productId:guid}")]
        public async Task<IActionResult> AssociateAges([FromRoute] Guid productId,
                                                       [FromQuery] int? page,
                                                       [FromQuery] string searchTerm,
                                                       [FromServices] IAssociateAgesUseCase associateAgesUseCase,
                                                       [FromServices] IGetProductsAgesByProductIdUseCase getProductsAgesByProductIdUseCase,
                                                       CancellationToken cancellationToken)
        {
            TempData["page"] = page ?? 1;
            TempData["searchTerm"] = searchTerm;

            var output = await associateAgesUseCase.ExecuteAsync(productId, cancellationToken);

            ViewBag.SelectedAges = await getProductsAgesByProductIdUseCase.ExecuteAsync(productId, cancellationToken);

            return View(output);
        }

        [HttpPost("AssociateAges")]
        public async Task<ActionResult> AssociateAges([FromBody] AssociateAgesToProductInput input,
                                                      [FromServices] IAssociateAgesToProductUseCase useCase,
                                                      CancellationToken cancellationToken)
        {
            var output = await useCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Idades associadas com sucesso.");

            return Ok();
        }

        [HttpGet("AssociateGroups/{productId:guid}")]
        public async Task<ActionResult> AssociateGroups([FromRoute] Guid productId,
                                                        [FromQuery] int? page,
                                                        [FromQuery] string searchTerm,
                                                        [FromServices] IAssociateGroupsUseCase associateGroupsUseCase,
                                                        [FromServices] IGetAgesUseCase getAgesUseCase,
                                                        CancellationToken cancellationToken)
        {
            TempData["page"] = page ?? 1;
            TempData["searchTerm"] = searchTerm;

            var output = await associateGroupsUseCase.ExecuteAsync(productId, cancellationToken);

            ViewBag.Ages = await getAgesUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpPost("AssociateGroups")]
        public async Task<ActionResult> AssociateGroups([FromBody] AssociateGroupsToProductInput input,
                                                        [FromServices] IAssociateGroupsToProductUseCase associateGroupsToProductUseCase,
                                                        CancellationToken cancellationToken)
        {
            var output = await associateGroupsToProductUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Grupos associados com sucesso.");

            return Ok();
        }
    }
}
