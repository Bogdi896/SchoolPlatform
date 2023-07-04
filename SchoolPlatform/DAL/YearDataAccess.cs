using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class YearDataAccess
    {
        private readonly DataContext _dbContext;
        public YearDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public void AddYearOfStudy(YearOfStudy year)
        {
            _dbContext.YearOfStudies.Add(year);
            _dbContext.SaveChanges();
        }

        public List<YearOfStudy> GetAllYearsOfStudy()
        {
            return _dbContext.YearOfStudies.ToList();
        }
    }
}
