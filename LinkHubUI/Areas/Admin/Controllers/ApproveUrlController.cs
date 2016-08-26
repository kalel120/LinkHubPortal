using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class ApproveUrlController : _BaseAdminController {
        public ActionResult Index(string status) {
            ViewBag.status = status == null ? "P" : status;
            if(status == null) {
                var urls = objBs.UrlBusiness.GetAll().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else {
                var urls = objBs.UrlBusiness.GetAll().Where(x => x.IsApproved == status).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(int id) {
            try {
                var myUrl = objBs.UrlBusiness.GetUrlById(id);
                myUrl.IsApproved = "A";
                objBs.UrlBusiness.Update(myUrl);
                TempData["Msg"] = "Approved Succesfully ";
                return RedirectToAction("Index");

            }
            //SPECIAL CODE FOR FINDING ENTITY FRAMWORK VALIDATION ERROR.
            catch(DbEntityValidationException entityException) {
                foreach(var validationErrors in entityException.EntityValidationErrors) {
                    foreach(var validationError in validationErrors.ValidationErrors) {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reject(int id) {
            try {
                var myUrl = objBs.UrlBusiness.GetUrlById(id);
                myUrl.IsApproved = "R";
                objBs.UrlBusiness.Update(myUrl);
                TempData["Msg"] = "Rejected Succesfully";
                return RedirectToAction("Index");
            }
            catch(Exception exception) {
                TempData["Msg"] = "Failed " + exception;
                return RedirectToAction("Index");
            }
        }
    }
}