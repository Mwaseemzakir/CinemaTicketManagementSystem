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
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "About")]

        public string Bio { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; } // Producer can have multiple movies
    }
}
