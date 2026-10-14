using Microsoft.EntityFrameworkCore;
using Race_System.Models;

namespace Race_System.Data
{
    // Acts as the bridge between our C# code and our SQL Server database (ProgERD)
    public class Race_SystemDbContext : DbContext
    {
        public Race_SystemDbContext(DbContextOptions<Race_SystemDbContext> options) : base(options) { }

        // DbSet properties map directly to your existing tables in SSMS
        public DbSet<Event> Events => Set<Event>();
        public DbSet<RaceCategory> Categories => Set<RaceCategory>();
        public DbSet<EventRace> EventRaces => Set<EventRace>();
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<Registration> Registrations => Set<Registration>();
        public DbSet<Result> Results => Set<Result>();

        // Seeds initial sample data into our database to satisfy Part 1 feedback
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hash a default password for our seed participants/organisers
            string defaultPasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123!");

            // 1. Seed Participants (covering both Organisers and Participants)
            modelBuilder.Entity<Participant>().HasData(
                new Participant { ParticipantID = 1, FirstName = "Simphiwe", LastName = "Mkhize", DateOfBirth = new DateTime(1999, 5, 12), Email = "sim.sim@gmail.com", Phone = "0681237631", PasswordHash = defaultPasswordHash, Role = "Organiser" },
                new Participant { ParticipantID = 2, FirstName = "Julius", LastName = "Somizi", DateOfBirth = new DateTime(2000, 8, 24), Email = "somizij@gmail.com", Phone = "0789754432", PasswordHash = defaultPasswordHash, Role = "Organiser" },
                new Participant { ParticipantID = 3, FirstName = "Amahle", LastName = "Zulu", DateOfBirth = new DateTime(2005, 11, 3), Email = "amahle.zulu@gmail.com", Phone = "0846862214", PasswordHash = defaultPasswordHash, Role = "Participant" },
                new Participant { ParticipantID = 4, FirstName = "Bonga", LastName = "Mqandi", DateOfBirth = new DateTime(1998, 2, 17), Email = "bonga.m@gmail.com", Phone = "0671806529", PasswordHash = defaultPasswordHash, Role = "Participant" }
            );

            // 2. Seed Events (matching your SQL script)
            modelBuilder.Entity<Event>().HasData(
                new Event { EventID = 101, EventName = "Spring City Run", EventDate = new DateTime(2025, 4, 15), EventLocation = "Central Park", OrganizerName = "Metropolitan Sports Club" },
                new Event { EventID = 102, EventName = "Summer Trail Challenge", EventDate = new DateTime(2025, 7, 20), EventLocation = "Mountain Ridge Park", OrganizerName = "Trail Masters Association" },
                new Event { EventID = 103, EventName = "Autumn Night Dash", EventDate = new DateTime(2025, 10, 10), EventLocation = "Downtown Plaza", OrganizerName = "Metropolitan Sports Club" }
            );

            // 3. Seed Race Categories
            modelBuilder.Entity<RaceCategory>().HasData(
                new RaceCategory { CategoryID = 1, CategoryName = "5K Fun Run", Distance = 5, Category_description = "5 kilometer recreational run for all fitness levels" },
                new RaceCategory { CategoryID = 2, CategoryName = "10K Challenge", Distance = 10, Category_description = "10 kilometer intermediate road race" },
                new RaceCategory { CategoryID = 3, CategoryName = "Half Marathon", Distance = 21, Category_description = "21 kilometer long-distance endurance race" },
                new RaceCategory { CategoryID = 4, CategoryName = "Full Marathon", Distance = 42, Category_description = "42 kilometer full marathon event" }
            );

            // 4. Seed EventRaces (linking events to categories)
            modelBuilder.Entity<EventRace>().HasData(
                new EventRace { EventRaceID = 201, StartTime = new TimeSpan(8, 0, 0), MaxParticipants = 500, EventID = 101, CategoryID = 1 },
                new EventRace { EventRaceID = 202, StartTime = new TimeSpan(8, 30, 0), MaxParticipants = 300, EventID = 101, CategoryID = 2 },
                new EventRace { EventRaceID = 203, StartTime = new TimeSpan(7, 0, 0), MaxParticipants = 200, EventID = 102, CategoryID = 3 },
                new EventRace { EventRaceID = 204, StartTime = new TimeSpan(6, 0, 0), MaxParticipants = 150, EventID = 102, CategoryID = 4 }
            );

            // 5. Seed Registrations
            modelBuilder.Entity<Registration>().HasData(
                new Registration { RegistrationID = 301, Reg_Date = new DateTime(2025, 3, 1), BidNumber = 1001, PaymentStatus = "Paid", ParticipantID = 1, EventRaceID = 201 },
                new Registration { RegistrationID = 302, Reg_Date = new DateTime(2025, 3, 2), BidNumber = 1002, PaymentStatus = "Paid", ParticipantID = 2, EventRaceID = 201 },
                new Registration { RegistrationID = 303, Reg_Date = new DateTime(2025, 3, 5), BidNumber = 1003, PaymentStatus = "Paid", ParticipantID = 3, EventRaceID = 202 }
            );

            // 6. Seed Results
            modelBuilder.Entity<Result>().HasData(
                new Result { ResultID = 401, FinishTime = new TimeSpan(0, 22, 30), RankOverall = 1, RankInCategory = 1, RegistrationID = 301 },
                new Result { ResultID = 402, FinishTime = new TimeSpan(0, 23, 40), RankOverall = 2, RankInCategory = 2, RegistrationID = 302 }
            );
        }
    }
}