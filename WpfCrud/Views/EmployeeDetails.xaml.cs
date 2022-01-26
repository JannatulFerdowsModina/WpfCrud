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
namespace WpfCrud.Views
{
    /// <summary>
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : Window , INotifyPropertyChanged
    {
       // public int Id;
        public EmployeeDetails()
        {
            InitializeComponent();
            this.DataContext = this;
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
            //MessageBox.Show(Name.Text);
            EmployeeEntities context = new EmployeeEntities();
            EmployeeDetail employeeDetail = new EmployeeDetail();
            employeeDetail.Id = Convert.ToInt32(Id.Text);
            employeeDetail.Name = Name.Text;
            employeeDetail.Age = Age.Text;
            employeeDetail.Gender = Gender.Text;
            employeeDetail.Address = Address.Text;
            context.EmployeeDetails.Add(employeeDetail);
            context.SaveChanges();

            EmployeeList dashboard = new EmployeeList();
            dashboard.Show();
            this.Close();

         
        }

        //private void ListButton_Click(object sender, RoutedEventArgs e)
        //{
        //    EmployeeList dashboard = new EmployeeList();
        //    dashboard.Show();
        //}
    }
}
