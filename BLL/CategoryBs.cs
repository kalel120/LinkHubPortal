/* This class just communicates with the DAL for "Retrieving" data from DAL and sends objects to UI
 */
using System.Collections.Generic;
using BOL;
using DAL;

namespace BLL {
    public class CategoryBs {
        private readonly CategoryDb _objCategoryDb;

        public CategoryBs() {
            _objCategoryDb = new CategoryDb();
        }

        public IEnumerable<tbl_Category> GetAllCategories() {
            return _objCategoryDb.GetAllCategories();
        }

        public tbl_Category GetCategoryById(int id) {
            return _objCategoryDb.GetCategoryById(id);
        }

        public void InsertCategory(tbl_Category objCategory) {
             _objCategoryDb.InsertCategory(objCategory);
        }

        public void UpdateCategory(tbl_Category objCategory) {
           _objCategoryDb.UpdateCategory(objCategory);
        }

        public void DeleteCategory(int id) {
            _objCategoryDb.DeleteCategory(id);
        }
    }
}
