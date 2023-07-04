using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolPlatform.Views.Class;
using SchoolPlatform.Views.Admin;

namespace SchoolPlatform.ViewModels
{
    public class ClassViewModel : BaseNotification
    {
        private SpecializationDataAccess _specializationDataAccess;
        private YearDataAccess _yearDataAccess;
        public ClassDataAccess _classDataAccess;

        private ObservableCollection<Class> _classes;
        public ObservableCollection<Class> Classes
        {
            get { return _classes; }
            set
            {
                _classes = value;
                NotifyPropertyChanged("Classes");
            }
        }
        public ObservableCollection<YearOfStudy> YearOfStudies { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }
        public bool EditMode { get; set; }
        public Class NewClass { get; set; }
        public Class SelectedClass { get; set; }

        public ClassViewModel()
        {
            NewClass = new Class();
            _yearDataAccess = new YearDataAccess();
            _specializationDataAccess = new SpecializationDataAccess();
            _classDataAccess = new ClassDataAccess();
            Classes = new ObservableCollection<Class>(_classDataAccess.GetAllClasses());   
            YearOfStudies = new ObservableCollection<YearOfStudy>(_yearDataAccess.GetAllYearsOfStudy());
            Specializations = new ObservableCollection<Specialization>(_specializationDataAccess.GetAllSpecializations());
        }

        public void AddClass(object param)
        {
            if (!EditMode)
            {
                _classDataAccess.AddClass(NewClass);
                Classes.Add(NewClass);
            }
            else
            {
                _classDataAccess.UpdateClass(NewClass, SelectedClass.ClassId);
                var objectToUpdate = Classes.FirstOrDefault(obj => obj == SelectedClass);
                objectToUpdate = NewClass;
            }
            NewClass = new Class();
        }

        public void DeleteClass(object param)
        {
            _classDataAccess.DeleteClass(SelectedClass);
            var objectToRemove = Classes.FirstOrDefault(obj => obj == SelectedClass);
            Classes.Remove(objectToRemove);
        }

        public void FillInData()
        {
            NewClass.Specialization = SelectedClass.Specialization;
            NewClass.SpecializationId = SelectedClass.SpecializationId;
            NewClass.YearOfStudy = SelectedClass.YearOfStudy;
            NewClass.YearOfStudyId = SelectedClass.YearOfStudyId;   
        }

        public void OpenAddOrEditWindow(object param)
        {
            if (param is string strParam)
            {
                if (strParam == "1")
                {
                    EditMode = true;
                }
                else if (strParam == "0")
                {
                    EditMode = false;
                }
            }
            AddOrEditClass window = new AddOrEditClass(this, EditMode);
            window.ShowDialog();
        }

        public void OpenSubjectsClassWindow(object param)
        {
            ManageSubjectsClass window = new ManageSubjectsClass(SelectedClass);
            window.ShowDialog();
        }

        public ICommand OpenAddOrEditWindowCommand => new RelayCommand<object>(OpenAddOrEditWindow);
        public ICommand AddOrEditClassCommand => new RelayCommand<object>(AddClass);
        public ICommand DeleteClassCommand => new RelayCommand<object>(DeleteClass);
        public ICommand OpenSubjectsWindowCommand => new RelayCommand<object>(OpenSubjectsClassWindow);
    }
}
