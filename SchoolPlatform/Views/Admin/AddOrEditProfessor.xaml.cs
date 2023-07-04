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
using SchoolPlatform.ViewModels;

namespace SchoolPlatform.Views.Admin
{
    /// <summary>
    /// Interaction logic for AddOrEditProfessor.xaml
    /// </summary>
    public partial class AddOrEditProfessor : Window
    {
        public AddOrEditProfessor(ProfessorViewModel professorViewModel, bool editMode)
        {
            InitializeComponent();
            DataContext = professorViewModel;
            if(editMode)
            {
                professorViewModel.FillInData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
