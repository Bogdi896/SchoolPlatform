using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class SpecializationDataAccess
    {
        private readonly DataContext _dbContext;
        public SpecializationDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public void AddSpecialization(Specialization specialization)
        {
            _dbContext.Specializations.Add(specialization);
            _dbContext.SaveChanges();
        }

        public List<Specialization> GetAllSpecializations()
        {
            return _dbContext.Specializations.ToList();
        }
    }
}
