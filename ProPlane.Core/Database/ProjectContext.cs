﻿using ProPlane.Core.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace ProPlane.Core.Database
{
    public class ProjectContext : DbContext
    {
        private const string DBCONNECTION = "Server=DESKTOP-9QI02R2\\LOCALSQLSERVER;Database=ProPlaneDB;Integrated Security=sspi";

        public DbSet<Project> Projects { get; set; }
        public DbSet<Feature> Features { get; set; }

        public ProjectContext()
        {
            Database.EnsureDeleted();
            Trace.WriteLine("Datenbank gelöscht.");
            Database.EnsureCreated();
            Trace.WriteLine("Datenbank erstellt.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBCONNECTION);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityConfig());
        }
    }
}