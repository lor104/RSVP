using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RSVP.Infrastucture.Data;

namespace RSVP.Infrastucture.Models.ViewModels
{
    public class ReservationViewModel
    {
        public string FullName { get; set; }

        public int GuestId { get; set; }

        [Required(ErrorMessage = "Email is required, we hope we won't need it, but in case we need to get in touch with you, we'd like to have it!")]
        [Display(Name = "Attendee Email")]
        public string AttendeeEmail { get; set; }

        #region Recurring fields per event
        public List<ReplyViewModel> ReplyList { get; set; }
        #endregion
    }

    public class ReplyViewModel
    {
        public Event Event { get; set; }

        public List<EventMeal> EventMeals { get; set; }

        [Required(ErrorMessage = "Response is required")]
        public bool? Attending { get; set; }

        [Display(Name = "Please select your meal")]
        public int? SelectedMeal { get; set; }

        [Display(Name = "Do you have any dietary restrictions?")]
        public string Notes { get; set; }

        [Display(Name = "Need Parking?")]
        public bool NeedParking { get; set; }
    }
}