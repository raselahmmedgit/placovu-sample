using QuizGamingApp.Core.BLL;
using QuizGamingApp.Core.DAL;
using QuizGamingApp.Core.EnitityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace QuizGamingApp.Web.Controllers
{
    public class ClientProfileController : Controller
    {
        private ClientProfileManager _clientProfileManager;
        public ClientProfileController()
        {
            _clientProfileManager = new ClientProfileManager();
        }
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var items = await _clientProfileManager.IndexAsync();
            return View(items);
        }

        [ActionName("Create")]
        public async Task<ActionResult> Create()
        {
            return View(new ClientProfile());
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( ClientProfile clientProfile)
        {
            if (ModelState.IsValid)
            {
                await _clientProfileManager.CreateAsync(clientProfile);
                return RedirectToAction("Index");
            }

            return View(new ClientProfile());
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClientProfile clientProfile)
        {
            if (ModelState.IsValid)
            {
                await _clientProfileManager.EditAsync(clientProfile);
                return RedirectToAction("Index");
            }

            return View(new ClientProfile());
        }

        [ActionName("Edit")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClientProfile clientProfile = await _clientProfileManager.GetItemAsync(id);
            if (clientProfile == null)
            {
                return HttpNotFound();
            }

            return View(clientProfile);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClientProfile clientProfile = await _clientProfileManager.GetItemAsync(id);
            if (clientProfile == null)
            {
                return HttpNotFound();
            }

            return View(clientProfile);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _clientProfileManager.DeleteConfirmedAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> Details(string id)
        {
            ClientProfile clientProfile = await _clientProfileManager.GetItemAsync(id);
            return View(clientProfile);
        }
    }
}