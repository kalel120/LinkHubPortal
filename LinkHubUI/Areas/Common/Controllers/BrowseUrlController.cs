using System;
using System.Linq;
using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.Common.Controllers {
    public class BrowseUrlController : Controller {
        // GET: Common/BrowseUrl
        // Fetch data from Business logic layer to UI
        private readonly UrlBs _objUrls;
        public BrowseUrlController() {
            _objUrls = new UrlBs();
        }

        //Added SortOrder and SortBy Functionalities
        //Added PageNumber functionality 
        public ActionResult Index(string sortOrder, string sortBy, string page) {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            //Filter and collect all approved urls
            var urlList = _objUrls.GetAll().Where(x => x.IsApproved == "P");
            switch(sortBy) {
                case "Title":
                    switch(sortOrder) {
                        case "ASC":
                            urlList = urlList.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "DESC":
                            urlList = urlList.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                    }
                    break;
                case "Url":
                    switch(sortOrder) {
                        case "ASC":
                            urlList = urlList.OrderBy(x => x.Url).ToList();
                            break;
                        case "DESC":
                            urlList = urlList.OrderByDescending(x => x.Url).ToList();
                            break;
                    }
                    break;
                case "Description":
                    switch(sortOrder) {
                        case "ASC":
                            urlList = urlList.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "DESC":
                            urlList = urlList.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                    }
                    break;
                case "Category":
                    switch(sortOrder) {
                        case "ASC":
                            urlList = urlList.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        case "DESC":
                            urlList = urlList.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;
                    }
                    break;
                default:
                    urlList = urlList.OrderBy(x => x.UrlTitle).ToList();
                    break;
            }
            //Send Total number of pages to view
            ViewBag.TotalPages = Math.Ceiling(_objUrls.GetAll().Where(x => x.IsApproved == "A").Count() / 10.0);

            int currentPageNo = int.Parse(page == null ? "1" : page);
            ViewBag.Page = currentPageNo;
            /* Logic for taking only 10 results per page 
             * If pageNumber = 2 then Skip (2-1) = 1 * 10 = 10 Pages 
             * Then Take next 10 pages 
             */
            urlList = urlList.Skip((currentPageNo - 1) * 10).Take(10);
            return View(urlList); 
        }
    }
}