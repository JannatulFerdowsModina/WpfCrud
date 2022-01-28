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
using WpfCrud.ViewModels;

namespace WpfCrud.Views
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        //private readonly List<string> Departments = new List<string>();
        public UpdateEmployee(int a,string b)
        {
            InitializeComponent();
            this.DataContext = this;
            //MessageBox.Show(b);
            EmployeeEntities context = new EmployeeEntities();
            EmployeeDetail e = (from data in context.EmployeeDetails where data.Id == a select data).First();
            Id.Text = e.Id.ToString();
            Name.Text = e.Name;
            Address.Text = e.Address;
            Gender.Text = e.Gender;
           
            DateOfBirth.Text = e.DateOfBirth.ToString();
            var query = (from data in context.Departments

                         select new { Name = data.Name, Id = data.Id }).ToList();
            //foreach (var d in query)
            //{
            //    Departments.Add(d.Name.ToString());
            //}
            //Department.ItemsSource = Departments;
            // var department = (from data in context.Departments where data.Id == e.DepertmentId select data).First();
            Department.ItemsSource = query;
            Department.DisplayMemberPath = "Name";
            Department.SelectedValuePath = "Id";
            Department.Text=b;
            IsActive.IsChecked = e.IsActive; 
        }
        public bool IsValid()
        {

            if (Name.Text == string.Empty)
            {
                MessageBox.Show("please Insert name");
                return false;
            }

            if (Gender.Text == string.Empty)
            {
                MessageBox.Show("please Insert gender");
                return false;
            }
            if (Address.Text == string.Empty)
            {
                MessageBox.Show("please Insert address");
                return false;
            }
            if (DateOfBirth.Text == string.Empty)
            {
                MessageBox.Show("Please insert Date of Birth");
                return false;
            }

            if (Department.Text == string.Empty)
            {
                MessageBox.Show("Please insert Department");
                return false;
            }
            return true;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                EmployeeEntities context = new EmployeeEntities();
                int a = Convert.ToInt32(Id.Text);
                EmployeeDetail employeeDetail = (from data in context.EmployeeDetails where data.Id == a select data).First();
                employeeDetail.Name = Name.Text;
                EmployeeDetailsViewModel age = new EmployeeDetailsViewModel();
                employeeDetail.Age = age.AgeCalculate(Convert.ToDateTime(DateOfBirth.Text));
                employeeDetail.Gender = Gender.Text;
                employeeDetail.Address = Address.Text;
                employeeDetail.DateOfBirth = Convert.ToDateTime(DateOfBirth.Text);
                employeeDetail.IsActive = Convert.ToBoolean(IsActive.IsChecked);
                employeeDetail.DepertmentId = Convert.ToInt32(Department.SelectedValue);
                context.SaveChanges();

                EmployeeList dashboard = new EmployeeList();
                dashboard.Show();
                this.Close();
            }

        }
    }
}
