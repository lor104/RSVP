using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RSVP.Infrastucture.Data;
using System.Security.Cryptography.X509Certificates;

namespace RSVP.Infrastucture.Models.ViewModels
{
    public class ReservationViewModel
    {
        public GuestViewModel Guest { get; set; }

        [Required(ErrorMessage = "Email is required, we hope we won't need it, but in case we need to get in touch with you, we'd like to have it!")]
        [Display(Name = "Attendee Email")]
        public string AttendeeEmail { get; set; }
        public bool? IsBringingGuest { get; set; }
        [Display(Name ="Guest First Name")]
        public string GuestFirstName { get; set; }
        [Display(Name = "Guest Last Name")]
        public string GuestLastName { get; set; }

        #region Recurring fields per event
        public List<ReplyViewModel> ReplyList { get; set; }
        #endregion
    }

    public class ReplyViewModel
    {
        public EventViewModel Event { get; set; }

        public List<EventMeal> EventMeals { get; set; }

        [Required(ErrorMessage = "Response is required")]
        public bool? Attending { get; set; }

        [Display(Name = "Please select your meal")]
        public int? SelectedMeal { get; set; }

        [Display(Name = "Do you have any dietary restrictions?")]
        public string Notes { get; set; }

        public string LicensePlate { get; set; }
    }

    public class EventViewModel
    {
        public EventViewModel(Event eventData)
        {
            EventId = eventData.EventID;
            StartDate = eventData.EventStartDate;
            Title = eventData.Title;
            Subtitle = eventData.Subtitle;
            Venue = eventData.Venue;
        }

        public EventViewModel()
        {

        }

        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Venue { get; set; }
    }

    public class GuestViewModel
    {
        public GuestViewModel(Guest guestData)
        {
            GuestId = guestData.GuestID;
            IsChild = guestData.IsChild;
            FirstName = guestData.FirstName;
            LastName = guestData.LastName;
            CanBringGuest = guestData.CanBringGuest;
        }

        public GuestViewModel()
        {

        }

        public string FullName
        {
            get
            {
                return FirstName?.Trim() + " " + LastName?.Trim();
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GuestId { get; set; }

        public bool IsChild { get; set; }

        public bool CanBringGuest { get; set; }
    }
}