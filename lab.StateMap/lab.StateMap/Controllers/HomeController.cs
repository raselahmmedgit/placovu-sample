using lab.StateMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.StateMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var stateViewModelList = GetStateViewModelList();
            return View(stateViewModelList);
        }

        private List<StateViewModel> GetStateViewModelList()
        {
            List<StateViewModel> stateViewModelList = new List<StateViewModel>() {
                new StateViewModel { StateId = 1, StateName = "	Alabama", StateShortName = "AL" },
                new StateViewModel { StateId = 2, StateName = "	Alaska", StateShortName = "AK" },
                new StateViewModel { StateId = 4, StateName = "	Arizona", StateShortName = "AZ" },
                new StateViewModel { StateId = 5, StateName = "	Arkansas", StateShortName = "AR" },
                new StateViewModel { StateId = 6, StateName = "	California", StateShortName = "CA" },
                new StateViewModel { StateId = 8, StateName = "	Colorado", StateShortName = "CO" },
                new StateViewModel { StateId = 9, StateName = "	Connecticut", StateShortName = "CT" },
                new StateViewModel { StateId = 10, StateName = "Delaware", StateShortName = "DE" },
                new StateViewModel { StateId = 11, StateName = "District Of Columbia", StateShortName = "DC" },
                new StateViewModel { StateId = 12, StateName = "Florida", StateShortName = "FL" },
                new StateViewModel { StateId = 13, StateName = "Georgia", StateShortName = "GA" },
                new StateViewModel { StateId = 15, StateName = "Hawaii", StateShortName = "HI" },
                new StateViewModel { StateId = 16, StateName = "Idaho", StateShortName = "ID" },
                new StateViewModel { StateId = 17, StateName = "Illinois", StateShortName = "IL" },
                new StateViewModel { StateId = 18, StateName = "Indiana", StateShortName = "IN" },
                new StateViewModel { StateId = 19, StateName = "Iowa", StateShortName = "IA" },
                new StateViewModel { StateId = 20, StateName = "Kansas", StateShortName = "KS" },
                new StateViewModel { StateId = 21, StateName = "Kentucky", StateShortName = "KY" },
                new StateViewModel { StateId = 22, StateName = "Louisiana", StateShortName = "LA" },
                new StateViewModel { StateId = 23, StateName = "Maine", StateShortName = "ME" },
                new StateViewModel { StateId = 24, StateName = "Maryland", StateShortName = "MD" },
                new StateViewModel { StateId = 25, StateName = "Massachusetts", StateShortName = "MA" },
                new StateViewModel { StateId = 26, StateName = "Michigan", StateShortName = "MI" },
                new StateViewModel { StateId = 27, StateName = "Minnesota", StateShortName = "MN" },
                new StateViewModel { StateId = 28, StateName = "Mississippi", StateShortName = "MS" },
                new StateViewModel { StateId = 29, StateName = "Missouri", StateShortName = "MO" },
                new StateViewModel { StateId = 30, StateName = "Montana", StateShortName = "MT" },
                new StateViewModel { StateId = 31, StateName = "Nebraska", StateShortName = "NE" },
                new StateViewModel { StateId = 32, StateName = "Nevada", StateShortName = "NV" },
                new StateViewModel { StateId = 33, StateName = "New Hampshire", StateShortName = "NH" },
                new StateViewModel { StateId = 34, StateName = "New Jersey", StateShortName = "NJ" },
                new StateViewModel { StateId = 35, StateName = "New MExico", StateShortName = "NM" },
                new StateViewModel { StateId = 36, StateName = "New York", StateShortName = "NY" },
                new StateViewModel { StateId = 37, StateName = "North Carolina", StateShortName = "NC" },
                new StateViewModel { StateId = 38, StateName = "North Dakota", StateShortName = "ND" },
                new StateViewModel { StateId = 39, StateName = "Ohio", StateShortName = "OH" },
                new StateViewModel { StateId = 40, StateName = "Oklahoma", StateShortName = "OK" },
                new StateViewModel { StateId = 41, StateName = "Oregon", StateShortName = "OR" },
                new StateViewModel { StateId = 42, StateName = "Pennsylvania", StateShortName = "PA" },
                new StateViewModel { StateId = 44, StateName = "Rhode Island", StateShortName = "RI" },
                new StateViewModel { StateId = 45, StateName = "South Carolina", StateShortName = "SC" },
                new StateViewModel { StateId = 46, StateName = "South Dakota", StateShortName = "SD" },
                new StateViewModel { StateId = 47, StateName = "Tennessee", StateShortName = "TN" },
                new StateViewModel { StateId = 48, StateName = "Texas", StateShortName = "TX" },
                new StateViewModel { StateId = 49, StateName = "Utah", StateShortName = "UT" },
                new StateViewModel { StateId = 50, StateName = "Vermont", StateShortName = "VT" },
                new StateViewModel { StateId = 51, StateName = "Virginia", StateShortName = "VA" },
                new StateViewModel { StateId = 53, StateName = "Washington", StateShortName = "WA" },
                new StateViewModel { StateId = 54, StateName = "West Virginia", StateShortName = "WV" },
                new StateViewModel { StateId = 55, StateName = "Wisconsin", StateShortName = "WI" },
                new StateViewModel { StateId = 56, StateName = "Wyoming", StateShortName = "WY" },
                new StateViewModel { StateId = 57, StateName = "American Samoa", StateShortName = "AS" },
                new StateViewModel { StateId = 58, StateName = "Guam", StateShortName = "GU" },
                new StateViewModel { StateId = 59, StateName = "Northern Mariana Islands", StateShortName = "MP" },
                new StateViewModel { StateId = 60, StateName = "Puerto Rico", StateShortName = "PR" },
                new StateViewModel { StateId = 61, StateName = "U.S. Virgin Islands", StateShortName = "VI" },
                new StateViewModel { StateId = 62, StateName = "United States Minor Outlying Islands", StateShortName = "UM" }
            };

            return stateViewModelList;
        }

    }
}