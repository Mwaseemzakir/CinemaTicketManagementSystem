using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketManagementSystem.Models
{
    public class OrderItem
    {
        [Key] //Indication of Primary Key
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        //We don't need to mention that MovieId is the foriegn key , It make sense for it when we use name MovieId
        public int MovieId { get; set; } 
        public virtual Movie Movie { get; set; }
        //Below is the example if you want to define Foriegn Key on your own then we can define like this

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }


    }
}
