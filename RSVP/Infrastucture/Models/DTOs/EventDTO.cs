using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace RSVP.Infrastucture.Models.DTOs
{
    public class EventDTO
    {
        [JsonProperty(PropertyName = "eventID")]
        public int EventID { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "eventStartDate")]
        public DateTime EventStartDate { get; set; }
        [JsonProperty(PropertyName = "eventEndDate")]
        public DateTime EventEndDate { get; set; }
        [JsonProperty(PropertyName = "venue")]
        public string Venue { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "eventStartTime")]
        public TimeSpan EventStartTime { get; set; }
        [JsonProperty(PropertyName = "eventEndTime")]
        public TimeSpan EventEndTime { get; set; }
        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }
    }
}