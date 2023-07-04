using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Professor : BaseNotification
    {
        [Key]
        private int _professorId;
        public int ProfessorId
        {
            get { return _professorId; }
            set
            {
                _professorId = value;
                NotifyPropertyChanged("ProfessorId");
            }
        }

        private string _professorName;
        public string ProfessorName
        {
            get { return _professorName; }
            set
            {
                _professorName = value;
                NotifyPropertyChanged("ProfessorName");
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

        public Professor()
        {
        }
    }
}
