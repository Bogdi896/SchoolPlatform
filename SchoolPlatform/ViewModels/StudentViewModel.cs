using SchoolPlatform.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class StudentViewModel : BaseNotification
    {
        private UserDataAccess _userDataAccess; 
        private StudentDataAccess _studentDataAccess;
        private ClassDataAccess _classDataAccess;

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                NotifyPropertyChanged("Student");
            }
        }

        public bool EditMode { get; set; }
        public User NewUser { get; set; }
        public Student NewStudent { get; set; }
        public Student SelectedStudent { get; set; }
        public ObservableCollection<Class> Classes { get; set; }

        public StudentViewModel()
        {
            ResetData();
            _userDataAccess = new UserDataAccess();
            _studentDataAccess = new StudentDataAccess();
            _classDataAccess = new ClassDataAccess();
            Students = new ObservableCollection<Student>(_studentDataAccess.GetAllStudents());
            Classes = new ObservableCollection<Class>(_classDataAccess.GetAllClasses());
        }

        public void AddOrEditStudent(object param)
        {
            if (!EditMode)
            {
                // Add user
                _userDataAccess.AddUser(NewUser);
                // Add student
                NewStudent.UserId = NewUser.UserId;
                NewStudent.User = NewUser;
                NewStudent.Class = NewStudent.Class;
                NewStudent.ClassId = NewStudent.Class.ClassId;
                _studentDataAccess.AddStudent(NewStudent);
                // Add to UI
                Students.Add(NewStudent);
            }
            else if (SelectedStudent != null)
            {
                // Update user and student
                _userDataAccess.UpdateUser(NewUser, SelectedStudent.User.UserId);

                // Update student properties
                SelectedStudent.StudentName = NewStudent.StudentName;
                SelectedStudent.Class = NewStudent.Class;
                SelectedStudent.ClassId = NewStudent.Class.ClassId;
                SelectedStudent.User.UserName= NewUser.UserName;
                SelectedStudent.User.Password= NewUser.Password;

                // Update student in data access
                _studentDataAccess.UpdateStudent(SelectedStudent, SelectedStudent.StudentId);
            }
            else
            {
                MessageBox.Show("No selected entity!");
            }
            ResetData();
            RefreshStudentList();
        }



        public void DeleteStudent(object param)
        {
            if(SelectedStudent != null) {
                //delete student
                _studentDataAccess.DeleteStudent(SelectedStudent);
                //delete user
                int idToRemove = SelectedStudent.User.UserId;
                User user = _userDataAccess.GetUserById(idToRemove);
                _userDataAccess.DeleteUser(user);
            }
            else
            {
                MessageBox.Show("No selected entity!");
            }

            RefreshStudentList();
        }

        public void FillInData()
        {
            NewUser.UserName = SelectedStudent.User.UserName;
            NewUser.Password = SelectedStudent.User.Password;   
            NewStudent.StudentName = SelectedStudent.StudentName;
            NewStudent.Class = SelectedStudent.Class;   
            NewStudent.ClassId = SelectedStudent.ClassId;
        }

        public void ResetData()
        {
            NewUser = new User
            {
                UserType = UserType.Student,
            };
            NewStudent = new Student();
        }

        public void RefreshStudentList()
        {
            var list = _studentDataAccess.GetAllStudents();
            Students.Clear();
            foreach (var item in list)
            {
                Students.Add(item);
            }
        }

        public void RefreshClassList()
        {
            Classes = new ObservableCollection<Class>(_classDataAccess.GetAllClasses());
        }

        public ICommand AddOrEditStudentCommand => new RelayCommand<object>(AddOrEditStudent);

        public ICommand DeleteStudentCommand => new RelayCommand<object>(DeleteStudent);
    }
}
