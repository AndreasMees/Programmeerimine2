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
            if (context.Cars.Any() || context.Workers.Any()) // lisa vajadusel muud tabelid
                return;

            SeedWorkers(context);
            SeedCars(context);
            // kutsu siia ka teised meetodid kui olemas: SeedOperations, SeedRepairs jne
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
    }
}
