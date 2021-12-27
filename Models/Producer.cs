using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.Models
{
    public class Producer 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "Enter Name Please")]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "About")]
        [Required(ErrorMessage = "Enter Bio Please")]
        public string Bio { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Select Country Please")]
        public string Country { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; } // Producer can have multiple movies
    }
}
