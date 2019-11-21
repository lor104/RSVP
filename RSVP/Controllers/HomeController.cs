using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSVP.Infrastucture.Data;
using RSVP.Infrastucture.Models.ViewModels;

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

                EventViewModel viewModel = new EventViewModel()
                {
                    Events = events,
                    Guests = guests
                };

                return View(viewModel);
            }
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