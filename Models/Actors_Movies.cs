namespace CinemaTicketManagementSystem.Models
{
    public class Actors_Movies
    {
   
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
    }
}
