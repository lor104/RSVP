using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSVP.Infrastucture.Models.ViewModels
{
    public class AuthenticationViewModel
    {
        [Required(ErrorMessage = "First name is super duper required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is super duper required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string ErrorMessage { get; set; }
    }
}