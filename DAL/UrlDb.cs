/*First Entity Framework dlls are added to the project
 * Take private variables to create db entities through constructor
 * Implement the methods GetAllUrl, GetUrlById, InsertUrl, UpdateUrl, Delete
*/
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BOL;

namespace DAL {
    public class UrlDb {
        private LinkHubDbEntities _dbEntities;
        public UrlDb() {
            _dbEntities = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Url> GetAllUrl() {
            return _dbEntities.tbl_Url.ToList();
        }

        public tbl_Url GetUrlById(int id) {
            return _dbEntities.tbl_Url.Find(id);
        }

        public void InsertUrl(tbl_Url url) {
            _dbEntities.tbl_Url.Add(url);
            SaveChangesInUrl();
        }

        public void UpdateUrl(tbl_Url url) {
            _dbEntities.Entry(url).State = EntityState.Modified;
            _dbEntities.SaveChanges();
        }

        public void Delete(int id) {
            tbl_Url objUrl = _dbEntities.tbl_Url.Find(id);
            _dbEntities.tbl_Url.Remove(objUrl);
            SaveChangesInUrl();
        }

        public void SaveChangesInUrl() {
            _dbEntities.SaveChanges();
        }

    }
}
