using Microsoft.EntityFrameworkCore;

namespace Mission6_Vestergaard_new.Models;

public class MovieCollectionContext: DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
        
    }
    
    public DbSet<Application> Applications { get; set; }
}