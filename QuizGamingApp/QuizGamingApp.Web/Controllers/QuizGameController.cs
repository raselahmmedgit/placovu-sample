using QuizGamingApp.Core.BLL;
using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuizGamingApp.Web.Controllers
{
    public class QuizGameController : Controller
    {
        private QuizGameManager _quizGameManager;
        public QuizGameController()
        {
            _quizGameManager = new QuizGameManager();
        }
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var items = await _quizGameManager.IndexAsync();
            return View(items);
        }

        [ActionName("Create")]
        public async Task<ActionResult> Create()
        {
            return View(new QuizGame());
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuizGame quizGame)
        {
            if (ModelState.IsValid)
            {
                await _quizGameManager.CreateAsync(quizGame);
                return RedirectToAction("Index");
            }

            return View(new QuizGame());
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuizGame quizGame)
        {
            if (ModelState.IsValid)
            {
                await _quizGameManager.EditAsync(quizGame);
                return RedirectToAction("Index");
            }

            return View(new QuizGame());
        }

        [ActionName("Edit")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuizGame quizGame = await _quizGameManager.GetItemAsync(id);
            if (quizGame == null)
            {
                return HttpNotFound();
            }

            return View(quizGame);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuizGame quizGame = await _quizGameManager.GetItemAsync(id);
            if (quizGame == null)
            {
                return HttpNotFound();
            }

            return View(quizGame);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _quizGameManager.DeleteConfirmedAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> Details(string id)
        {
            QuizGame quizGame = await _quizGameManager.GetItemAsync(id);
            return View(quizGame);
        }
    }
}