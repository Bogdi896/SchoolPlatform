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

namespace SchoolPlatform.Views.Class
{
    /// <summary>
    /// Interaction logic for AddOrEditClass.xaml
    /// </summary>
    public partial class AddOrEditClass : Window
    {
        public AddOrEditClass(ClassViewModel classViewModel, bool editMode)
        {
            InitializeComponent(); 
            DataContext = classViewModel;

            if (editMode)
            {
                classViewModel.FillInData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
