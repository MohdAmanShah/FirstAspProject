using Microsoft.EntityFrameworkCore;
using Categories.Models;
namespace Categories.Data
{
    public class appdbcontext:DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options):base(options)
        {
            
        }
        public DbSet<Category> CateGories {  get; set; }    
    }
}