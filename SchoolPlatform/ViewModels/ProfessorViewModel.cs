using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using SchoolPlatform.Views;
using System.Windows;

namespace SchoolPlatform.ViewModels
{
    public class ProfessorViewModel
    {
        ProfessorDataAccess _professorDataAccess;
        UserDataAccess _userDataAccess;
        public ObservableCollection<Professor> Professors { get; set; }
        public List<UserType> ProfessorRoles { get; set; }

        public Professor SelectedProfessor { get; set; }
        public Professor NewProfessor { get; set; }
        public User NewUser { get; set; }

        public bool EditMode { get; set; } = false;

        public ProfessorViewModel()
        {
            ResetData();
            _userDataAccess = new UserDataAccess();
            _professorDataAccess = new ProfessorDataAccess();
            ProfessorRoles = new List<UserType>() {
                UserType.Professor, 
                UserType.ClassMaster
            };
            NewProfessor = new Professor
            {
                User = new User()
            };
            Professors = new ObservableCollection<Professor>(_professorDataAccess.GetAllProfessors());
        }

        public void OpenAddOrEditProfessorWindow(object param)
        {
            EditMode = param.ToString() == "1";
            Views.Admin.AddOrEditProfessor window = new Views.Admin.AddOrEditProfessor(this, EditMode);
            window.ShowDialog();
        }

        public void AddOrEditProfessor(object param)
{
    if (!EditMode)
    {
        //add user
        _userDataAccess.AddUser(NewProfessor.User);
        //add professor
        NewProfessor.UserId = NewProfessor.User.UserId;
        _professorDataAccess.AddProfessor(NewProfessor);
        //add to ui
        Professors.Add(NewProfessor);
    }
    else if (SelectedProfessor != null)
    {
        SelectedProfessor.User.UserName = NewUser.UserName;
        //NewProfessor.User.Password = SelectedProfessor.User.Password;
        SelectedProfessor.User.Password = NewUser.Password;
        SelectedProfessor.ProfessorName = NewProfessor.ProfessorName;
        //_userDataAccess.UpdateUser(NewUser, SelectedProfessor.User.UserId);

                _professorDataAccess.UpdateProfessor(NewProfessor, SelectedProfessor.ProfessorId);
    }
    else
    {
        MessageBox.Show("No selected entity!");
    }
    ResetData();
    RefreshProfessorList();
}


        public void ResetData()
        {
            NewUser = new User
            {
                UserType = UserType.Professor,
            };
            NewProfessor = new Professor();
        }

        public void RefreshProfessorList()
        {
            var list = _professorDataAccess.GetAllProfessors();
            Professors.Clear();
            foreach (var item in list)
            {
                Professors.Add(item);
            }
        }


        public void DeleteProfessor(object param)
        {
            _professorDataAccess.DeleteProfessor(SelectedProfessor);
            _userDataAccess.DeleteUser(SelectedProfessor.User);
            var objectToRemove = Professors.FirstOrDefault(obj => obj == SelectedProfessor);
            Professors.Remove(objectToRemove);
        }

        public void FillInData()
        {
            if (NewProfessor.User == null)
            {
                NewProfessor.User = new User();
            }
            NewProfessor.User.UserId = SelectedProfessor.User.UserId;
            NewProfessor.User.UserName = SelectedProfessor.User.UserName;
            NewProfessor.User.Password = SelectedProfessor.User.Password;
            NewProfessor.ProfessorName = SelectedProfessor.ProfessorName;
            NewProfessor.User.UserType = SelectedProfessor.User.UserType;
        }

        public ICommand OpenAddOrEditProfessorCommand => new RelayCommand<object>(OpenAddOrEditProfessorWindow);
        public ICommand AddOrEditProfessorCommand => new RelayCommand<object>(AddOrEditProfessor);
        public ICommand DeleteProfessorCommand => new RelayCommand<object>(DeleteProfessor);
    }
}
