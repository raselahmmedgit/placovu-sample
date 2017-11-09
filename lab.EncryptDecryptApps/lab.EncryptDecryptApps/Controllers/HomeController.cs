using lab.EncryptDecryptApps.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.EncryptDecryptApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string sqlConnectionKey = SiteConfigurationReader.SqlConnectionKey;

            string sqlConnectionEncrypt = CryptographyHelper.Encrypt(sqlConnectionKey);

            string sqlConnectionDecrypt = CryptographyHelper.Decrypt(sqlConnectionEncrypt);

            string encryptConnection = SiteConfigurationReader.GetAppSettingsString("ConStr");

            string decryptConnection = CryptographyHelper.Decrypt(encryptConnection);

            //

            string PlacovuOntrackHealthLive = CryptographyHelper.Encrypt(@"data source=PETERSON\PETERSON2008EXR2;initial catalog=PlacovuOntrackHealth;persist security info=True;user id=sa;password=$$OntrackHealth##2008R2$$;MultipleActiveResultSets=True;App=EntityFramework");

            string UroNavRegistryLive = CryptographyHelper.Encrypt(@"data source=PETERSON\PETERSON2008EXR2;initial catalog=UronavRegistry;persist security info=True;user id=sa;password=$$OntrackHealth##2008R2$$;MultipleActiveResultSets=True;App=EntityFramework");


            //

            return View();
        }
    }
}