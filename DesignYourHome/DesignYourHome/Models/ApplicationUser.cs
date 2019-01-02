using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DesignYourHome.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

       


        // Set up PK -> FK relationships to other objects
        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Contractor> Contractors { get; set; }

        public virtual ICollection<FixHome> FixHome { get; set; }
    }
}