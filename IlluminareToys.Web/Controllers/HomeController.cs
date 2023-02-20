using IlluminareToys.Application.ViewModels;
using IlluminareToys.Domain.UseCases.Age;
using IlluminareToys.Domain.UseCases.Group;
using IlluminareToys.Domain.UseCases.Product;
using IlluminareToys.Domain.UseCases.Tag;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;

namespace IlluminareToys.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> KnowChild([FromServices] IGetGroupsUseCase getGroupsUseCase, CancellationToken cancellationToken)
        {
            var output = await getGroupsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("KnowChildAges/{groupId:guid}")]
        public async Task<IActionResult> KnowChildAges([FromRoute] Guid groupId,
                                                      [FromServices] IGetProductsGroupsAgesByGroupIdUseCase getProductsGroupsAgesByGroupIdUseCase,
                                                      [FromServices] IGetGroupByIdUseCase getGroupByIdUseCase,
                                                      CancellationToken cancellationToken)
        {
            var output = await getProductsGroupsAgesByGroupIdUseCase.ExecuteAsync(groupId, cancellationToken);

            ViewBag.Group = await getGroupByIdUseCase.ExecuteAsync(groupId, cancellationToken);

            return View(output);
        }

        [HttpGet("KnowChildAgesProducts/{groupId}")]
        public async Task<IActionResult> KnowChildAgesProducts([FromRoute] Guid groupId,
                                                               [FromQuery] IEnumerable<Guid> ageIds,
                                                               [FromServices] IGetProductsByGroupIdAgeIdsUseCase getProductsByAgeIdsUseCase,
                                                               [FromServices] IGetGroupByIdUseCase getGroupByIdUseCase,
                                                               [FromServices] IGetProductsGroupsAgesByGroupIdUseCase getProductsGroupsAgesByGroupIdUseCase,
                                                               CancellationToken cancellationToken)
        {
            if (!ageIds.Any())
            {
                var errorOutput = await getProductsGroupsAgesByGroupIdUseCase.ExecuteAsync(groupId, cancellationToken);

                ViewBag.Group = await getGroupByIdUseCase.ExecuteAsync(groupId, cancellationToken);

                _toastNotification.AddErrorToastMessage("Selecione ao menos uma idade!");

                return View(nameof(KnowChildAges), errorOutput);
            }

            var output = await getProductsByAgeIdsUseCase.ExecuteAsync(groupId, ageIds, false, cancellationToken);

            return View(nameof(ProductsBook), output);
        }

        [HttpGet]
        public async Task<IActionResult> DontKnowChild([FromServices] IGetAgesUseCase getAgesUseCase,
                                                       CancellationToken cancellationToken)
        {
            var output = await getAgesUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("DontKnowChildProducts")]
        public async Task<IActionResult> DontKnowChildProducts([FromQuery] IEnumerable<Guid> ageIds,
                                                               [FromServices] IGetAgesUseCase getAgesUseCase,
                                                               [FromServices] IGetProdutsByAgeIdsUseCase getProductsByAgeIdsUseCase,
                                                               CancellationToken cancellationToken)
        {
            if (!ageIds.Any())
            {
                _toastNotification.AddErrorToastMessage("Selecione ao menos um grupo!");

                var errorOutput = await getAgesUseCase.ExecuteAsync(cancellationToken);

                return View(nameof(DontKnowChild), errorOutput);

            }

            var output = await getProductsByAgeIdsUseCase.ExecuteAsync(ageIds, true, cancellationToken);

            return View(nameof(ProductsBook), output);
        }

        [HttpGet]
        public async Task<IActionResult> ByTag([FromServices] IGetTagsUseCase getTagsUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await getTagsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("ByTagProducts")]
        public async Task<IActionResult> ByTagProduts([FromQuery] IEnumerable<Guid> tagIds,
                                                      [FromServices] IGetProductsByTagsUseCase getProductsByTagsUseCase,
                                                      [FromServices] IGetTagsUseCase getTagsUseCase,
                                                      CancellationToken cancellationToken)
        {
            if (!tagIds.Any())
            {
                _toastNotification.AddErrorToastMessage("Selecione ao menos uma tag!");

                var byTagOutput = await getTagsUseCase.ExecuteAsync(cancellationToken);

                return View(nameof(ByTag), byTagOutput);
            }

            var output = await getProductsByTagsUseCase.ExecuteAsync(tagIds, cancellationToken);

            return View(nameof(ProductsBook), output);
        }

        [HttpGet]
        public async Task<IActionResult> Books([FromServices] IGetProductsBooksUseCase getProductsBooksUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await getProductsBooksUseCase.ExecuteAsync(cancellationToken);

            return View(nameof(ProductsBook), output);
        }

        public IActionResult ProductsBook()
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
