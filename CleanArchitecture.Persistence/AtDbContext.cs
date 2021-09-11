using CleanArchitecture.Application.Common.Models.Seeds;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.User;

namespace CleanArchitecture.Persistence
{
    public class AtDbContext : DbContext, IAtDbContext
    {
        public AtDbContext(DbContextOptions<AtDbContext> options) : base(options)
        {

        }

        #region Person
        public DbSet<Person> Persons { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAtDbContext).Assembly);

            #region Seed

            #region Person
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "file.txt");
            using (StreamReader r = new StreamReader(filePath))
                    {
                        string json = r.ReadToEnd();
                        List<ParsedPerson> items = JsonConvert.DeserializeObject<List<ParsedPerson>>(json);
                        foreach (var item in items)
                        {
                            modelBuilder.Entity<Person>()
                                        .HasData(new Person
                                        {
                                            Id = item.id,
                                            Name = item.name,
                                            Username = item.username,
                                            Email = item.email,
                                            Password = new Random().Next(100000, 1000000).ToString(),
                                            Active = true,
                                            Deleted = false,
                                        });
                        }
                        modelBuilder.Entity<Person>(s =>
                        {
                            s.HasData(new Person
                            {
                                Id = items.Count + 1,
                                Name = "Default User",
                                Username = "ozgrrr",
                                Email = "ozgrrr@mail.com",
                                Password = "123123123",
                                Active = true,
                                Deleted = false,
                            });
                            s.Property(i => i.Id).HasIdentityOptions(startValue: items.Count + 2);
                        });
                    }
                #endregion

            #endregion

            #region Indexes

                #region Person
                modelBuilder.Entity<Person>().HasIndex(x => new { x.Username, x.Email, x.Active, x.Deleted }).IsUnique();
                #endregion

            #endregion

        }
    }
}
