using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RSVP.Infrastucture.Models.DTOs
{
    public class GuestDTO
    {
        [JsonProperty(PropertyName = "guestID")]
        public int GuestID { get; set; }
        [JsonProperty(PropertyName = "guestGroupID")]
        public int? GuestGroupID { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
    }
}