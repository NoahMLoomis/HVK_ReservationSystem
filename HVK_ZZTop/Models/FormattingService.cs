using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Models {
    public class FormattingService {
        private Dictionary<string, string> provinces = new Dictionary<string, string>{
                { "NL", "Newfoundland and Labrador" },
                { "PE", "Prince Edward Island" },
                { "NS", "Nova Scotia" },
                { "NB", "New Brunswick" },
                { "QC", "Quebec" },
                { "ON", "Ontario" },
                { "MB", "Manitoba" },
                { "SK", "Saskatchewan" },
                { "AB", "Alberta" },
                { "BC", "British Columbia" },
                { "YT", "Yukon" },
                { "NT", "Northwest Territories" },
                { "NU", "Nunavut" }
            };
        public string ProvinceFull(string p) {

            string retVal;
            if (!String.IsNullOrEmpty(p) && provinces.TryGetValue(p, out retVal)) {
                return retVal;
            } else {
                return null;
            }
        }

        public string PostalDisplay(string pc) {
            string retVal = null;
            if (pc != null && pc.Length == 6) {
                retVal = pc.Substring(0, 3) + " " + pc.Substring(3);
            }
            return retVal;
        }

        public string PhoneDisplay(string tel) {
            long number;

            if (Int64.TryParse(tel, out number)) {
                return string.Format("{0:(###) ###-####}", number);
            } else {
                return tel;
            }

        }

        public string DateDisplay(DateTime? d) {
            return $"{d:yyyy\\/MM\\/dd}";
        }
    }
}
