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
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCtegoryEnum MovieCategory { get; set; }

        #region Relationships 
        public List<Actors_Movies> ActorsMovies { get; set; }

        //Cinema
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }
        public List<Cinema> Cinema { get; set; }

        //Producer
        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }
        public List<Producer> Producer{ get; set; }
        #endregion
    }
}
