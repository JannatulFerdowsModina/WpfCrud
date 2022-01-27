using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : Window , INotifyPropertyChanged
    {
        // public int Id;
        private readonly List<string> Departments = new List<string>();
        public EmployeeDetails()
        {
            InitializeComponent();
            this.DataContext = this;
            EmployeeEntities context = new EmployeeEntities();

            var query = from data in context.Departments

                        select data;
            foreach(var d in query)
            {
                Departments.Add(d.Name.ToString());
            }
            Department.ItemsSource = Departments;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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

            if(Department.Text==string.Empty)
            {
                MessageBox.Show("Please insert Department");
                return false;
            }
            return true;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Name.Text);
            if(IsValid())
            {
                EmployeeEntities context = new EmployeeEntities();
                EmployeeDetail employeeDetail = new EmployeeDetail();
                EmployeeDetailsViewModel age = new EmployeeDetailsViewModel();
                string dept = Department.Text.ToString();
                var department = (from data in context.Departments where data.Name ==dept select data).First();
                //employeeDetail.Id = Convert.ToInt32(Id.Text);
                employeeDetail.Name = Name.Text;
                employeeDetail.Gender = Gender.Text;
                employeeDetail.Address = Address.Text;
                employeeDetail.Age = age.AgeCalculate(Convert.ToDateTime(DateOfBirth.Text));
                employeeDetail.DateOfBirth = Convert.ToDateTime(DateOfBirth.Text);
                employeeDetail.IsActive =Convert.ToBoolean(IsActive.IsChecked);
                employeeDetail.DepertmentId =department.Id;
                context.EmployeeDetails.Add(employeeDetail);
                context.SaveChanges();

                EmployeeList dashboard = new EmployeeList();
                dashboard.Show();
                this.Close();
            }
         

         
        }

        //private void ListButton_Click(object sender, RoutedEventArgs e)
        //{
        //    EmployeeList dashboard = new EmployeeList();
        //    dashboard.Show();
        //}
    }
}
