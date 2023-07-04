using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SchoolPlatform.Models;
using SchoolPlatform.ViewModels;
using SchoolPlatform.Views.Class;

namespace SchoolPlatform.Views.Admin
{
    /// <summary>
    /// Interaction logic for ManageSubjectsClass.xaml
    /// </summary>
    public partial class ManageSubjectsClass : Window
    {
        ClassSubjectViewModel _classSubjectViewModel;
        public ManageSubjectsClass(Models.Class selectedClass)
        {
            InitializeComponent();

            _classSubjectViewModel = new ClassSubjectViewModel(selectedClass);
            DataContext = _classSubjectViewModel;
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_classSubjectViewModel.SelectedClassSubject != null && _classSubjectViewModel.SelectedClassSubject != null)
            {
                _classSubjectViewModel.SelectedSubject = _classSubjectViewModel.SelectedClassSubject.Subject;
                _classSubjectViewModel.SelectedProfessor = _classSubjectViewModel.SelectedClassSubject.Professor;
            }
        }
    }
}
