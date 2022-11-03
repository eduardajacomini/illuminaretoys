using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public TagsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        // GET: TagsController
        [HttpGet]
        public async Task<ActionResult> Index([FromServices] IGetTagsUseCase listTagsUseCase, CancellationToken cancellationToken)
        {

            var output = await listTagsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        // GET: TagsController/Details/5
        [HttpGet("Details/{id:guid}")]
        public async Task<ActionResult> Details([FromRoute] Guid id, [FromServices] IGetTagByIdUseCase _getTagByIdUseCase, CancellationToken cancellationToken)
        {
            var output = await _getTagByIdUseCase.ExecuteAsync(id, cancellationToken);

            if (output is null)
            {
                _toastNotification.AddErrorToastMessage("Tag não encontrada.");

                return RedirectToAction(nameof(Index));
            }

            return View(output);
        }

        // GET: TagsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Description")] CreateTagInput input,
                                               [FromServices] ICreateTagUseCase createTagUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await createTagUseCase.ExecuteAsync(input, cancellationToken);

            if (output.IsValid)
            {
                output.Errors.AddToModelState(ModelState);
                return View(input);
            }

            _toastNotification.AddSuccessToastMessage("Tag criada com sucesso.");

            return RedirectToAction(nameof(Index));
        }

        // GET: TagsController/Edit/5
        [HttpGet("Edit/{id:guid}")]
        public async Task<ActionResult> Edit([FromRoute] Guid id, [FromServices] IGetTagByIdUseCase getTagByIdUseCase, CancellationToken cancellationToken)
        {
            var output = await getTagByIdUseCase.ExecuteAsync(id, cancellationToken);

            if (output is null)
            {
                _toastNotification.AddErrorToastMessage("Tag não encontrada.");

                return RedirectToAction(nameof(Index));
            }

            return View(output);
        }

        // POST: TagsController/Edit
        [HttpPost("Edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Description")] UpdateTagInput input,
                                             [FromServices] IUpdateTagUseCase updateTagUseCase,
                                             CancellationToken cancellationToken)
        {
            var output = await updateTagUseCase.ExecuteAsync(input, cancellationToken);

            if (output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao atualizar a tag. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Tag atualizada com sucesso.");

            return RedirectToAction(nameof(Index));
        }

        // GET: TagsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
