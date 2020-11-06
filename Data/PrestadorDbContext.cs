using Microsoft.EntityFrameworkCore;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class PrestadorDbContext : DbContext
    {
        public DbSet<Prestador> Prestadores { get; set; }
    }
}
