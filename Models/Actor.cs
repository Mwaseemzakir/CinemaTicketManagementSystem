using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.Models
{
    public class Actor 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Full Name is required")]
        [StringLength(30,MinimumLength = 5,ErrorMessage ="Name should be between 5 and 30 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
        [Required(ErrorMessage = "Select Country Please")]
        public string Country { get; set; }
        public List<Actors_Movies> ActorsMovies { get; set; }

    }
}
 