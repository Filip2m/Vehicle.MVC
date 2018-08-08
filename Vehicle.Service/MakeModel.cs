namespace Vehicle.Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MakeModel : DbContext
    {
        public MakeModel()
            : base("name=MakeModel")
        {
        }

        public virtual DbSet<Make> Make { get; set; }
        public virtual DbSet<Model> Model { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>()
                .Property(e => e.MakeName)
                .IsUnicode(false);

            modelBuilder.Entity<Make>()
                .Property(e => e.abrv)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.abrv)
                .IsUnicode(false);
        }
    }
}
