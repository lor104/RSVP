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

namespace RSVP.Controllers
{
    public class GuestEventController : ApiController
    {
        //return list of all guesteventjunctions
        public List<GuestEventJunction> GetAll()
        {
            using (RSVPEntities db = new RSVPEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.GuestEventJunctions.ToList();

            }
        }

        //return list of all event ids that a guest (Id) is invited to
        public IHttpActionResult GetEventsForGuest(int Id)
        {

            using (RSVPEntities db = new RSVPEntities())
            {
                List<GuestEventJunction> guestEventJunction = db.GuestEventJunctions.Where(x => x.GuestID == Id).ToList();

                GuestEventDTO guestEventDTO = new GuestEventDTO()
                {
                    GuestEventList = guestEventJunction.Select(x => x.EventID).ToList()
                };
                               
                return Ok(guestEventDTO);
            }

        }
    }
}

//if first name and last name match a guest  -  take guest id and find events within the GuestEventJunction table
//find all entries for GuestEventJunction (all events that guest is invited to)
//return event ID's
