/*First Entity Framework dlls are added to the project
 * Take private variables to create db entities through constructor
 * Implement the methods GetAllUrl, GetUrlById, InsertUrl, UpdateUrl, Delete
*/
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BOL;

namespace DAL {
    public class UserDb {
        private readonly LinkHubDbEntities _dbEntities;

        public UserDb() {
            _dbEntities = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetAllUser() {
            return _dbEntities.tbl_User.ToList();
        }

        public tbl_User GetUserById(int id) {
            return _dbEntities.tbl_User.Find(id);
        }

        public void InsertUser(tbl_User objUser) {
            _dbEntities.tbl_User.Add(objUser);
            SaveChangesInUser();
        }

        public void UpdateUser(tbl_User objUser) {
            _dbEntities.Entry(objUser).State = EntityState.Modified;
        }

        public void DeleteUser(int id) {
            var user = _dbEntities.tbl_User.Find(id);
            _dbEntities.tbl_User.Remove(user);
            SaveChangesInUser();
        }

        private void SaveChangesInUser() {
            _dbEntities.SaveChanges();
        }
    }
}
