using lab.Authorized.Net.App.Helpers;
using System;
using AuthorizeNet.Api.Contracts.V1;
using System.Web.Mvc;
using lab.Authorized.Net.App.ViewModels;
using System.Collections.Generic;

namespace lab.Authorized.Net.App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                var aNetApiCreditCardTypeViewModel = new ANetApiCreditCardTypeViewModel
                {
                    CardNumber = "4111111111111111",
                    ExpirationDate = "0718",
                    CardCode = "123"
                };

                var aNetApiCustomerAddressTypeViewModel = new ANetApiCustomerAddressTypeViewModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 My St",
                    City = "OurTown",
                    ZipCode = "98004"
                };

                var aNetApiLineItemTypeList = new List<ANetApiLineItemType>() {
                    new ANetApiLineItemType { ItemId = "1", Name = "t-shirt", Quantity = 2, UnitPrice = new Decimal(15.00) },
                    new ANetApiLineItemType { ItemId = "2", Name = "snowboard", Quantity = 1, UnitPrice = new Decimal(450.00) }
                };

                var aNetApiResponseViewModel = AuthorizedNetHelper.ChargeCreditCard(new Decimal(465.00), aNetApiCreditCardTypeViewModel, aNetApiCustomerAddressTypeViewModel, aNetApiLineItemTypeList);

                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}