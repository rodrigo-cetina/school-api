using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SchoolContextSeed
    {
        public static async Task SeedAsync(SchoolContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Administrators.Any())
                {
                    var administratorsData = File.ReadAllText("../Infrastructure/Data/SeedData/administrators.json", Encoding.Latin1);

                    var administrators = JsonSerializer.Deserialize<List<Administrator>>(administratorsData);

                    foreach (var item in administrators)
                    {
                        context.Administrators.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Careers.Any())
                {
                    var careersData = File.ReadAllText("../Infrastructure/Data/SeedData/careers.json", Encoding.Latin1);

                    var careers = JsonSerializer.Deserialize<List<Career>>(careersData);

                    foreach (var item in careers)
                    {
                        context.Careers.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Students.Any())
                {
                    var studentsData = File.ReadAllText("../Infrastructure/Data/SeedData/students.json", Encoding.Latin1);

                    var students = JsonSerializer.Deserialize<List<Student>>(studentsData);

                    foreach (var item in students)
                    {
                        context.Students.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Teachers.Any())
                {
                    var teachersData = File.ReadAllText("../Infrastructure/Data/SeedData/teachers.json", Encoding.Latin1);

                    var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersData);

                    foreach (var item in teachers)
                    {
                        context.Teachers.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SchoolContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}