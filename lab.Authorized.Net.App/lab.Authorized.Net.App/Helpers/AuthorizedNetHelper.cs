using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using lab.Authorized.Net.App.ViewModels;
using lab.Authorized.Net.App.Utility;

namespace lab.Authorized.Net.App.Helpers
{
    public static class AuthorizedNetHelper
    {
        public static string APILOGINID = "48kMS6mr268h";
        public static string APITRANSACTIONKEY = "862FfmS2TY6P2FxA";
        public static string APIKEY = "Simon";

        public static ANetApiResponseViewModel ChargeCreditCard(decimal amount, ANetApiCreditCardTypeViewModel aNetApiCreditCardTypeViewModel, ANetApiCustomerAddressTypeViewModel aNetApiCustomerAddressTypeViewModel, List<ANetApiLineItemType> aNetApiLineItemTypeList)
        {
            try
            {
                ANetApiResponseViewModel aNetApiResponseViewModel = new ANetApiResponseViewModel();

                string apiLoginID = SiteConfigurationReader.GetAppSettingsString("AuthorizedNet.APILOGINID");
                string apiTransactionKey = SiteConfigurationReader.GetAppSettingsString("AuthorizedNet.APITRANSACTIONKEY");

                ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

                // define the merchant information (authentication / transaction id)
                ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
                {
                    name = apiLoginID,
                    ItemElementName = ItemChoiceType.transactionKey,
                    Item = apiTransactionKey,
                };

                var creditCard = new creditCardType
                {
                    cardNumber = aNetApiCreditCardTypeViewModel.CardNumber,
                    expirationDate = aNetApiCreditCardTypeViewModel.ExpirationDate,
                    cardCode = aNetApiCreditCardTypeViewModel.CardCode
                };

                var billingAddress = new customerAddressType
                {
                    firstName = aNetApiCustomerAddressTypeViewModel.FirstName,
                    lastName = aNetApiCustomerAddressTypeViewModel.LastName,
                    address = aNetApiCustomerAddressTypeViewModel.Address,
                    city = aNetApiCustomerAddressTypeViewModel.City,
                    zip = aNetApiCustomerAddressTypeViewModel.ZipCode
                };

                //standard api call to retrieve response
                var paymentType = new paymentType { Item = creditCard };

                // Add line Items
                var lineItemTypeList = new List<lineItemType>();

                foreach (var aNetApiLineItemType in aNetApiLineItemTypeList)
                {
                    var lineItemType = new lineItemType { itemId = aNetApiLineItemType.ItemId, name = aNetApiLineItemType.Name, quantity = aNetApiLineItemType.Quantity, unitPrice = aNetApiLineItemType.UnitPrice };
                    lineItemTypeList.Add(lineItemType);
                }

                var transactionRequest = new transactionRequestType
                {
                    transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

                    amount = amount,
                    payment = paymentType,
                    billTo = billingAddress,
                    lineItems = lineItemTypeList.ToArray()
                };

                var request = new createTransactionRequest { transactionRequest = transactionRequest };

                // instantiate the controller that will call the service
                var controller = new createTransactionController(request);
                controller.Execute();

                // get the response from the service (errors contained if any)
                var response = controller.GetApiResponse();

                // validate response
                if (response != null)
                {
                    if (response.messages.resultCode == messageTypeEnum.Ok)
                    {
                        if (response.transactionResponse.messages != null)
                        {
                            aNetApiResponseViewModel.TransactionID = response.transactionResponse.transId;
                            aNetApiResponseViewModel.ResponseCode = response.transactionResponse.responseCode;
                            aNetApiResponseViewModel.MessageCode = response.transactionResponse.messages[0].code;
                            aNetApiResponseViewModel.MessageDescription = response.transactionResponse.messages[0].description;
                            aNetApiResponseViewModel.AuthCode = response.transactionResponse.authCode;
                        }
                        else
                        {
                            aNetApiResponseViewModel.ErrorDescription = "Failed Transaction.";
                            if (response.transactionResponse.errors != null)
                            {
                                aNetApiResponseViewModel.ErrorCode = response.transactionResponse.errors[0].errorCode;
                                aNetApiResponseViewModel.ErrorDescription = response.transactionResponse.errors[0].errorText;
                            }
                        }
                    }
                    else
                    {
                        aNetApiResponseViewModel.ErrorDescription = "Failed Transaction.";
                        if (response.transactionResponse != null && response.transactionResponse.errors != null)
                        {
                            aNetApiResponseViewModel.ErrorCode = response.messages.message[0].code;
                            aNetApiResponseViewModel.ErrorDescription = response.messages.message[0].text;
                        }
                        else
                        {
                            aNetApiResponseViewModel.ErrorCode = response.messages.message[0].code;
                            aNetApiResponseViewModel.ErrorDescription = response.messages.message[0].text;
                        }
                    }
                }
                else
                {
                    aNetApiResponseViewModel.ErrorDescription = "Null Response.";
                }

                return aNetApiResponseViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public static ANetApiResponse ChargeCreditCard(String apiLoginID, String apiTransactionKey, decimal amount)
        {
            Console.WriteLine("Charge Credit Card Sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey,
            };

            var creditCard = new creditCardType
            {
                cardNumber = "4111111111111111",
                expirationDate = "0718",
                cardCode = "123"
            };

            var billingAddress = new customerAddressType
            {
                firstName = "John",
                lastName = "Doe",
                address = "123 My St",
                city = "OurTown",
                zip = "98004"
            };

            //standard api call to retrieve response
            var paymentType = new paymentType { Item = creditCard };

            // Add line Items
            var lineItems = new lineItemType[2];
            lineItems[0] = new lineItemType { itemId = "1", name = "t-shirt", quantity = 2, unitPrice = new Decimal(15.00) };
            lineItems[1] = new lineItemType { itemId = "2", name = "snowboard", quantity = 1, unitPrice = new Decimal(450.00) };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

                amount = amount,
                payment = paymentType,
                billTo = billingAddress,
                lineItems = lineItems
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            // instantiate the controller that will call the service
            var controller = new createTransactionController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            // validate response
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse.messages != null)
                    {
                        Console.WriteLine("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
                        Console.WriteLine("Response Code: " + response.transactionResponse.responseCode);
                        Console.WriteLine("Message Code: " + response.transactionResponse.messages[0].code);
                        Console.WriteLine("Description: " + response.transactionResponse.messages[0].description);
                        Console.WriteLine("Success, Auth Code : " + response.transactionResponse.authCode);
                    }
                    else
                    {
                        Console.WriteLine("Failed Transaction.");
                        if (response.transactionResponse.errors != null)
                        {
                            Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed Transaction.");
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                        Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
                    }
                    else
                    {
                        Console.WriteLine("Error Code: " + response.messages.message[0].code);
                        Console.WriteLine("Error message: " + response.messages.message[0].text);
                    }
                }
            }
            else
            {
                Console.WriteLine("Null Response.");
            }

            return response;
        }

    }

}