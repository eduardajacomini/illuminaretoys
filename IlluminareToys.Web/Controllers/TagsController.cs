using IlluminareToys.Application.Extensions;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace IlluminareToys.Web.Controllers
{
    public class TagsController : Controller
    {
        // GET: TagsController
        public async Task<ActionResult> Index([FromServices] IListTagsUseCase listTagsUseCase, CancellationToken cancellationToken)
        {

            var output = await listTagsUseCase.ExecuteAsync(cancellationToken);

            return View(output);
        }

        // GET: TagsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                return View(output);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: TagsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
