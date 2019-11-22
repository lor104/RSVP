﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSVP.Infrastucture.Data;
using RSVP.Infrastucture.Models.ViewModels;
using RSVP.Infrastucture.Models;

namespace RSVP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (RSVPEntities db = new RSVPEntities())
            {
                //Event firstEvent = db.Events.FirstOrDefault(x => x.Details != null && x.Description != null);

                List<Event> events = db.Events.ToList();
                List<Guest> guests = db.Guests.ToList();
                List<GuestEventJunction> guestEventJunctions = db.GuestEventJunctions.ToList();

                EventViewModel viewModel = new EventViewModel()
                {
                    Events = events,
                    Guests = guests,
                    GuestEventJunctions = guestEventJunctions
                };

                return View(viewModel);
            }
        }

        public ActionResult RSVP()
        {
            InviteViewModel viewModel = new InviteViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RSVP(InviteViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (RSVPEntities db = new RSVPEntities())
                {
                    Guest guest = db.Guests.FirstOrDefault(x => x.FirstName == model.FirstName && x.LastName == model.LastName);

                    if (guest != null)
                    {
                        // Create the reply object
                        Reply mynewRSVP = new Reply();
                        mynewRSVP.AtendeeEmail = model.AtendeeEmail;
                        mynewRSVP.Attending = model.Attending;

                        //guest.GuestID
                        //guest.RepliesID

                        GuestEventJunction guestEventJunction = db.GuestEventJunctions.FirstOrDefault(x => x.GuestID == guest.GuestID);

                        // Insert the reply object in order to associate it to the dbContext (dbcontext is used to keep track of objects)
                        db.Replies.Add(mynewRSVP);

                        db.SaveChanges();

                        // Associate the guest to the reply
                        Reply reply = db.Replies.FirstOrDefault(x => x.RepliesID == mynewRSVP.RepliesID);
                        guestEventJunction.RepliesID = reply.RepliesID;

                        // Push changes to sql server via db.savechanges()
                        db.SaveChanges();
                    }

                }

            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}