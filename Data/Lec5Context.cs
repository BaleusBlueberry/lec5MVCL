using System.ComponentModel.DataAnnotations;
using lec5MVCL.Models;
using Microsoft.EntityFrameworkCore;
namespace lec5MVCL.Data;

public class Lec5Context(DbContextOptions<Lec5Context> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<Capital> Capitals { get; set; } = default!;
    public DbSet<Song> Songs { get; set; } = default!;
    public DbSet<Album> Alboms { get; set; } = default!;
    public DbSet<Movie> Movie { get; set; } = default!;
    public DbSet<Genre> Genre { get; set; } = default!;
    public DbSet<MovieGenres> MovieGenres { get; set; } = default!;
}
/*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies).UsingEntity<MovieGenres>();
    }
}*/

[PrimaryKey("MoviesId", "GenresId")]
public class MovieGenres
{
    public int MoviesId { get; set; }
    public int GenresId { get; set; }
}
