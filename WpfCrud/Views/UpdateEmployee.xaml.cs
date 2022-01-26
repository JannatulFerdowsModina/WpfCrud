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
using WpfCrud.Models;

namespace WpfCrud.Views
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        public UpdateEmployee(int a)
        {
            InitializeComponent();
            this.DataContext = this;

            EmployeeEntities context = new EmployeeEntities();
            EmployeeDetail e = (from data in context.EmployeeDetails where data.Id == a select data).First();
            //MessageBox.Show(employeeDetail.Name);
            Name.Text = e.Name;
            Age.Text = e.Age;
            Address.Text = e.Address;
            Gender.Text = e.Gender;
            Id.Text = e.Id.ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEntities context = new EmployeeEntities();
            int a = Convert.ToInt32(Id.Text);
            EmployeeDetail employeeDetail = (from data in context.EmployeeDetails where data.Id ==a select data).First();
            employeeDetail.Id = Convert.ToInt32(Id.Text);
            employeeDetail.Name = Name.Text;
            employeeDetail.Age = Age.Text;
            employeeDetail.Gender = Gender.Text;
            employeeDetail.Address = Address.Text;
            context.SaveChanges();

            EmployeeList dashboard = new EmployeeList();
            dashboard.Show();
            this.Close();
        }
    }
}
