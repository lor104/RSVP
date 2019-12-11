using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
using RSVP.Infrastucture.Data;
using RSVP.Infrastucture.Models.ViewModels;
using RSVP.Infrastucture.Models;
using RSVP.Infrastucture.Models.DTOs;

namespace RSVP.Controllers.API
{
    public class GuestController : ApiController
    {
        //return list of all guests
        public List<Guest> GetAll()
        {
            using (RSVPEntities db = new RSVPEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Guests.ToList();

            }
        }

        //return guest of specific id
        public IHttpActionResult GetGuest(int Id)
        {
            using (RSVPEntities db = new RSVPEntities())
            {
                Guest guest = db.Guests.FirstOrDefault(x => x.GuestID == Id);

                GuestDTO guestDTO = new GuestDTO
                {
                    GuestID = guest.GuestID,
                    GuestGroupID = guest.GuestGroupID,
                    FirstName = guest.FirstName,
                    LastName = guest.LastName
                };

                return Ok(guestDTO);

            }
        }

    }
}
