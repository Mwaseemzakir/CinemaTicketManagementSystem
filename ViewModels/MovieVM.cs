using CinemaTicketManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name Please")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Description Please")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Price Please")]
        public double Price { get; set; }
        [Display(Name = "Logo")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Select Start Date Please")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Select End Date Please")]

        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Select Category Please")]
        public MoviesCategoryEnum MovieCategory { get; set; }

        [Required(ErrorMessage = "Select atleast one actor ")]

        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Select Cinema Please")]
        public int CinemaId { get; set; }
       
        [Required(ErrorMessage = "Select Producer Please")]
        public int ProducerId { get; set; }
      

        
    }
}
