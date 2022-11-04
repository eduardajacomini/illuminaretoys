﻿using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace IlluminareToys.Web.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("Create")]
        // GET: TagsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsController/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Description")] CreateTagInput input,
                                               [FromServices] ICreateTagUseCase createTagUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await createTagUseCase.ExecuteAsync(input, cancellationToken);

            if (!output.IsValid)
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

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao atualizar a tag. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Tag atualizada com sucesso.");

            return RedirectToAction(nameof(Index));
        }

        // POST: TagsController/Delete/5
        [HttpPost("Delete/{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id,
                                               [FromServices] IDeleteTagUseCase deleteTagUseCase,
                                               CancellationToken cancellationToken)
        {
            var output = await deleteTagUseCase.ExecuteAsync(new DeleteTagInput(id), cancellationToken);

            if (!output.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Erro ao excluir a tag. Informe os campos corretamente.");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage("Tag removida com sucesso.");

            return RedirectToAction(nameof(Index));
        }
    }
}