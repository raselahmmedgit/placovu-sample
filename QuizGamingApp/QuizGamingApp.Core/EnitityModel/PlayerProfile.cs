using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGamingApp.Core.EnitityModel
{
    public class PlayerProfile : Base
    {
        [JsonProperty(PropertyName = "clientProfileId")]
        public string ClientProfileId { get; set; }
        [JsonProperty(PropertyName = "playerName")]
        public string PlayerName { get; set; }
        [JsonProperty(PropertyName = "playerNumber")]
        public string PlayerNumber { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "EmailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty(PropertyName = "phoneNo")]
        public string PhoneNo { get; set; }
        [JsonProperty(PropertyName = "phoneCode")]
        public string PhoneCode { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "isOverAge")]
        public bool IsOverAge { get; set; }
        
    }
}
