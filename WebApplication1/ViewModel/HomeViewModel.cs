using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class HomeViewModel
    {
        public DbSet<Service>Services { get; set; }
    }
}
