using IlluminareToys.Application.ViewModels;
using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.UseCases.Group;
using IlluminareToys.Domain.UseCases.Product;
using IlluminareToys.Domain.UseCases.Tag;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IlluminareToys.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IGetProductsByTagsUseCase getProductsByTagsUseCase,
                                               [FromServices] IGetTagsUseCase getTagsUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await getProductsByTagsUseCase.ExecuteAsync(new(), cancellationToken);
            var tags = await getTagsUseCase.ExecuteAsync(cancellationToken);

            ViewBag.Tags = tags;

            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Tags")] GetProductsByTagsInput input,
                                               [FromServices] IGetProductsByTagsUseCase getProductsByTagsUseCase,
                                               [FromServices] IGetTagsUseCase getTagsUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await getProductsByTagsUseCase.ExecuteAsync(input, cancellationToken);

            var tags = await getTagsUseCase.ExecuteAsync(cancellationToken);

            ViewBag.Tags = tags;
            ViewBag.SelectedTags = input.Tags;

            return View(output);
        }

        [HttpGet]
        public async Task<IActionResult> KnowChild([FromServices] IGetGroupsUseCase getGroupsUseCase, CancellationToken cancellationToken)
        {
            var output = await getGroupsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("KnowChildAges/{groupId:guid}")]
        public async Task<IActionResult> KnowChildAges([FromRoute] Guid groupId,
                                                      [FromServices] IGetTagsGroupsByGroupIdUseCase getTagsGroupsByGroupIdUseCase,
                                                      [FromServices] IGetGroupByIdUseCase getGroupByIdUseCase,
                                                      CancellationToken cancellationToken)
        {
            var output = await getTagsGroupsByGroupIdUseCase.ExecuteAsync(groupId, cancellationToken);

            ViewBag.Group = await getGroupByIdUseCase.ExecuteAsync(groupId, cancellationToken);

            return View(output.DistinctBy(x => x.Age));
        }

        [HttpGet("KnowChildAgesProducts/{groupId:guid}/{age}")]
        public async Task<IActionResult> KnowChildAgesProducts([FromRoute] Guid groupId,
                                                               [FromRoute] string age,
                                                               [FromServices] IGetProductsByGroupIdUseCase getProductsByGroupIdUseCase,
                                                               CancellationToken cancellationToken)
        {
            var output = await getProductsByGroupIdUseCase.ExecuteAsync(groupId, age, cancellationToken);

            return View(nameof(ProductsBook), output);
        }

        [HttpGet]
        public async Task<IActionResult> DontKnowChild([FromServices] IGetProductCategoriesUseCase getProductCategoriesUseCase,
                                                       CancellationToken cancellationToken)
        {
            var output = await getProductCategoriesUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("DontKnowChildCategoryProducts/{category}")]
        public async Task<IActionResult> DontKnowChildCategoryProducts([FromRoute] string category,
                                                                       [FromServices] IGetProductsByCategoryUseCase getProductsByCategoryUseCase,
                                                                       CancellationToken cancellationToken)
        {
            var output = await getProductsByCategoryUseCase.ExecuteAsync(category, cancellationToken);

            return View(nameof(ProductsBook), output);
        }

        [HttpGet]
        public IActionResult ByTag()
        {
            return View();
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
