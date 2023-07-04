using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Class : BaseNotification
    {
        [Key]
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
        [ForeignKey("SpecializationId")]
        private Specialization _specialization;
        public Specialization Specialization
        {
            get { return _specialization; }
            set
            {
                _specialization = value;
                NotifyPropertyChanged("Specialization");
            }
        }

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

        [ForeignKey("YearOfStudyId")]
        private YearOfStudy _yearOfStudy;
        public YearOfStudy YearOfStudy
        {
            get { return _yearOfStudy; }
            set
            {
                _yearOfStudy = value;
                NotifyPropertyChanged("YearOfStudy");
            }
        }
        public Class() { }
    }
}
