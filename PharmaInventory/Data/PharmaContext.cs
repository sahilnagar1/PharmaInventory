using Microsoft.EntityFrameworkCore;
using PharmaInventory.Models;

namespace PharmaInventory.Data
{
   
    public class PharmaContext : DbContext
    {
        public PharmaContext(DbContextOptions<PharmaContext> options) : base(options)
        {
        }

       
        public DbSet<Drug> Drugs { get; set; }
    }
}