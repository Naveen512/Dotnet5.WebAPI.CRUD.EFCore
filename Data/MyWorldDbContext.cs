using Dotnet5.API.CRUD.EF.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.API.CRUD.EF.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {
 
        }
        public DbSet<Gadgets> Gadgets { get; set; }

        
    }
}