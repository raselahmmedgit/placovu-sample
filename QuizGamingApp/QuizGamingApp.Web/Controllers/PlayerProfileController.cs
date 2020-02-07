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
    public class PlayerProfileController : Controller
    {
        private PlayerProfileManager _playerProfileManager;
        public PlayerProfileController()
        {
            _playerProfileManager = new PlayerProfileManager();
        }
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var items = await _playerProfileManager.IndexAsync();
            return View(items);
        }

        [ActionName("Create")]
        public async Task<ActionResult> Create()
        {
            return View(new PlayerProfile());
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlayerProfile playerProfile)
        {
            if (ModelState.IsValid)
            {
                await _playerProfileManager.CreateAsync(playerProfile);
                return RedirectToAction("Index");
            }

            return View(new PlayerProfile());
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PlayerProfile playerProfile)
        {
            if (ModelState.IsValid)
            {
                await _playerProfileManager.EditAsync(playerProfile);
                return RedirectToAction("Index");
            }

            return View(new PlayerProfile());
        }

        [ActionName("Edit")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlayerProfile PlayerProfile = await _playerProfileManager.GetItemAsync(id);
            if (PlayerProfile == null)
            {
                return HttpNotFound();
            }

            return View(PlayerProfile);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlayerProfile playerProfile = await _playerProfileManager.GetItemAsync(id);
            if (playerProfile == null)
            {
                return HttpNotFound();
            }

            return View(playerProfile);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _playerProfileManager.DeleteConfirmedAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> Details(string id)
        {
            PlayerProfile PlayerProfile = await _playerProfileManager.GetItemAsync(id);
            return View(PlayerProfile);
        }
    }
}