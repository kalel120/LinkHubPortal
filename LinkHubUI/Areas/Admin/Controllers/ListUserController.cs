//Fetch data from BLL to UI
using System;
using System.Linq;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class ListUserController : _BaseAdminController {
        public ActionResult Index(string sortOrder, string sortBy, string page) {
            //Store sortOrder and sortBy into viewbag
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;

            var userList = objBs.UserBusiness.GetAllUser();
            //Send total number of pages to the view
            ViewBag.TotalPages = Math.Ceiling(userList.Count() / 10.00);
            switch(sortBy) {
                case "UserEmail":
                    switch (sortOrder) {
                        case "ASC":
                            userList = userList.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "DESC":
                            userList = userList.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                    }
                    break;
                case "UserRole":
                    switch (sortOrder) {
                        case "ASC":
                            userList = userList.OrderBy(x => x.Role).ToList();
                            break;
                        case "DESC":
                            userList = userList.OrderByDescending(x => x.Role).ToList();
                            break;
                    }
                    break;
                default:
                    userList = userList.OrderBy(x => x.UserEmail).ToList();
                    break;
            }
            
            //Sends current pages number to the view
            int currentPageNo = int.Parse(page ?? "1");
            ViewBag.CurrentPage = currentPageNo;

            //For skipping n number of pages for pagination
            userList = userList.Skip((currentPageNo - 1)*10).Take(10);
            return View(userList);
        }
    }
}