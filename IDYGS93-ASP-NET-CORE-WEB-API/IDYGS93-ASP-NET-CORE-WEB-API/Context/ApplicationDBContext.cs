using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace IDYGS93_ASP_NET_CORE_WEB_API.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base (options)
        { }

        //Modelos a mapear 
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
