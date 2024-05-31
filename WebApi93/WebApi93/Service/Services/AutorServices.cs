using WebApi93.Context;

namespace WebApi93.Service.Services
{
    public class AutorServices
    {
        private readonly ApplicationDbContext _context;

        public AutorServices (ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
