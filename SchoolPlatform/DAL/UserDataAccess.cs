using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SchoolPlatform.DAL
{
    public class UserDataAccess
    {
        private readonly DataContext _dbContext;
        public UserDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
 
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", user.UserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        /*public void UpdateUser(User user, int id)
        {
            var existingUser = _dbContext.Users.Find(id); // Find method attaches the entity to the DbContext

            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.UserType = user.UserType;

                _dbContext.Users.Update(existingUser); // Explicitly tell DbContext to track the entity
                _dbContext.SaveChanges();
            }
        }*/
        public void UpdateUser(User user, int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@UserType", (int)user.UserType);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return GetAllUsers().FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
