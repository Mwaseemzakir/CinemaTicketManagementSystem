using CinemaTicketManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketManagementSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name Please")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 30 characters")]
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        [Display(Name = "Logo")]
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MoviesCategoryEnum MovieCategory { get; set; }

        #region Relationships 
        public List<Actors_Movies> ActorsMovies { get; set; }

        //CinemaId is FK here we have def
        [ForeignKey("CinemaId")]

        [Required(ErrorMessage = "Select Cinema Please")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }


        //Producer
        [ForeignKey("ProducerId")]
        [Required(ErrorMessage = "Select Producer Please")]
        public int ProducerId { get; set; }
        public Producer Producer{ get; set; }

        #endregion
    }
}
