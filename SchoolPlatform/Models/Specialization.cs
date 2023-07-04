using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Specialization : BaseNotification
    {
        [Key]
        private int _specializationId;
        public int SpecializationId
        {
            get { return _specializationId; }
            set
            {
                _specializationId = value;
                NotifyPropertyChanged("SpecializationId");
            }
        }
        private string _specializationName;
        public string SpecializationName
        {
            get { return _specializationName; }
            set
            {
                _specializationName = value;
                NotifyPropertyChanged("SpecializationName");
            }
        }
    }
}
