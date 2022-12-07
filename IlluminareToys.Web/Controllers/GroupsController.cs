using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs.Groups;
using IlluminareToys.Domain.UseCases.Group;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    [Route("[controller]")]
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
        public async Task<ActionResult> Create([Bind("Description, Name")] CreateGroupInput input,
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

        [HttpPost("Delete/{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id,
                                               [FromServices] IDeleteGroupUseCase deleteTagUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await deleteTagUseCase.ExecuteAsync(id, cancellationToken);

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao excluir o grupo. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Grupo removida com sucesso.");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:guid}")]
        public async Task<ActionResult> Edit([FromRoute] Guid id,
                                             [FromServices] IGetGroupByIdUseCase getGroupByIdUseCase,
                                             CancellationToken cancellationToken)
        {
            var output = await getGroupByIdUseCase.ExecuteAsync(id, cancellationToken);

            if (output is null)
            {
                _toastNotification.AddErrorToastMessage("Grupo não encontrado.");

                return RedirectToAction(nameof(Index));
            }

            return View(output);
        }

        [HttpPost("Edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Description, Name")] UpdateGroupInput input,
                                             [FromServices] IUpdateGroupUseCase updateTagUseCase,
                                             CancellationToken cancellationToken)
        {
            var output = await updateTagUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao atualizar o grupo. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Grupo atualizado com sucesso.");

            return RedirectToAction(nameof(Index));
        }
    }
}
