namespace Ass2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnections")
        {
        }

        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<cars_2> cars_2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>()
                .Property(e => e.CarID)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .Property(e => e.Models)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .HasMany(e => e.cars_2)
                .WithRequired(e => e.car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cars_2>()
                .Property(e => e.Cars)
                .IsUnicode(false);

            modelBuilder.Entity<cars_2>()
                .Property(e => e.VehNo)
                .IsUnicode(false);
        }
    }
}
