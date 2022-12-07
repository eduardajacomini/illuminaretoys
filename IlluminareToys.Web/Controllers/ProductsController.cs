﻿using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.UseCases;
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
    }
}
