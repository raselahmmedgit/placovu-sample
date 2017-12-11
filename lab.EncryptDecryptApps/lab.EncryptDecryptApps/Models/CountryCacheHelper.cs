using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.EncryptDecryptApps.Models
{
    public class CountryCacheHelper
    {
        public List<Country> GetCountries
        {
            get
            {
                List<Country> _countryList = new List<Country>
                            {
                                new Country { CountryId = 1, CountryName = "BANGLADESH", CountryDisplayName = "Bangladesh", CountryIso = "BD", CountryIso3 = "BGD", NumberCode = "50", PhoneCode = "880", IsPublished = true},
                                new Country { CountryId = 2, CountryName = "INDIA", CountryDisplayName = "India", CountryIso = "IN", CountryIso3 = "IND", NumberCode = "356", PhoneCode = "91", IsPublished = true},
                                new Country { CountryId = 3, CountryName = "UNITED STATES", CountryDisplayName = "United States", CountryIso = "US", CountryIso3 = "USA", NumberCode = "840", PhoneCode = "1", IsPublished = true}
                            };
                return _countryList;
            }
        }
    }
}