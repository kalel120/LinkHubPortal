/* This class just passes the objects into Data access layer 
 */
using System.Collections.Generic;
using BOL;
using DAL;

namespace BLL {
    public class UrlBs {
        private readonly UrlDb _objUrlDb;

        public UrlBs() {
            _objUrlDb = new UrlDb();
        }

        public IEnumerable<tbl_Url> GetAll() {
            return _objUrlDb.GetAllUrl();
        }

        public tbl_Url GetUrlById(int id) {
            return _objUrlDb.GetUrlById(id);
        }

        public void Insert(tbl_Url url) {
            _objUrlDb.InsertUrl(url);
        }

        public void Update(tbl_Url url) {
            _objUrlDb.UpdateUrl(url);
        }

        public void Delete(int id) {
            _objUrlDb.Delete(id);
        }
    }
}
