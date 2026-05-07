using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace listyeah
{

    public partial class MainWindow : Window
    {
        public List<Employee> Employees { get; }
        public object Id { get; private set; }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();

            Employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Title = "Software Engineer", Department = "IT", Salary = 60000 },
                new Employee { Id = 2, Name = "Jane Smith", Title = "Project Manager", Department = "Operations", Salary = 75000 },
                new Employee { Id = 3, Name = "Emily Johnson", Title = "HR Specialist", Department = "Human Resources", Salary = 50000 }
            };
            this.DataContext = this;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if all fields are filled. 'User' is your ID field here
                if (User.Text != " " && Naming.Text != " " && Sub.Text != " " && Office.Text != " " && Money.Text != " ")
                {
                    // Validate that ID and Salary are numbers before parsing
                    if (int.TryParse(User.Text, out int id) && decimal.TryParse(Money.Text, out decimal salary))
                    {
                        Employees.Add(new Employee
                        {
                            Id = id,
                            Name = Naming.Text,
                            Title = Sub.Text,
                            Department = Office.Text,
                            Salary = salary
                        });
                        Menu.Items.Refresh();

                        User.Text = "";
                        Naming.Text = "";
                        Sub.Text = "";
                        Office.Text = "";
                        Money.Text = "";
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values.");
            }
        }

            
        
    


        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            User.Text = "";
            Naming.Text = "";
            Sub.Text = "";
            Office.Text = "";
            Money.Text = "";

        }
    }
}

