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
    public class ClassDataAccess
    {
        private readonly DataContext _dbContext;
        public ClassDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        /*public List<Class> GetAllClasses()
        {
            return _dbContext.Classes.ToList();
        }*/
        public List<Class> GetAllClasses()
        {
            List<Class> classes = new List<Class>();

            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    classes.Add(new Class
                    {
                        ClassId = Convert.ToInt32(reader["ClassId"]),
                        YearOfStudy = new YearOfStudy
                        {
                            YearOfStudyId = Convert.ToInt32(reader["YearOfStudyId"]),
                            Year = Convert.ToInt32(reader["Year"])
                        },
                        Specialization = new Specialization
                        {
                            SpecializationId = Convert.ToInt32(reader["SpecializationId"]),
                            SpecializationName = reader["SpecializationName"].ToString()
                        }
                    });
                }
            }

            return classes;
        }


        public Class GetClassById(int id)
        {
            return _dbContext.Classes.FirstOrDefault(u => u.ClassId == id);
        }

        public void AddClass(Class c)
        {
            _dbContext.Classes.Add(c);
            _dbContext.SaveChanges();
        }
        /*public void AddClass(Class newClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClass", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@SpecializationId", (int)newClass.SpecializationId);
                cmd.Parameters.AddWithValue("@YearOfStudyId", (int)newClass.YearOfStudyId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }*/


        /*public void DeleteClass(Class c)
        {
            _dbContext.Classes.Remove(c);
            _dbContext.SaveChanges();
        }*/
        public void DeleteClass(Class c)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClass", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ClassId", c.ClassId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateClass(Class c, int id)
        {
            var dbEntity = GetClassById(id);

            if (dbEntity != null)
            {
                dbEntity.Specialization = c.Specialization;
                dbEntity.SpecializationId = c.SpecializationId;
                dbEntity.YearOfStudy = c.YearOfStudy;
                dbEntity.YearOfStudyId = c.YearOfStudyId;
                _dbContext.SaveChanges();
            }
        }
    }
}
