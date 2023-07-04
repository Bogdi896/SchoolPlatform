using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolPlatform.DAL
{
    public class DbSeeder
    {
        public static void SeedAdminUser(DataContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new User
                {
                    UserName = "admin",
                    Password = "pass",
                    UserType = UserType.Admin,
                };
                context.Users.Add(adminUser);
                context.SaveChanges();
            }
        }

        public static void SeedYearOfStudy(DataContext context)
        {
            for (int i = 9; i <= 12; i++)
            {
                if (!context.YearOfStudies.Any(u => u.Year == i))
                {
                    YearOfStudy yearOfStudy = new YearOfStudy
                    {
                        Year = i,
                    };
                    context.YearOfStudies.Add(yearOfStudy);
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSpecialization(DataContext context)
        {
            List<String> list = new List<String>
            {
                "Mate-Info",
                "Științe ale naturii",
                "Științe sociale",
                "Filologie",
            };
            foreach (var item in list)
            {
                if (!context.Specializations.Any(u => u.SpecializationName == item))
                {
                    Specialization specialization = new Specialization
                    {
                        SpecializationName = item
                    };

                    context.Specializations.Add(specialization);
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSubjects(DataContext context)
        {
            List<String> list = new List<String>
            {
                "Romana",
                "Matematica",
                "Biologie",
                "Fizica",
                "Chimie"
            };
            foreach (var item in list)
            {
                if (!context.Subjects.Any(u => u.SubjectName == item))
                {
                    Subject subject = new Subject
                    {
                        SubjectName = item
                    };

                    context.Subjects.Add(subject);
                    context.SaveChanges();
                }
            }
        }
    }
}
