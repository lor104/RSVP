using System;
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
        #region Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Directions()
        {
            return View();
        }

        public ActionResult Accomodations()
        {
            return View();
        }
        public ActionResult Registry()
        {
            return View();
        }
        #endregion

        #region Registration
        public ActionResult RSVP()
        {
            AuthenticationViewModel viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RSVP(AuthenticationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Massage data
                viewModel.FirstName = viewModel.FirstName.Trim();
                viewModel.LastName = viewModel.LastName.Trim();

                using (RSVPEntities db = new RSVPEntities())
                {
                    // Try to find guest based on first/last names
                    Guest guest = db.Guests.FirstOrDefault(x => x.FirstName == viewModel.FirstName && x.LastName == viewModel.LastName);

                    // If the guest can be found and they havent registered for any event then continue
                    if (guest != null && guest.GuestEventJunctions.Count(x => x.RepliesID == null) > 0)
                    {
                        return RedirectToAction("Reserve", new { guestId = guest.GuestID });
                    }
                }
            }
            return View(viewModel);
        }

        public ActionResult Reserve(int guestId)
        {
            // Validation
            if (guestId != 0)
            {
                return RedirectToAction("RSVP");
            }

            // Find configuration for this user
            using (RSVPEntities db = new RSVPEntities())
            {
                Guest guest = db.Guests.FirstOrDefault(x => x.GuestID == guestId);
                ReservationViewModel viewModel = new ReservationViewModel();

                //viewModel.MealList = 
                viewModel.EventList = guest.GuestEventJunctions.Select(x => x.Event).ToList().Select(x => x.Title).ToList();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Reserve(ReservationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Return them to confirmation page
                //return View();
            }
            return View(viewModel);
        }
        #endregion
    }
}