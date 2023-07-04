using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class ClassSubjectViewModel : BaseNotification
    {
        ClassSubjectDataAccess _classSubjectDataAccess;
        SubjectDataAccess _subjectDataAccess;
        ProfessorDataAccess _professorDataAccess;

        public Models.Class SelectedClass { get; set;}
        public ClassSubject SelectedClassSubject { get; set; }
        public ObservableCollection<ClassSubject> ClassSubjects { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Professor> Professors { get; set; }
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                _selectedSubject = value;
                NotifyPropertyChanged(nameof(SelectedSubject));
            }
        }
        private Professor _selectedProfessor;
        public Professor SelectedProfessor
        {
            get { return _selectedProfessor; }
            set
            {
                _selectedProfessor = value;
                NotifyPropertyChanged(nameof(SelectedProfessor));
            }
        }

        public ClassSubjectViewModel(Models.Class selectedClass) { 
            SelectedClass = selectedClass;
            _classSubjectDataAccess = new ClassSubjectDataAccess();
            _subjectDataAccess = new SubjectDataAccess();
            _professorDataAccess = new ProfessorDataAccess();   
            ClassSubjects = new ObservableCollection<ClassSubject>(_classSubjectDataAccess.GetClassSubjects(selectedClass.ClassId));
            Subjects = new ObservableCollection<Subject>(_subjectDataAccess.GetAllSubjects());
            Professors = new ObservableCollection<Professor>(_professorDataAccess.GetAllProfessors());
        }

        public void AddSubject(object param)
        {
            ClassSubject classSubject = new ClassSubject
            {
                ClassId = SelectedClass.ClassId,
                SubjectId = SelectedSubject.SubjectId,
                ProfessorId = SelectedProfessor.ProfessorId,
                Professor = SelectedProfessor,
                Class = SelectedClass,
                Subject = SelectedSubject
            };
            _classSubjectDataAccess.AddClassSubject(classSubject);

            ClassSubjects.Add(classSubject);
        }

        public void RemoveSubject(object param)
        {
            _classSubjectDataAccess.DeleteClassSubject(SelectedClassSubject);

            var objectToRemove = ClassSubjects.FirstOrDefault(obj => obj.ClassSubjectId == SelectedClassSubject.ClassSubjectId);
            ClassSubjects.Remove(objectToRemove);
        }

        public void UpdateSubject(object param)
        {
            ClassSubject classSubject = new ClassSubject
            {
                ClassId = SelectedClass.ClassId,
                Class = SelectedClass,
                SubjectId = SelectedSubject.SubjectId,
                Subject = SelectedSubject,
                ProfessorId = SelectedProfessor.ProfessorId,
                Professor = SelectedProfessor
            };
            _classSubjectDataAccess.UpdateClassSubject(classSubject, SelectedClassSubject.ClassSubjectId);
        }

        public ICommand AddSubjectCommand => new RelayCommand<object>(AddSubject);
        public ICommand RemoveSubjectCommand => new RelayCommand<object>(RemoveSubject);
        public ICommand UpdateSubjectCommand => new RelayCommand<object>(UpdateSubject);

    }
}
