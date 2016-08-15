using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL {
    public class UserBs {
        private readonly UserDb _objUserDb;

        public UserBs() {
            _objUserDb = new UserDb();
        }

        public IEnumerable<tbl_User> GetAllUser() {
            return _objUserDb.GetAllUser();
        }

        public tbl_User GetUserById(int id) {
            return _objUserDb.GetUserById(id);
        }

        public void InsertUser(tbl_User objUser) {
            _objUserDb.InsertUser(objUser);
        }

        public void UpdateUser(tbl_User objUser) {
            _objUserDb.UpdateUser(objUser);
        }

        public void DeleteUser(int id) {
            _objUserDb.DeleteUser(id);
        }
    }
}
