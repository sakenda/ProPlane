using ProPlane.Core.Entity;
using System;
using System.Collections.Generic;

namespace ProPlane.Core.Database
{
    public static class DatabaseSeed
    {
        public static void Seed(this ProjectContext context)
        {
            var feature1 = new Feature { Name = "Feature 1", Description = "Beschreibung Projekt 1" };
            var feature2 = new Feature { Name = "Feature 2", Description = "Beschreibung Projekt 1" };
            var feature3 = new Feature { Name = "Feature 3", Description = "Beschreibung Projekt 1" };
            var feature4 = new Feature { Name = "Feature 4", Description = "Beschreibung Projekt 1" };
            var feature5 = new Feature { Name = "Feature 1", Description = "Beschreibung Project 2" };
            var feature6 = new Feature { Name = "Feature 2", Description = "Beschreibung Project 2" };
            var feature7 = new Feature { Name = "Feature 1", Description = "Beschreibung Projekt 3" };
            var feature8 = new Feature { Name = "Feature 1", Description = "Beschreibung Projekt 4" };
            var feature9 = new Feature { Name = "Feature 2", Description = "Beschreibung Projekt 4" };
            var feature10 = new Feature { Name = "Feature 3", Description = "Beschreibung Projekt 4" };
            var feature11 = new Feature { Name = "Feature 4", Description = "Beschreibung Projekt 4" };
            var feature12 = new Feature { Name = "Feature 5", Description = "Beschreibung Projekt 4" };
            var feature13 = new Feature { Name = "Feature 6", Description = "Beschreibung Projekt 4" };

            var project1 = new Project
            {
                Name = "Projekt 1",
                Description = "Beschreibung zu Projekt 1. Test Text Test Text Test Text Test Text Test Text ",
                Created = DateTime.Now,
                LastEdit = DateTime.Now,
                Features = new List<Feature>()
                    {
                        feature1,
                        feature2,
                        feature3,
                        feature4
                    }
            };
            var project2 = new Project
            {
                Name = "Projekt 2",
                Description = "Beschreibung zu Projekt 2",
                Created = DateTime.Now,
                LastEdit = DateTime.Now,
                Features = new List<Feature>()
                    {
                        feature5,
                        feature6
                    }
            };
            var project3 = new Project
            {
                Name = "Projekt 3",
                Description = "Beschreibung zu Projekt 3",
                Created = DateTime.Now,
                LastEdit = DateTime.Now,
                Features = new List<Feature>()
                    {
                        feature7
                    }
            };
            var project4 = new Project
            {
                Name = "Projekt 4",
                Description = "Beschreibung zu Projekt 4",
                Created = DateTime.Now,
                LastEdit = DateTime.Now,
                Features = new List<Feature>()
                    {
                        feature8,
                        feature9,
                        feature10,
                        feature11,
                        feature12,
                        feature13
                    }
            };

            context.Features.Add(feature1);
            context.Features.Add(feature2);
            context.Features.Add(feature3);
            context.Features.Add(feature4);
            context.Features.Add(feature5);
            context.Features.Add(feature6);
            context.Features.Add(feature7);
            context.Features.Add(feature8);
            context.Features.Add(feature9);
            context.Features.Add(feature10);
            context.Features.Add(feature11);
            context.Features.Add(feature12);
            context.Features.Add(feature13);

            context.Projects.Add(project1);
            context.Projects.Add(project2);
            context.Projects.Add(project3);
            context.Projects.Add(project4);

            context.SaveChanges();
        }
    }
}