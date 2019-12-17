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
    public class EventController : ApiController
    {
        //return list of all events
        public List<Event> GetAll()
        {
            using (RSVPEntities db = new RSVPEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Events.ToList();

            }
        }

        //return events with specified ids
        public IHttpActionResult GetEvent(int Id)
        {

            using (RSVPEntities db = new RSVPEntities())
            {
                Event eventx = db.Events.FirstOrDefault(x => x.EventID == Id);

                EventDTO eventDTO = new EventDTO()
                {
                    EventID = eventx.EventID,
                    Title = eventx.Title,
                    Subtitle = eventx.Subtitle,
                    Description = eventx.Description,
                    EventStartDate = eventx.EventStartDate.ToString("MMMM dd, yyyy"),
                    EventEndDate = eventx.EventEndDate.ToString("MMMM dd, yyyy"),
                    Venue = eventx.Venue,
                    Address = eventx.Address,
                    EventStartTime = eventx.EventStartTime.ToString(),
                    EventEndTime = eventx.EventEndTime.ToString(),
                    Details = eventx.Details
                };
                               
                return Ok(eventDTO);
            }

        }
    }
}

//if first name and last name match a guest  -  take guest id and find events within the GuestEventJunction table
//find all entries for GuestEventJunction (all events that guest is invited to)
//return event ID's
