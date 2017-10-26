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

            return View();
        }
    }
}