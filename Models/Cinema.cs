using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema Name")]
        [Required (ErrorMessage ="Cinema Name is required")]
        public string Name { get; set; }
        public string Logo { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
