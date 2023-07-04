using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class YearOfStudy : BaseNotification
    {
        [Key]
        private int _yearOfStudyId;
        public int YearOfStudyId
        {
            get { return _yearOfStudyId; }
            set
            {
                _yearOfStudyId = value;
                NotifyPropertyChanged("YearOfStudyId");
            }
        }
        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                NotifyPropertyChanged("Year");
            }
        }
    }
}
