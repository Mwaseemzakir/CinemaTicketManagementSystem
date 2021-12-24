﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketManagementSystem.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema Name")]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
