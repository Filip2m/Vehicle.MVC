namespace Vehicle.Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    
    

    public partial class VehicleContext : DbContext
    {
        public VehicleContext()
            : base("name=MakeModel")
        {
            
        }

        public virtual DbSet<VehicleMake> Makes { get; set; }
        public virtual DbSet<VehicleModel> Models { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.Abrv)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.Abrv)
                .IsUnicode(false);
        }

       









        //public System.Data.Entity.DbSet<Vehicle.MVC.Models.VehicleMakeModelView> VehicleMakeModelViews { get; set; }
    }
}
