using FreePlace.API.Booking.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FreePlace.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Parking> Parkings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booked> Bookings { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public AppDbContext(DbContextOptions options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Parking Entity Mapping
        builder.Entity<Parking>().ToTable("Parking");
        builder.Entity<Parking>().HasKey(p => p.Id);
        builder.Entity<Parking>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Parking>().Property(p => p.Capacity).IsRequired();
        builder.Entity<Parking>().Property(p => p.Description).IsRequired().HasMaxLength(250);
        builder.Entity<Parking>().Property(p => p.Ubication).IsRequired().HasMaxLength(100);
        builder.Entity<Parking>().Property(p => p.Price).IsRequired();

        // Car Entity Mapping
        builder.Entity<Car>().ToTable("Cars");
        builder.Entity<Car>().HasKey(p => p.Id);
        builder.Entity<Car>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(p => p.Plate).IsRequired().HasMaxLength(10);
        builder.Entity<Car>().Property(p => p.ParkedTime).IsRequired();

        // User Entity Mapping
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(40);
        builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(40);
        builder.Entity<User>().Property(p => p.Age).IsRequired();
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Username).IsRequired();
        builder.Entity<User>().Property(p => p.TypeAccount).IsRequired();
        builder.Entity<User>().Property(p => p.Suscribed).IsRequired();

        //Booking Entity Mapping
        builder.Entity<Booked>().ToTable("Bookings");
        builder.Entity<Booked>().HasKey(p => p.Id);
        builder.Entity<Booked>().Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Booked>().Property(p => p.StartDate).IsRequired();
        builder.Entity<Booked>().Property(p => p.EndDate).IsRequired();
        builder.Entity<Booked>().Property(p => p.Status).IsRequired();

        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p => p.Id);
        builder.Entity<Review>().Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p => p.Comment).IsRequired();
        builder.Entity<Review>().Property(p => p.likes).IsRequired();
        builder.Entity<Review>().Property(p => p.dislikes).IsRequired();

        builder.Entity<Payment>().Property("Payments");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.User).IsRequired();
        builder.Entity<Payment>().Property(p => p.Description).IsRequired().HasMaxLength(100);

        //Relationships
        builder.Entity<Parking>().HasMany(p => p.Cars)
            .WithOne(p => p.Parking)
            .HasForeignKey(p => p.ParkingId);
        builder.Entity<Parking>().HasMany(p => p.Bookings)
            .WithOne(p => p.Parking)
            .HasForeignKey(p => p.ParkingId);
        builder.Entity<Parking>().HasMany(p => p.Reviews)
            .WithOne(p => p.Parking)
            .HasForeignKey(p => p.ParkingId);
        builder.Entity<User>().HasMany(p => p.Cars)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<User>().HasMany(p => Parkings)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<User>().HasMany(p => p.Bookings)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<User>().HasMany(p => p.Reviews)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<Car>().HasOne(p => p.Parking)
            .WithOne(p => p.Car);
        builder.Entity<Car>().HasOne(p => p.User)
            .WithOne(p => p.Car);


    }
    
}