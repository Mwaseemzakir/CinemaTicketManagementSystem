using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.Models
{
    public class Producer 
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; } // Producer can have multiple movies
    }
}
