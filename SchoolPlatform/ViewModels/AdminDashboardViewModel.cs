using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class AdminDashboardViewModel : BaseNotification
    {
        private StudentViewModel _studentViewModel;
        public StudentViewModel StudentViewModel
        {
            get { return _studentViewModel; }
            set
            {
                _studentViewModel = value;
                NotifyPropertyChanged(nameof(StudentViewModel));
            }
        }
        private ClassViewModel _classViewModel;
        public ClassViewModel ClassViewModel
        {
            get { return _classViewModel; }
            set
            {
                _classViewModel = value;
                NotifyPropertyChanged(nameof(ClassViewModel));
            }
        }

        private ProfessorViewModel _professorViewModel;
        public ProfessorViewModel ProfessorViewModel
        {
            get { return _professorViewModel; }
            set
            {
                _professorViewModel = value;
                NotifyPropertyChanged(nameof(ProfessorViewModel));
            }
        }

        public AdminDashboardViewModel()
        {
            _studentViewModel = new StudentViewModel();
            _classViewModel = new ClassViewModel();
            _professorViewModel = new ProfessorViewModel();
        }

        public void Refresh()
        {
            _studentViewModel.RefreshClassList();
        }
    }
}
