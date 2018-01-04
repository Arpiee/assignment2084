namespace Assignment_2.Models
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

        public virtual DbSet<phone> phones { get; set; }
        public virtual DbSet<phones1> phones1 { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<phone>()
                .Property(e => e.phones)
                .IsUnicode(false);

            modelBuilder.Entity<phone>()
                .Property(e => e.models)
                .IsUnicode(false);

            modelBuilder.Entity<phone>()
                .HasMany(e => e.phones1)
                .WithRequired(e => e.phone)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phones1>()
                .Property(e => e.phones)
                .IsUnicode(false);

            modelBuilder.Entity<phones1>()
                .Property(e => e.models)
                .IsUnicode(false);

            modelBuilder.Entity<phones1>()
                .Property(e => e.condition)
                .IsUnicode(false);
        }
    }
}
