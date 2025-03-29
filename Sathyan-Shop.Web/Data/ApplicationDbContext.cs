using Microsoft.EntityFrameworkCore;
using Sathyan_Shop.Web.Models;

namespace Sathyan_Shop.Web.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category>categories { get; set; }
    }
}
