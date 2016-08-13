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
        public ActionResult Index(string sortOrder, string sortBy) {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            //Filter and collect all approved urls
            var urlList = _objUrls.GetAll().Where(x => x.IsApproved == "A");
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
            return View(urlList);
        }
    }
}