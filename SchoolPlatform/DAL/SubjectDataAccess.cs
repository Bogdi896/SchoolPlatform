using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class SubjectDataAccess
    {
        private readonly DataContext _dbContext;
        public SubjectDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<Subject> GetAllSubjects()
        {
            return _dbContext.Subjects.ToList();
        }

    }
}
