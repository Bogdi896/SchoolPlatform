using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchoolPlatform.Models
{
    public class Student : BaseNotification
    {

        /*private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }*/
        [Key]
        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                NotifyPropertyChanged("StudentId");
            }
        }

        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                _studentName = value;
                NotifyPropertyChanged("StudentName");
            }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                NotifyPropertyChanged("UserId");
            }
        }

        [ForeignKey("UserId")]
        public User User { get; set; }

        private int _classId;
        public int ClassId
        {
            get { return _classId; }
            set
            {
                _classId = value;
                NotifyPropertyChanged("ClassId");
            }
        }

        [ForeignKey("ClassId")]
        private Class _class;
        public Class Class
        {
            get { return _class; }
            set
            {
                _class = value;
                NotifyPropertyChanged("Class");
            }
        }

        public Student()
        {
        }
    }
}
