using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.Data
{
    public static class SeedData
    {

        public static void Generate(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Kui andmed juba olemas, siis välju
            if (context.Cars.Any() || context.Workers.Any())
                return;

            // Call all seeding methods in the correct order
            SeedWorkers(context);
            SeedCars(context);
            SeedCarCares(context);
            SeedRepairs(context);
            SeedCarDisplacements(context);
            SeedOperations(context);
            SeedWashes(context);

            // Final save to ensure all changes are persisted
            context.SaveChanges();
        }

        private static void SeedWorkers(ApplicationDbContext context)
        {
            var workers = new List<Worker>
            {
                new Worker { WorkerName = "Anna", WorkerAge = "25" },
                new Worker { WorkerName = "Juhan", WorkerAge = "30" },
                new Worker { WorkerName = "Maarja", WorkerAge = "22" },
                new Worker { WorkerName = "Kaur", WorkerAge = "28" },
                new Worker { WorkerName = "Liis", WorkerAge = "35" },
                new Worker { WorkerName = "Mikk", WorkerAge = "27" },
                new Worker { WorkerName = "Tiina", WorkerAge = "31" },
                new Worker { WorkerName = "Raul", WorkerAge = "29" },
                new Worker { WorkerName = "Kätlin", WorkerAge = "26" },
                new Worker { WorkerName = "Sander", WorkerAge = "33" }
            };
            context.Workers.AddRange(workers);
            context.SaveChanges();
        }

        private static void SeedCars(ApplicationDbContext context)
        {
            var cars = new List<Car>
            {
                new Car { Model = "Toyota Corolla", Plate = "123ABC", Age = 2015 },
                new Car { Model = "BMW 320i", Plate = "234BCD", Age = 2018 },
                new Car { Model = "Volkswagen Golf", Plate = "345CDE", Age = 2017 },
                new Car { Model = "Audi A4", Plate = "456DEF", Age = 2019 },
                new Car { Model = "Honda Civic", Plate = "567EFG", Age = 2016 },
                new Car { Model = "Ford Focus", Plate = "678FGH", Age = 2014 },
                new Car { Model = "Kia Ceed", Plate = "789GHI", Age = 2020 },
                new Car { Model = "Skoda Octavia", Plate = "890HIJ", Age = 2021 },
                new Car { Model = "Hyundai i30", Plate = "901IJK", Age = 2022 },
                new Car { Model = "Mazda 3", Plate = "012JKL", Age = 2013 }
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
        private static void SeedCarCares(ApplicationDbContext context)
        {
            var carCares = new List<CarCare>
            {
                new CarCare { CarId = 1, WorkerId = 1 },
                new CarCare { CarId = 2, WorkerId = 2 },
                new CarCare { CarId = 3, WorkerId = 3 },
                new CarCare { CarId = 4, WorkerId = 4 },
                new CarCare { CarId = 5, WorkerId = 5 },
                new CarCare { CarId = 6, WorkerId = 6 },
                new CarCare { CarId = 7, WorkerId = 7 },
                new CarCare { CarId = 8, WorkerId = 8 },
                new CarCare { CarId = 9, WorkerId = 9 },
                new CarCare { CarId = 10, WorkerId = 10 }
            };
            context.CarCares.AddRange(carCares);
            context.SaveChanges();
        }

        private static void SeedRepairs(ApplicationDbContext context)
        {
            var repairs = new List<Repair>
            {
                new Repair { CarId = 1, WorkerId = 10 },
                new Repair { CarId = 2, WorkerId = 9 },
                new Repair { CarId = 3, WorkerId = 8 },
                new Repair { CarId = 4, WorkerId = 7 },
                new Repair { CarId = 5, WorkerId = 6 },
                new Repair { CarId = 6, WorkerId = 5 },
                new Repair { CarId = 7, WorkerId = 4 },
                new Repair { CarId = 8, WorkerId = 3 },
                new Repair { CarId = 9, WorkerId = 2 },
                new Repair { CarId = 10, WorkerId = 1 }
            };
            context.Repairs.AddRange(repairs);
            context.SaveChanges();
        }

        private static void SeedCarDisplacements(ApplicationDbContext context)
        {
            var carDisplacements = new List<CarDisplacement>
            {
                new CarDisplacement { CarId = 1, WorkerId = 5 },
                new CarDisplacement { CarId = 2, WorkerId = 6 },
                new CarDisplacement { CarId = 3, WorkerId = 7 },
                new CarDisplacement { CarId = 4, WorkerId = 8 },
                new CarDisplacement { CarId = 5, WorkerId = 9 },
                new CarDisplacement { CarId = 6, WorkerId = 10 },
                new CarDisplacement { CarId = 7, WorkerId = 1 },
                new CarDisplacement { CarId = 8, WorkerId = 2 },
                new CarDisplacement { CarId = 9, WorkerId = 3 },
                new CarDisplacement { CarId = 10, WorkerId = 4 }
            };
            context.CarDisplacements.AddRange(carDisplacements);
            context.SaveChanges();
        }

        private static void SeedOperations(ApplicationDbContext context)
        {
            var operations = new List<Operation>
            {
                new Operation { CarId = 1, WorkerId = 3 },
                new Operation { CarId = 2, WorkerId = 4 },
                new Operation { CarId = 3, WorkerId = 5 },
                new Operation { CarId = 4, WorkerId = 6 },
                new Operation { CarId = 5, WorkerId = 7 },
                new Operation { CarId = 6, WorkerId = 8 },
                new Operation { CarId = 7, WorkerId = 9 },
                new Operation { CarId = 8, WorkerId = 10 },
                new Operation { CarId = 9, WorkerId = 1 },
                new Operation { CarId = 10, WorkerId = 2 }
            };
            context.Operations.AddRange(operations);
            context.SaveChanges();
        }

        private static void SeedWashes(ApplicationDbContext context)
        {
            var washes = new List<Wash>
            {
                new Wash { CarId = 1, WorkerId = 8 },
                new Wash { CarId = 2, WorkerId = 7 },
                new Wash { CarId = 3, WorkerId = 6 },
                new Wash { CarId = 4, WorkerId = 5 },
                new Wash { CarId = 5, WorkerId = 4 },
                new Wash { CarId = 6, WorkerId = 3 },
                new Wash { CarId = 7, WorkerId = 2 },
                new Wash { CarId = 8, WorkerId = 1 },
                new Wash { CarId = 9, WorkerId = 10 },
                new Wash { CarId = 10, WorkerId = 9 }
            };
            context.Washes.AddRange(washes);
            context.SaveChanges();
        }
    }
}
