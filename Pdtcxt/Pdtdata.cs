using MediatorCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorCrud.Pdtcxt
{
    public class Pdtdata : DbContext
    {
        public Pdtdata(DbContextOptions<Pdtdata> options) : base(options)
        {
        }

        public DbSet<Pdt> Pdts { get; set; }
        public DbSet<ctgry> Ctgries { get;set; }

        protected override void OnModelCreating(ModelBuilder pdtmdl)
        {
            base.OnModelCreating(pdtmdl);

            pdtmdl.Entity<Pdt>()
                .HasOne(p => p.catgry)
                .WithMany(c => c.Pdts)
                .HasForeignKey(p => p.catgryId)
                .OnDelete(DeleteBehavior.Cascade);

            pdtmdl.Entity<ctgry>().HasData(
                new ctgry { catgryId=1,catgryNmae="Mobile"},
                new ctgry { catgryId = 2, catgryNmae = "Laptop" },
                new ctgry { catgryId = 3, catgryNmae = "TV" },
                new ctgry { catgryId = 4, catgryNmae = "Audio" }
            );
        }
    }
}
