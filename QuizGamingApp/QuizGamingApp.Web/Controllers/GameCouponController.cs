using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuizGamingApp.Core.BLL;
using QuizGamingApp.Core.EnitityModel;
using QuizGamingApp.Web.Models;

namespace QuizGamingApp.Web.Controllers
{
    public class GameCouponController : Controller
    {
        private GameCouponManager _gameCouponManager;
        public GameCouponController()
        {
            _gameCouponManager = new GameCouponManager();
        }
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var items = await _gameCouponManager.IndexAsync();
            return View(items);
        }

        [ActionName("Create")]
        public async Task<ActionResult> Create()
        {
            return View(new GameCoupon());
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GameCoupon gameCoupon)
        {
            if (ModelState.IsValid)
            {
                await _gameCouponManager.CreateAsync(gameCoupon);
                return RedirectToAction("Index");
            }

            return View(new GameCoupon());
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GameCoupon gameCoupon)
        {
            if (ModelState.IsValid)
            {
                await _gameCouponManager.EditAsync(gameCoupon);
                return RedirectToAction("Index");
            }

            return View(new GameCoupon());
        }

        [ActionName("Edit")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GameCoupon gameCoupon = await _gameCouponManager.GetItemAsync(id);
            if (gameCoupon == null)
            {
                return HttpNotFound();
            }

            return View(gameCoupon);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GameCoupon gameCoupon = await _gameCouponManager.GetItemAsync(id);
            if (gameCoupon == null)
            {
                return HttpNotFound();
            }

            return View(gameCoupon);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _gameCouponManager.DeleteConfirmedAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> Details(string id)
        {
            GameCoupon gameCoupon = await _gameCouponManager.GetItemAsync(id);
            return View(gameCoupon);
        }
    }
}
