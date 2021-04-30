using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Models {
    public class User : Owner {
        public int UserId { get; set; }
        public string DisplayName {
            get {
                return FirstName + " " + LastName;
            }
        }
    }
}
