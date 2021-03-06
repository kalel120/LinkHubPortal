﻿using System;
using System.Linq;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class ListCategoryController : _BaseAdminController {
       // GET: Admin/ListCategory
        public ActionResult Index(string sortOrder, string sortBy, string page) {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;

            var categoryList = objBs.CategoryBusiness.GetAllCategories();
            //Send total number of pages to the view           
            ViewBag.TotalPages = Math.Ceiling(categoryList.Count() / 10.00);

            switch(sortBy) {
                case "CategoryName":
                    switch(sortOrder) {
                        case "ASC":
                            categoryList = categoryList.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "DESC":
                            categoryList = categoryList.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                    }
                    break;
                case "CategoryDescription":
                    switch(sortOrder) {
                        case "ASC":
                            categoryList = categoryList.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "DESC":
                            categoryList = categoryList.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                    }
                    break;
                default:
                    categoryList = categoryList.OrderBy(x => x.CategoryDesc).ToList();
                    break;
            }

            //Sends current pages number to the view
            int currentPageNo = int.Parse(page ?? "1");
            ViewBag.CurrentPage = currentPageNo;

            //For skipping n number of pages for pagination
            categoryList = categoryList.Skip((currentPageNo - 1) * 10).Take(10);
            return View(categoryList);
        }
        
        public ActionResult Delete(int id) {
            try {
                objBs.CategoryBusiness.DeleteCategory(id);
                TempData["DeleteMsg"] = "Deleted Sucessfully";
                return RedirectToAction("Index");
            }
            catch (Exception exMessage) {
                TempData["DeleteMsg"] = "Delete Failed with exception of " + exMessage;
                return RedirectToAction("Index");                
            }  
        }
    }
}