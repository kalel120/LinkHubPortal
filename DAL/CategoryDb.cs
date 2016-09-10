/*First Entity Framework dlls are added to the project
 * Take private and readonly variables to create db entities through constructor
 * Implement the methods GetAllUrl, GetUrlById, InsertUrl, UpdateUrl, Delete
*/
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BOL;

namespace DAL {
    public class CategoryDb {
        private LinkHubDbEntities _dbEntities;

        public CategoryDb() {
            _dbEntities = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Category> GetAllCategories() {
            return _dbEntities.tbl_Category.ToList();
        }

        public tbl_Category GetCategoryById(int id) {
            return _dbEntities.tbl_Category.Find(id);
        }

        public void InsertCategory(tbl_Category objCategory) {
            _dbEntities.tbl_Category.Add(objCategory);
            SaveChangesInCategory();
        }

        public void UpdateCategory(tbl_Category objCategory) {
            _dbEntities.Entry(objCategory).State = EntityState.Modified;
        }

        public void DeleteCategory(int id) {
            tbl_Category categoryToDelete = _dbEntities.tbl_Category.Find(id);
            _dbEntities.tbl_Category.Remove(categoryToDelete);
            SaveChangesInCategory();
        }

        private void SaveChangesInCategory() {
            _dbEntities.SaveChanges();
        }
    }
}
