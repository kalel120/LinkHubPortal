namespace BLL {
   public class BaseBusinessLogic {
        public CategoryBs CategoryBusiness { get; set; }
        public UrlBs UrlBusiness { get; set; }
        public UserBs UserBusiness { get; set; }
        
        public BaseBusinessLogic() {
            CategoryBusiness = new CategoryBs();
            UrlBusiness = new UrlBs();
            UserBusiness = new UserBs();
        }
    }
}
