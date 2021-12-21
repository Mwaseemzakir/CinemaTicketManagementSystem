using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.Models
{
    public class Actor 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture Url")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public List<Actors_Movies> ActorsMovies { get; set; }

    }
}
 