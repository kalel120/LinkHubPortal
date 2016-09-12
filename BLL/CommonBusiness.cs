using System;
using System.Transactions;
using BOL;

namespace BLL {
    public class CommonBusiness : _BaseBusinessLogic {
        public void InsertQuickUrl(QuickUrlSubmitModel quickUrl) {
            using (TransactionScope transaction = new TransactionScope()) {
                try {
                    //Extract User object from QuickSubmitUser object
                    tbl_User objQuickUser = quickUrl.QuickSubmitUser;
                    objQuickUser.Password = objQuickUser.ConfirmPassword = "12345";
                    objQuickUser.Role = "U";
                    UserBusiness.InsertUser(objQuickUser);

                    //Extract Url object from QuickSubmit object
                    tbl_Url objQuickUrl = quickUrl.QuickSubmitUrl;
                    objQuickUrl.UserId = objQuickUser.UserId;
                    objQuickUrl.UrlDesc = objQuickUrl.UrlTitle;
                    objQuickUrl.IsApproved = "P";
                    UrlBusiness.Insert(objQuickUrl);

                    transaction.Complete();
                }
                catch (Exception exception) {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}
