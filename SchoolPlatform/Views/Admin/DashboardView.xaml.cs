using SchoolPlatform.ViewModels;
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
using SchoolPlatform.Views.Admin;
using System.ComponentModel;

namespace SchoolPlatform.Views.Admin
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        AdminDashboardViewModel _adminDashboardViewModel;
        public DashboardView()
        {
            InitializeComponent();
            _adminDashboardViewModel = new AdminDashboardViewModel();
            DataContext = _adminDashboardViewModel;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStudent window = new AddOrEditStudent((AdminDashboardViewModel)DataContext, false);
            window.ShowDialog();
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStudent window = new AddOrEditStudent((AdminDashboardViewModel)DataContext, true);
            window.ShowDialog();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _adminDashboardViewModel.Refresh();
        }
    }
}
