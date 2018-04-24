using TesteDotNet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TesteDotNet.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>();



            modelBuilder.Entity<Item>();
   
        }



    }
}
