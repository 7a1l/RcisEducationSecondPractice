using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Garage.Models
{
    public partial class gr612_fepolContext : DbContext
    {
        public gr612_fepolContext()
        {
        }

        public gr612_fepolContext(DbContextOptions<gr612_fepolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverRightsCategory> DriverRightsCategories { get; set; }
        public virtual DbSet<Itinerary> Itineraries { get; set; }
        public virtual DbSet<RightsCategory> RightsCategories { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<TypeCar> TypeCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=10.30.0.137;Port=5432;Database=gr612_fepol;Username=gr612_fepol;Password=Raz93pimzc");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.HasIndex(e => e.state_number, "car_state_number_key")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.id_type_car).HasColumnName("id_type_car");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.number_passengers).HasColumnName("number_passengers");

                entity.Property(e => e.state_number)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("state_number");

                entity.HasOne(d => d.type_car)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.id_type_car)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("car_id_type_car_fkey");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.first_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.last_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<DriverRightsCategory>(entity =>
            {
                entity.HasKey(e => new { e.id_driver, e.id_rights_category })
                    .HasName("driver_rights_category_pkey");

                entity.ToTable("driver_rights_category");

                entity.Property(e => e.id_driver).HasColumnName("id_driver");

                entity.Property(e => e.id_rights_category).HasColumnName("id_rights_category");

                entity.HasOne(d => d.id_driver_navigation)
                    .WithMany(p => p.driver_rights_categories)
                    .HasForeignKey(d => d.id_driver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("driver_rights_category_id_driver_fkey");

                entity.HasOne(d => d.id_rights_category_navigation)
                    .WithMany(p => p.driver_rights_categories)
                    .HasForeignKey(d => d.id_rights_category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("driver_rights_category_id_rights_category_fkey");
            });

            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.ToTable("itinerary");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RightsCategory>(entity =>
            {
                entity.ToTable("rights_category");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("route");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.id_car).HasColumnName("id_car");

                entity.Property(e => e.id_driver).HasColumnName("id_driver");

                entity.Property(e => e.id_itinerary).HasColumnName("id_itinerary");

                entity.Property(e => e.number_passengers).HasColumnName("number_passengers");

                entity.HasOne(d => d.idCarNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.id_car)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_car_fkey");

                entity.HasOne(d => d.id_driver_navigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.id_driver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_driver_fkey");

                entity.HasOne(d => d.id_itinerary_navigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.id_itinerary)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_itinerary_fkey");
            });

            modelBuilder.Entity<TypeCar>(entity =>
            {
                entity.ToTable("type_car");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
