using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSVP.Infrastucture.Models.ViewModels
{
    public class ReservationViewModel
    {
        public string FullName { get; set; }

        public List<string> MealList { get; set; }

        public List<string> EventList { get; set; }

        [Required(ErrorMessage = "Email is required, we hope we won't need it, but in case we need to get in touch with you, we'd like to have it!")]
        [Display(Name = "Atendee Email")]
        public string AtendeeEmail { get; set; }

        [Required(ErrorMessage = "Response is required")]
        [Display(Name = "Attending")]
        public bool Attending { get; set; }

        [Required(ErrorMessage = "Meal Selection is required")]
        [Display(Name = "Meal Selection")]
        public int MealSelection { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Need Parking?")]
        public bool NeedParking { get; set; }
    }
}