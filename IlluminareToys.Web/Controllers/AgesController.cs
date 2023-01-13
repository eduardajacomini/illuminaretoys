using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Enums;
using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Shared.Extensions;
using IlluminareToys.Domain.UseCases.Age;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    [Route("[controller]")]
    public class AgesController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public AgesController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<ActionResult> Index([FromServices] IGetAgesUseCase getAgesUseCase, CancellationToken cancellationToken)
        {

            var output = await getAgesUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            var ageTypes = new List<SelectListItem>
            {
                new SelectListItem("ANOS", AgeType.YEARS.ToInt().ToString()),
                new SelectListItem("MESES", AgeType.MONTHS.ToInt().ToString())
            };

            ViewBag.AgeTypes = ageTypes;

            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Quantity, Type")] CreateAgeInput input,
                                               [FromServices] ICreateAgeUseCase createAgeUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await createAgeUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Idade criada com sucesso.");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Delete/{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id,
                                               [FromServices] IDeleteAgeUseCase deleteTagUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await deleteTagUseCase.ExecuteAsync(id, cancellationToken);

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao excluir a idade. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Idade removida com sucesso.");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:guid}")]
        public async Task<ActionResult> Edit([FromRoute] Guid id,
                                             [FromServices] IGetAgeByIdUseCase getAgeByIdUseCase,
                                             CancellationToken cancellationToken)
        {
            var output = await getAgeByIdUseCase.ExecuteAsync(id, cancellationToken);

            if (output is null)
            {
                _toastNotification.AddErrorToastMessage("Idade não encontrada.");

                return RedirectToAction(nameof(Index));
            }

            var ageTypes = new List<SelectListItem>
            {
                new SelectListItem("ANOS", AgeType.YEARS.ToInt().ToString()),
                new SelectListItem("MESES", AgeType.MONTHS.ToInt().ToString())
            };

            ViewBag.AgeTypes = ageTypes;

            return View(output);
        }

        [HttpPost("Edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Quantity,Type")] UpdateAgeInput input,
                                             [FromServices] IUpdateAgeUseCase updateAgeUseCase,
                                             CancellationToken cancellationToken)
        {
            var output = await updateAgeUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao atualizar a idade. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Idade atualizada com sucesso.");

            return RedirectToAction(nameof(Index));
        }
    }
}
