using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSample.Core.Settings;
using TestSample.Domain.Entities;
using TestSample.Persistance.Interface;
using TestSample.Web.Helpers;

namespace TestSample.Web.Controllers
{
    public class InsurersController : Controller
    {
        #region Private variables and constructors
        IInsurerDao _insurerDao;
        public InsurersController(IInsurerDao insurerDao)
        {
            _insurerDao = insurerDao;
        }
        #endregion

        #region Manage

        [HttpGet]
        public ActionResult Index()
        {
            var referrers = _insurerDao.GetAll(null, null, 1, AppSettings.PageListLength);

            ViewBag.PageNum = 1;

            return View(referrers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Search, bool? IsActive = null, int PageNum = 1)
        {
            var referrers = _insurerDao.GetAll(IsActive, Search, PageNum, AppSettings.PageListLength);

            ViewBag.PageNum = PageNum;

            ViewBag.IsActive = IsActive;

            ViewBag.Search = Search;

            return View(referrers);
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Insurer I)
        {
            if (I?.Id > 0)
            {
                _insurerDao.Delete(I.Id, 1);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Insurer I)
        {
            if (ValidateAndSaveInsurer(I, ModelState))
            {
                return RedirectToAction("Index");
            }

            return View(viewName: "Add", I);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Id > 0)
            {
                var insurer = _insurerDao.Get(Id);

                if (insurer != null)
                {
                    return View(viewName: "Add", insurer);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Insurer I)
        {
            if (ValidateAndSaveInsurer(I, ModelState))
            {
                return RedirectToAction("Index");
            }

            return View(viewName: "Add", I);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CheckName(string Name, int Id = 0)
        {
            return Json((_insurerDao.GetByName(Name, Id)?.Count() == 0), JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CheckInternalCode(string InternalCode, int Id = 0)
        {
            return Json((_insurerDao.GetByInternalCode(InternalCode, Id)?.Count() == 0), JsonRequestBehavior.DenyGet);
        }

        public ActionResult Details(int Id = 0)
        {
            if (Id > 0)
            {
                var insurer = _insurerDao.Get(Id);

                if (insurer != null)
                {
                    return View(insurer);
                }
            }
            return RedirectToAction("Index");
        }

        #region Private Methods
        private bool ValidateAndSaveInsurer(Insurer I, ModelStateDictionary MSD)
        {
            bool result = false;

            if (I != null)
            {
                if (I.IsValidToSave(MSD))
                {
                    //I.SystemIp = GetRemoteIp.GetIPAddress(HttpContext);

                    result = _insurerDao.Save(I, 1) > 0;
                }
            }
            return result;
        }

        #endregion
    }
}