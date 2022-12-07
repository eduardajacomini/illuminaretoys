using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.UseCases.Group;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public GroupsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<ActionResult> Index([FromServices] IGetGroupsUseCase getGroupsUseCase, CancellationToken cancellationToken)
        {

            var output = await getGroupsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Description, Age")] CreateGroupInput input,
                                               [FromServices] ICreateGroupUseCase createGroupUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await createGroupUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Grupo criado com sucesso.");

            return RedirectToAction(nameof(Index));
        }
    }
}
