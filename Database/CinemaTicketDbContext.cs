using CinemaTicketManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace CinemaTicketManagementSystem.Database
{
    public class CinemaTicketDbContext : DbContext
    {
        public CinemaTicketDbContext(DbContextOptions<CinemaTicketDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Actors_Movies>().HasKey(am => new {
                am.ActorId,
                am.MovieId
            });
            
            model.Entity<Actors_Movies>().HasOne(mov => mov.Movie).WithMany(am => am.ActorsMovies).HasForeignKey(fk => fk.MovieId);
            model.Entity<Actors_Movies>().HasOne(act => act.Actor).WithMany(am => am.ActorsMovies).HasForeignKey(fk => fk.ActorId);

            base.OnModelCreating(model);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actors_Movies> Actors_Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}
