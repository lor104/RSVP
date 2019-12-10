using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RSVP.Infrastucture.Models.DTOs
{
    public class GuestEventDTO
    {
        [JsonProperty(PropertyName = "guestEventList")]
        public List<int> GuestEventList { get; set; }
    }
}