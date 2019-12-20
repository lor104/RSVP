using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSVP.Infrastucture.Models.ViewModels
{
    public class RespondViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Atendee Email")]
        public string AtendeeEmail { get; set; }

        [Required(ErrorMessage = "Response is required")]
        [Display(Name = "Attending")]
        public bool Attending { get; set; }

        [Required(ErrorMessage = "Meal Selection is required")]
        [Display(Name = "MealSelection")]
        public string MealSelection { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "NeedParking")]
        public bool NeedParking { get; set; }
    }
}