using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Window, INotifyPropertyChanged
    {
        public readonly List<EmployeeDetail> emp;
        public EmployeeList()
        {
            InitializeComponent();
            emp = new List<EmployeeDetail>();
            this.DataContext = this;
            EmployeeEntities context = new EmployeeEntities();

            var query = from data in context.EmployeeDetails

                        select data;
           foreach(var data in query)
            // MessageBox.Show(data.Id.ToString());
            {
                EmployeeDetail employeeDetail = new EmployeeDetail();
                employeeDetail.Id = data.Id;
                employeeDetail.Name = data.Name;
                employeeDetail.Age = data.Age;
                employeeDetail.Gender = data.Gender;
                employeeDetail.Address = data.Address;
                employeeDetail.DateOfBirth = data.DateOfBirth;
                employeeDetail.Department = data.Department;
                employeeDetail.IsActive = data.IsActive;
                emp.Add(employeeDetail);
            }
            empList.DataContext = emp;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetails dashboard = new EmployeeDetails();
            dashboard.Show();
            this.Close();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
        
            Button btn = (Button)sender;
            int a =Convert.ToInt32(btn.Uid);
           var b = btn.Tag.ToString();
            //MessageBox.Show(btn.Tag..ToString());
            UpdateEmployee updateEmployee = new UpdateEmployee(a,b);
            updateEmployee.Show();
            this.Close();
            //EmployeeEntities context = new EmployeeEntities();
           // var query = (from data in context.EmployeeDetails where data.Id==Convert.ToInt32(a) select data).First();
            
            
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int a =Convert.ToInt32(btn.Uid);
            //MessageBox.Show(a);
            EmployeeEntities context = new EmployeeEntities();
            EmployeeDetail employeeDetail = (from data in context.EmployeeDetails where data.Id == a select data).First();
            context.EmployeeDetails.Remove(employeeDetail);
            context.SaveChanges();

            //MessageBox.Show(employeeDetail.Name);
            // var query = from data in context.EmployeeDetails where data.Id == Convert.ToInt32(a) select data;

            EmployeeList dashboard = new EmployeeList();
            dashboard.Show();
            this.Close();

        }

    }
}
