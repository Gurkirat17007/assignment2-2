namespace WebApplication5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>()
                .Property(e => e.Soccer)
                .IsFixedLength();

            modelBuilder.Entity<Sport>()
                .Property(e => e.Baseball)
                .IsFixedLength();

            modelBuilder.Entity<Sport>()
                .Property(e => e.Rugby)
                .IsFixedLength();

            

            modelBuilder.Entity<Team>()
                .Property(e => e.Girls)
                .IsFixedLength();

            modelBuilder.Entity<Team>()
                .Property(e => e.Kids)
                .IsFixedLength();

            modelBuilder.Entity<Team>()
                .Property(e => e.Old)
                .IsFixedLength();
        }
    }
}
