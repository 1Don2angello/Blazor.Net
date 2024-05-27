using Microsoft.EntityFrameworkCore;
using WebApiPersona.Models;
namespace WebApiPersona.Context
{
    public class AppDbContext: DbContext
    {
        
        public AppDbContext(DbContextOptions  <AppDbContext> options): base(options) 
        {
            
        } 
        public DbSet <Person> Persons { get; set; }
    }
}
