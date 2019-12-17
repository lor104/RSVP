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
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

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

        [Route("api/Guest/GetGuestFromName/{FirstAndLastName}")]
        public IHttpActionResult GetGuestFromName(string FirstAndLastName)
        {
            char[] seperator = { '?', '_' };
            String[] Name = FirstAndLastName.Split(seperator, 2, StringSplitOptions.RemoveEmptyEntries);
            string FirstName = Name[0];
            string LastName = Name[1];
            using (RSVPEntities db = new RSVPEntities())
            {
                Guest guest = db.Guests.FirstOrDefault(x => x.FirstName == FirstName && x.LastName == LastName);

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

        [Route("api/Guest/GetEventInfoFromName/{FirstAndLastName}")]
        public IHttpActionResult GetEventInfoFromName(string FirstAndLastName)
        {
            char[] seperator = { '?', '_' };
            String[] Name = FirstAndLastName.Split(seperator, 2, StringSplitOptions.RemoveEmptyEntries);
            string FirstName = Name[0];
            string LastName = Name[1];
            using (RSVPEntities db = new RSVPEntities())
            {
                Guest guest = db.Guests.FirstOrDefault(x => x.FirstName == FirstName && x.LastName == LastName);

                //GuestDTO guestDTO = new GuestDTO
                //{
                //    GuestID = guest.GuestID,
                //    GuestGroupID = guest.GuestGroupID,
                //    FirstName = guest.FirstName,
                //    LastName = guest.LastName
                //};

                //return Ok(guestDTO);

                List<GuestEventJunction> guestEventJunction = db.GuestEventJunctions.Where(x => x.GuestID == guest.GuestID).ToList();

                GuestEventDTO guestEventDTO = new GuestEventDTO()
                {
                    GuestEventList = guestEventJunction.Select(x => x.EventID).ToList()
                };

                //return Ok(guestEventDTO);
                List<EventDTO> eventDTO = new List<EventDTO>();
                foreach (int eventx in guestEventDTO.GuestEventList)
                {
                    Event eventi = db.Events.FirstOrDefault(x => x.EventID == eventx);

                    eventDTO.Add( new EventDTO()
                    {
                        EventID = eventi.EventID,
                        Title = eventi.Title,
                        Subtitle = eventi.Subtitle,
                        Description = eventi.Description,
                        EventStartDate = eventi.EventStartDate.ToString("MMMM dd, yyyy"),
                        EventEndDate = eventi.EventEndDate.ToString("MMMM dd, yyyy"),
                        Venue = eventi.Venue,
                        Address = eventi.Address,
                        EventStartTime = eventi.EventStartTime.ToString(),
                        EventEndTime = eventi.EventEndTime.ToString(),
                        Details = eventi.Details
                    });
                }


                return Ok(eventDTO);

            }
        }

    }
}
