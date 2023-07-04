using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SchoolPlatform.DAL
{
    public class ClassSubjectDataAccess
    {
        private readonly DataContext _dbContext;
        public ClassSubjectDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public ClassSubject GetClassSubjectById(int id)
        {
            return _dbContext.ClassSubjects
                .Include(cs => cs.Professor)
                .FirstOrDefault(u => u.ClassSubjectId == id);
        }

        public List<ClassSubject> GetClassSubjects(int id)
        {
            return _dbContext.ClassSubjects
                .Include(cs => cs.Professor)
                .Where(p => p.ClassId == id)
                .ToList();
        }

        public List<ClassSubject> GetProfessorSubjects(int id)
        {
            return _dbContext.ClassSubjects
                .Where(cs => cs.ProfessorId == id)
                .Include(cs => cs.Class)
                    .ThenInclude(c => c.YearOfStudy)
                .Include(cs => cs.Class)
                    .ThenInclude(c => c.Specialization)
                .Include(cs => cs.Subject)
                .ToList();
        }

        public void AddClassSubject(ClassSubject classSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClassSubject", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ClassId", classSubject.ClassId);
                cmd.Parameters.AddWithValue("@SubjectId", classSubject.SubjectId);
                cmd.Parameters.AddWithValue("@ProfessorId", classSubject.ProfessorId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteClassSubject(ClassSubject classSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassSubject", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ClassSubjectId", classSubject.ClassSubjectId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateClassSubject(ClassSubject classSubject, int id)
        {
            var dbEntity = GetClassSubjectById(id);

            if (dbEntity != null)
            {
                dbEntity.ClassId = classSubject.ClassId;
                dbEntity.Class = classSubject.Class;
                dbEntity.SubjectId = classSubject.SubjectId;
                dbEntity.Subject = classSubject.Subject;
                dbEntity.ProfessorId = classSubject.ProfessorId;
                dbEntity.Professor = classSubject.Professor;
                _dbContext.SaveChanges();
            }
        }
    }
}
