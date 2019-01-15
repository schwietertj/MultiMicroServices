using System;
using Microsoft.EntityFrameworkCore;
using MicroServicesDataModels.Models;
using Attribute = MicroServicesDataModels.Models.Attribute;

namespace MicroServicesDataModels.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonAttribute> PersonAttributes { get; set; }
        public DbSet<PersonEvent> PersonEvents { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Set default active value
            builder.Entity<Attribute>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<Event>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<Link>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<Person>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<PersonAttribute>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<PersonEvent>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<Attribute>().Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Event>().Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Link>().Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Person>().Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<PersonAttribute>().Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<PersonEvent>().Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);

            // Attribute
            builder.Entity<Attribute>().HasIndex(x => x.Name).IsUnique();

            // Event
            builder.Entity<Event>().HasIndex(x => x.EventDate).IsUnique(false);

            // Link
            builder.Entity<Link>().HasIndex(x => new { x.EventId, x.Url }).IsUnique(false);
            builder.Entity<Link>().HasIndex(x => new { x.Url }).IsUnique(false);

            // Person
            builder.Entity<Person>().HasIndex(x => new { x.Name }).IsUnique(false);

            // Person Attribute
            builder.Entity<PersonAttribute>().HasIndex(x => new { x.PersonId, x.AttributeId }).IsUnique(false);

            // Person Attribute
            builder.Entity<PersonEvent>().HasIndex(x => new { x.PersonId, x.EventId }).IsUnique(true);

            base.OnModelCreating(builder);
        }

    }
}
