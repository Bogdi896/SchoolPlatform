using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class ClassSubject : BaseNotification
    {
        [Key]
        private int _classSubjectId;
        public int ClassSubjectId
        {
            get { return _classSubjectId; }
            set
            {
                _classSubjectId = value;
                NotifyPropertyChanged("ClassSubjectId");
            }
        }

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

        [ForeignKey("SubjectId")]
        private Subject _subject;
        public Subject Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                NotifyPropertyChanged("Subject");
            }
        }

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

        [ForeignKey("ProfessorId")]
        private Professor _professor;
        public Professor Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                NotifyPropertyChanged("Professor");
            }
        }
    }
}
