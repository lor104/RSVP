using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSVP.Infrastucture.Data;

namespace RSVP.Infrastucture.Models.ViewModels
{
    public class EventViewModel
    {
        public List<Event> Events { get; set; }
        public List<Guest> Guests { get; set; }
        public List<GuestEventJunction> GuestEventJunctions { get; set; }
    }
}