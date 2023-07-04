using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SchoolPlatform.DAL
{
    public class ProfessorDataAccess
    {
        UserDataAccess _userDataAccess;
        private readonly DataContext _dbContext;
        public ProfessorDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
            _userDataAccess = new UserDataAccess();
        }

        /*public List<Professor> GetAllProfessors()
        {
            return _dbContext.Professors.ToList();
        }*/
        public ObservableCollection<Professor> GetAllProfessors()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllProfessors", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                ObservableCollection<Professor> professors = new ObservableCollection<Professor>();

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Professor professor = new Professor
                    {
                        ProfessorId = (int)reader["ProfessorId"],
                        ProfessorName = reader["ProfessorName"].ToString(),
                        User = new User
                        {
                            UserId = (int)reader["UserId"],
                            UserName = reader["UserName"].ToString(),
                            Password = reader["Password"].ToString(),
                            UserType = (UserType)(int)reader["UserType"]
                        }
                    };

                    professors.Add(professor);
                }

                reader.Close();
                return professors;
            }
        }


        public Professor GetProfessorById(int id)
        {
            return _dbContext.Professors.FirstOrDefault(u => u.ProfessorId == id);
        }

        /*public void AddProfessor(Professor professor)
        {
            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();
        }*/
        public void AddProfessor(Professor professor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProfessor", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserName", professor.User.UserName);
                cmd.Parameters.AddWithValue("@Password", professor.User.Password);
                cmd.Parameters.AddWithValue("@UserType", (int)professor.User.UserType);
                cmd.Parameters.AddWithValue("@ProfessorName", professor.ProfessorName);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        /*public void DeleteProfessor(Professor professor)
        {
            _dbContext.Professors.Remove(professor);
            _dbContext.SaveChanges();
        }*/
        public void DeleteProfessor(Professor professor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProfessor", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ProfessorId", professor.ProfessorId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        /*public void UpdateProfessor(Professor professor, int id)
        {
            var dbEntity = GetProfessorById(id);

            if (dbEntity != null)
            {
                dbEntity.ProfessorName = professor.ProfessorName;
                _dbContext.SaveChanges();
            }
        }*/
        public void UpdateProfessor(Professor newProfessor, int selectedProfessorId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateProfessor", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ProfessorId", selectedProfessorId);
                cmd.Parameters.AddWithValue("@ProfessorName", newProfessor.ProfessorName);
                cmd.Parameters.AddWithValue("@UserId", newProfessor.User.UserId);
                cmd.Parameters.AddWithValue("@UserName", newProfessor.User.UserName);
                cmd.Parameters.AddWithValue("@Password", newProfessor.User.Password);
                cmd.Parameters.AddWithValue("@UserType", (int)newProfessor.User.UserType);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
