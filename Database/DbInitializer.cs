using CinemaTicketManagementSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketManagementSystem.Database
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CinemaTicketDbContext>();
                context.Database.EnsureCreated();
                if (!context.Cinemas.Any())
                {
                    List<Cinema> cinemas = new List<Cinema>() {
                        new Cinema() {
                            Name = "Universal Cinema",
                            Logo = "https://www.google.com/maps/uv?pb=!1s0x393b34b392733b3f%3A0x92838560f189fcf4!3m1!7e115!4shttps%3A%2F%2Flh5.googleusercontent.com%2Fp%2FAF1QipMxxn_QvWxPqgqq7tIHQQc7Le4nWpZU6QEUQcFm%3Dw266-h200-k-no!5suniversal%20cinema%20multan%20-%20Google%20Search!15sCgIgAQ&imagekey=!1e10!2sAF1QipMxxn_QvWxPqgqq7tIHQQc7Le4nWpZU6QEUQcFm&hl=en&sa=X&ved=2ahUKEwjpqP-N6fL0AhUNy6QKHR4xB88Qoip6BAggEAM",
                            Description = "This is Description"
                        }
                    };

                    context.Cinemas.AddRange(cinemas);
                    context.SaveChanges();
                }
                if (!context.Actors.Any())
                {
                    List<Actor> actors = new List<Actor>() {
                        new Actor() {
                            FullName =  "Amir Khan",
                            ProfilePictureUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fakm-img-a-in.tosshub.com%2Findiatoday%2Fimages%2Fstory%2F202111%2F964609-aamirkhan-socialmedia.jpg%3Fsqx_s6Fzu3kV6.liN7BrYoZG5MX.At4F%26size%3D770%3A433&imgrefurl=https%3A%2F%2Fwww.indiatoday.in%2Fmovies%2Fcelebrities%2Fstory%2Faamir-khan-s-third-wedding-rumours-are-fake-source-1879593-2021-11-22&tbnid=Szr3YM6NY-cQMM&vet=12ahUKEwjw0vft6_L0AhUDNxoKHZiXBBkQMygCegUIARDTAQ..i&docid=taUxPJFKfyRr9M&w=770&h=433&itg=1&q=amir%20khan&ved=2ahUKEwjw0vft6_L0AhUDNxoKHZiXBBkQMygCegUIARDTAQ",
                            Bio = "Comes with new Ideas",
                            Country = "India"
                        }
                    };
                    context.Actors.AddRange(actors);
                    context.SaveChanges();
                }
                if (!context.Producers.Any())
                {
                    List<Producer> producers = new List<Producer>() {
                        new Producer() {
                            FullName =  "Vidhu Vinod Chopra",
                            ProfilePictureUrl = "data:image/jpeg;base64,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",
                            Bio = "Blockbuster Movies"
                        }
                    };
                    context.Producers.AddRange(producers);
                    context.SaveChanges();
                }
                if (!context.Movies.Any())
                {
                    List<Movie> movies = new List<Movie>() {
                        new Movie() {
                           Name = "3 Idiots",
                           ProducerId = 1,
                           Price = 600,
                           MovieCategory = Enums.MovieCtegoryEnum.Drama,
                           Description = "Tale of 3 friends",
                           StartDate = System.DateTime.Now.AddDays(-10),
                           EndDate = System.DateTime.Now.AddDays(-2),
                           CinemaId = 1,
                           ImageURL ="https://upload.wikimedia.org/wikipedia/en/d/df/3_idiots_poster.jpg"

                        }
                    };
                    context.Movies.AddRange(movies);
                    context.SaveChanges();
                }
                if (!context.Actors_Movies.Any())
                {

                }
            }
        }
    }
}
