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

namespace SchoolPlatform.Views.Admin
{
    /// <summary>
    /// Interaction logic for AddOrEditStudent.xaml
    /// </summary>
    public partial class AddOrEditStudent : Window
    {
        StudentViewModel _studentViewModel;
        public AddOrEditStudent(AdminDashboardViewModel adminDashboardViewModel, bool editMode)
        {
            InitializeComponent();
            DataContext = adminDashboardViewModel.StudentViewModel;
            _studentViewModel = adminDashboardViewModel.StudentViewModel;
            _studentViewModel.EditMode = editMode;

            if(editMode)
            {
                _studentViewModel.FillInData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
