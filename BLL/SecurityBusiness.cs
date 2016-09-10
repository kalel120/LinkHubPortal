using System;
using System.Linq;
using System.Web.Security;
using DAL;

namespace BLL {
    public class SecurityBusiness : _BaseBusinessLogic { }

    //Implementation of  custom Membership provider
    public class LinkHubMembershipProvider : MembershipProvider {
        private UserDb _objDb;
        public LinkHubMembershipProvider() {
            _objDb = new UserDb();
        }

        #region Not Implemented Yet
        public override string ApplicationName {
            get {
                throw new NotImplementedException();
            }

            set {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset {
            get {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval {
            get {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts {
            get {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters {
            get {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength {
            get {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow {
            get {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat {
            get {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression {
            get {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer {
            get {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail {
            get {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline() {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline) {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email) {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName) {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user) {
            throw new NotImplementedException();
        }
        #endregion

        public override bool ValidateUser(string username, string password) {
            var count = _objDb.GetAllUser().Where(x => x.UserEmail == username && x.Password == password).Count();
            if(count != 0) {
                return true;
            }
            return false;
        }
    }

    //Implementation of Role Provider
    public class LinkHubRoleProvider : RoleProvider {
        private UserDb _objDb;
        public LinkHubRoleProvider() {
            _objDb = new UserDb();
        }
        public override bool IsUserInRole(string username, string roleName) {
            throw new NotImplementedException();
        }

        //Implementing Role Provider
        public override string[] GetRolesForUser(string username) {
            string[] roles = {_objDb.GetAllUser().Where(x => x.UserEmail == username).FirstOrDefault().Role};
            return roles;
        }

        public override void CreateRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
