using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Transactions;

namespace BLL {
    public class AdminBusiness : _BaseBusinessLogic {
        public void ApproveOrReject(List<int> idList, string status) {
            using (TransactionScope updateTransaction = new TransactionScope()) {
                try {
                    foreach (var item in idList) {
                        var urlToUpdate = UrlBusiness.GetUrlById(item);
                        urlToUpdate.IsApproved = status;
                        UrlBusiness.Update(urlToUpdate);
                    }
                    updateTransaction.Complete();
                }
                catch (DbEntityValidationException entityException) {
                    foreach (var validationErrors in entityException.EntityValidationErrors) {
                        foreach (var validationError in validationErrors.ValidationErrors) {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                    throw new Exception(entityException.Message);
                }
            }
        }
    }
}
