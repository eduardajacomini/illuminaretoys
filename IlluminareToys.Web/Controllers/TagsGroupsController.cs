using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.UseCases.Tag;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    [Route("[controller]")]
    public class TagsGroupsController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public TagsGroupsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTagsGroupsInput input,
                                               [FromServices] ICreateTagsGroupsUseCase createTagsGroupsUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await createTagsGroupsUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Solicitação criada com sucesso.");

            return Ok();
        }
    }
}
