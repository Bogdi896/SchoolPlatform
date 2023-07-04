using Microsoft.EntityFrameworkCore;
using SchoolPlatform.DAL;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Views.Auth;
using System.Windows;
using SchoolPlatform.Service;

namespace SchoolPlatform.ViewModels
{
    public class LoginViewModel
    {
        private UserDataAccess _userDataAccess;
        private ProfessorDataAccess _professorDataAccess;

        public LoginViewModel()
        {
            _userDataAccess = new UserDataAccess();
            _professorDataAccess = new ProfessorDataAccess();
            DataContextSingleton.SeedData();
        }

        public void Authenticate(LoginView login, string username, string password)
        {
            User user = _userDataAccess.GetUserByUsernameAndPassword(username, password);
            if (user != null)
            {
                if (user.UserType == UserType.Admin)
                {
                    Views.Admin.DashboardView dashboardView = new Views.Admin.DashboardView();
                    dashboardView.Show();
                    login.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong Credentials!");
            }
        }
    }
}
