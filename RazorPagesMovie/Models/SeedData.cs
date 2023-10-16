using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Dune",
                    ReleaseDate = DateTime.Parse("2021-2-12"),
                    Genre = "Drama",
                    Price = 7.99M,
                    Rating = "PG-13"
                },

                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "PG"
                },

                new Movie
                {
                    Title = "The Hating Game",
                    ReleaseDate = DateTime.Parse("2022-2-23"),
                    Genre = "Romantic Comedy",
                    Price = 9.99M,
                    Rating = "PG-13"
                },

                new Movie
                {
                    Title = "Scream",
                    ReleaseDate = DateTime.Parse("1999-4-15"),
                    Genre = "Horror",
                    Price = 3.99M,
                    Rating = "PG-13"
                },

                new Movie
                {
                    Title = "Brave",
                    ReleaseDate = DateTime.Parse("2012-4-15"),
                    Genre = "Family",
                    Price = 3.99M,
                    Rating = "PG"
                }
            );
            context.SaveChanges();
        }
    }
}

