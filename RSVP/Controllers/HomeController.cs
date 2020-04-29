using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSVP.Infrastucture.Data;
using RSVP.Infrastucture.Models.ViewModels;
using RSVP.Infrastucture.Models;
using System.Data.SqlTypes;

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
                    } else
                    {
                        //ModelState.AddModelError();
                    }
                }
            }
            return View(viewModel);
        }

        public ActionResult Reserve(int? guestId)
        {
            // Validation
            if (!guestId.HasValue || guestId == 0)
            {
                return RedirectToAction("RSVP");
            }

            // Find configuration for this user
            using (RSVPEntities db = new RSVPEntities())
            {
                Guest guest = db.Guests.FirstOrDefault(x => x.GuestID == guestId);
                ReservationViewModel viewModel = new ReservationViewModel();
                viewModel.FullName = guest.FirstName?.Trim() + " " + guest.LastName?.Trim();
                viewModel.ReplyList = guest.GuestEventJunctions.Select(x => x.Event).Select(x => new ReplyViewModel()
                {
                    Attending = null,
                    Event = x,
                    EventMeals = x.EventMeals.ToList()
                }).ToList();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Reserve(ReservationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Start validating submissions if accept or decline is clicked
                for (int i = 0; i < viewModel.ReplyList.Count; i++)
                {
                    if (viewModel.ReplyList[i].Attending.Value == true)
                    {
                        // Add errors for empty meals
                        if (!viewModel.ReplyList[i].SelectedMeal.HasValue)
                        {
                            ModelState.AddModelError("ReplyList[" + i + "].SelectedMeal", "Please select a meal!");
                        }
                    }
                }

                // Check if ModelState is valid once more after custom validation
                if (ModelState.IsValid)
                {
                    // Massage data
                    viewModel.AttendeeEmail = viewModel.AttendeeEmail.Trim();

                    // Begin reply insertions
                    using (RSVPEntities db = new RSVPEntities())
                    {
                        // Create each reply
                        foreach (var reply in viewModel.ReplyList)
                        {
                            Reply newReply = new Reply();
                            newReply.AtendeeEmail = viewModel.AttendeeEmail;
                            newReply.Attending = reply.Attending.Value;

                            // If user is attending this event then add the rest
                            if (reply.Attending.Value == true)
                            {
                                newReply.MealId = reply.SelectedMeal;
                                newReply.Notes = reply.Notes;
                                newReply.NeedParking = reply.NeedParking;
                            }
                            db.Replies.Add(newReply);
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Confirmation");
                }
            }

            // If there are any errors then recreate lists and return to page
            using (RSVPEntities db = new RSVPEntities())
            {
                Guest guest = db.Guests.FirstOrDefault(x => x.GuestID == viewModel.GuestId);
                viewModel.ReplyList = guest.GuestEventJunctions.Select(x => x.Event).Select(x => new ReplyViewModel()
                {
                    Event = x,
                    EventMeals = x.EventMeals.ToList()
                }).ToList();
            }

            return View(viewModel);
        }

        public ActionResult Confirmation()
        {
            return View();
        }
        #endregion
    }
}