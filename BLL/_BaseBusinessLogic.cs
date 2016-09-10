using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class _BaseBusinessLogic {
        public CategoryBs CategoryBusiness { get; set; }
        public UrlBs UrlBusiness { get; set; }
        public UserBs UserBusiness { get; set; }

        public _BaseBusinessLogic() {
            CategoryBusiness = new CategoryBs();
            UrlBusiness = new UrlBs();
            UserBusiness = new UserBs();
        }
    }
}
