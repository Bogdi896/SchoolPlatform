using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Subject : BaseNotification
    {
        [Key]
        private int _subjectId;
        public int SubjectId
        {
            get { return _subjectId; }
            set
            {
                _subjectId = value;
                NotifyPropertyChanged("SubjectId");
            }
        }

        private string _subjectName;
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                _subjectName = value;
                NotifyPropertyChanged("SubjectName");
            }
        }

        public Subject() { }
    }
}
