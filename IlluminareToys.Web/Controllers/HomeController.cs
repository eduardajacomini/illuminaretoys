using IlluminareToys.Application.ViewModels;
using IlluminareToys.Domain.Inputs.Products;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
