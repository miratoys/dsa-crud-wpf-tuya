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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object cartTable;

        public List<Shopping> shoppings { get; }
        public object ID {  get; private set; }

        public class Shopping
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }
    
       public MainWindow()
        {
            InitializeComponent();

            shoppings = new List<Shopping>();
            {
                new Shopping { ID = 1, Name = "jabili", Description = "foodie", Price = 300 };
                new Shopping { ID = 1, Name = "makdwo", Description = "foodie", Price = 200 };
            };
            this.DataContext = this;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e, Menu menu)
        {
            try
            {
                if (Amount.Text != " " && Product.Text != " " && Details.Text != " " && Presyo.Text != " ")
                {
                    if (int.TryParse(Amount.Text, out int id) && decimal.TryParse(Product.Text, out decimal price))
                    {
                        shoppings.Add(new Shopping()
                        {
                            ID = id,
                            Name = Product.Text,
                            Description = Details.Text,
                            Price = (int)price,
                        });
                        menu.Items.Refresh();

                        Amount.Text = "";
                        Product.Text = "";
                        Details.Text = "";
                        Presyo.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid values");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Amount.Text = "";
            Product.Text = "";
            Details.Text = "";
            Presyo.Text = "";

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(cartTable.SelectItem is Shopping selectShopping))
            {
                MessageBox.Show("Please click a field");
            }
            else
            {
                selectShopping.ID = int.Parse(ID.Text);
                SelectShopping.Name = Product.Text;
            }

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
