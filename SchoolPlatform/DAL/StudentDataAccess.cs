using SchoolPlatform.Data;
using SchoolPlatform.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;
using Microsoft.EntityFrameworkCore;
using SchoolPlatform.ViewModels;
using System.Runtime.Remoting.Contexts;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace SchoolPlatform.DAL
{
    public class StudentDataAccess
    {
        UserDataAccess _userDataAccess;
        private readonly DataContext _dbContext;
        public StudentDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
            _userDataAccess = new UserDataAccess();
        }

        /*public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }*/
        public ObservableCollection<Student> GetAllStudents()
{
    using (SqlConnection con = DALHelper.Connection)
    {
        SqlCommand cmd = new SqlCommand("GetAllStudents", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };

        ObservableCollection<Student> students = new ObservableCollection<Student>();

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            User user = new User
            {
                UserId = (int)reader["UserId"],
                UserName = reader["UserName"].ToString(),
                Password = reader["Password"].ToString(),
                UserType = (UserType)Enum.Parse(typeof(UserType), reader["UserType"].ToString())
            };

            Specialization specialization = new Specialization
            {
                SpecializationId = (int)reader["SpecializationId"],
                SpecializationName = reader["SpecializationName"].ToString()
            };

            YearOfStudy yearOfStudy = new YearOfStudy
            {
                YearOfStudyId = (int)reader["YearOfStudyId"],
                Year = (int)reader["Year"]
            };

            Class classInfo = new Class
            {
                ClassId = (int)reader["ClassId"],
                SpecializationId = specialization.SpecializationId,
                Specialization = specialization,
                YearOfStudyId = yearOfStudy.YearOfStudyId,
                YearOfStudy = yearOfStudy
            };

            Student student = new Student
            {
                StudentId = (int)reader["StudentId"],
                StudentName = reader["StudentName"].ToString(),
                ClassId = classInfo.ClassId,
                Class = classInfo,
                UserId = user.UserId,
                User = user
            };

            students.Add(student);
        }

        reader.Close();
        return students;
    }
}



        public Student GetStudentById(int id)
        {
            return _dbContext.Students.FirstOrDefault(u => u.StudentId == id);
        }

        /*public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }*/
        public void AddStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@UserName", student.User.UserName);
                cmd.Parameters.AddWithValue("@Password", student.User.Password);
                cmd.Parameters.AddWithValue("@UserType", (int)student.User.UserType);
                cmd.Parameters.AddWithValue("@ClassId", student.ClassId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        /*public void DeleteStudent(Student student)
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }*/
        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /*public void UpdateStudent(Student student, int id)
        {
            var existingStudent = GetStudentById(id);

            if (existingStudent != null)
            {
                existingStudent.StudentName = student.StudentName;
                existingStudent.Class = student.Class;
                existingStudent.ClassId = student.ClassId;
                _dbContext.SaveChanges();
            }
        }*/
        public void UpdateStudent(Student newStudent, int selectedStudentId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@StudentId", selectedStudentId);
                cmd.Parameters.AddWithValue("@StudentName", newStudent.StudentName);
                cmd.Parameters.AddWithValue("@ClassId", newStudent.Class.ClassId);
                cmd.Parameters.AddWithValue("@UserId", newStudent.User.UserId);
                cmd.Parameters.AddWithValue("@UserName", newStudent.User.UserName);
                cmd.Parameters.AddWithValue("@Password", newStudent.User.Password);
                cmd.Parameters.AddWithValue("@UserType", (int)newStudent.User.UserType);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }






    }
}
