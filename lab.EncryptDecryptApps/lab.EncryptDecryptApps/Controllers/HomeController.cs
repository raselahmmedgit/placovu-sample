using lab.EncryptDecryptApps.Helpers;
using lab.EncryptDecryptApps.Models;
using lab.EncryptDecryptApps.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace lab.EncryptDecryptApps.Controllers
{
    public class HomeController : Controller
    {
        private CountryCacheHelper _countryCacheHelper = new CountryCacheHelper();

        public ActionResult Index()
        {
            #region Encrypt/Decrypt

            //string sqlConnectionKey = SiteConfigurationReader.SqlConnectionKey;

            //string sqlConnectionEncrypt = CryptographyHelper.Encrypt(sqlConnectionKey);

            //string sqlConnectionDecrypt = CryptographyHelper.Decrypt(sqlConnectionEncrypt);

            //string encryptConnection = SiteConfigurationReader.GetAppSettingsString("ConStr");

            //string decryptConnection = CryptographyHelper.Decrypt(encryptConnection);

            //string PlacovuOntrackHealthLive = CryptographyHelper.Encrypt(@"data source=PETERSON\PETERSON2008EXR2;initial catalog=PlacovuOntrackHealth;persist security info=True;user id=sa;password=$$OntrackHealth##2008R2$$;MultipleActiveResultSets=True;App=EntityFramework");

            //string UroNavRegistryLive = CryptographyHelper.Encrypt(@"data source=PETERSON\PETERSON2008EXR2;initial catalog=UronavRegistry;persist security info=True;user id=sa;password=$$OntrackHealth##2008R2$$;MultipleActiveResultSets=True;App=EntityFramework");

            //string UroNavRegistryLiveServerDecrypt = CryptographyHelper.Decrypt(@"YutuYEP1ExBz7QyLbnTdzYv6KL+9QO0WoeOSSz1m8MMoaRx1wWHJwAjkKAy80sX3VDDRd6WL591d5Ye1ifLVyk/cIHk9jAXGuFY46bdDoKqSKST96BovzTi7o3193syq1o0Souw085nllHNPYdIIUSqKpMeXskDbd+reEFomsdO9aQ+dl5y6ifAoNw4cm5KNA9vP9rYAuZTUzDfCq5sP0IqDLYPGHMV8MRQeOvwwVjHRllC3WlQGFWZ+YW1jau6ogN4P7KmLkRvsU2wz8fMGNM+J92f8aZVbYgPCaxmTxyT8ZH3b8nUhplJrH7lXGyd+8+aiB1Xz/RLwFrBla4WkUw==");

            //string UroNavRegistryLiveServerEncrypt = CryptographyHelper.Encrypt(@"data source=PETERSON\PETERSON2008EXR2;initial catalog=UronavRegistry_New;persist security info=True;user id=sa;password=$$OntrackHealth##2008R2$$;MultipleActiveResultSets=True;App=EntityFramework");

            //string UroNavRegistryLiveServerDecrypt = CryptographyHelper.Decrypt(@"data source=PETERSON\PETERSON2008EXR2;initial catalog=UronavRegistry;persist security info=True;user id=sa;password=$$OntrackHealth##2008R2$$;MultipleActiveResultSets=True;App=EntityFramework");

            //string UroNavRegistryLiveServerEncrypt = CryptographyHelper.Encrypt(UroNavRegistryLiveServerDecrypt);

            #endregion

            #region Twilio

            //try
            //{
            //    // Find your Account Sid and Auth Token at twilio.com/user/account
            //    const string accountSid = "AC53b5864228773fef0440bdc3341a513d";
            //    const string authToken = "9969abc6e589e669b352ba407c720aa1";

            //    // Initialize the Twilio client
            //    TwilioClient.Init(accountSid, authToken);

            //    // make an associative array of people we know, indexed by phone number
            //    var people = new Dictionary<string, string>() {
            //        {"+8801672089753", "Nahid"},
            //        {"+8801621611880", "Touhid"},
            //        //{"+8801911045573", "Rasel"}
            //    };

            //    var mediaUrl = new List<Uri>() {
            //      new Uri( "https://google.com" )
            //    };

            //    // Iterate over all our friends
            //    foreach (var person in people)
            //    {
            //        // Send a new outgoing SMS by POSTing to the Messages resource
            //        MessageResource.Create(
            //            from: new PhoneNumber("+15615670381"), // From number, must be an SMS-enabled Twilio number
            //            to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
            //            body: $"Dear {person.Value}, This is placovu SMS.", // Message content
            //            mediaUrl: mediaUrl
            //            );

            //        Console.WriteLine($"Sent message to {person.Value}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult EditSortable(SortableItem[] items)
        {
            foreach (var item in items)
            {
                item.DisplayOrder = item.UpdatedDisplayOrder;
            }

            return null;
        }
    }
}