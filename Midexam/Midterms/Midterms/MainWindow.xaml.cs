using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Midterms
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Shopping> shoppings { get; set; }
        public ObservableCollection<Shopping> cartItems { get; set; }

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

            shoppings = new ObservableCollection<Shopping>
            {
                new Shopping { ID = 1, Name = "jabili", Description = "foodie", Price = 300 },
                new Shopping { ID = 2, Name = "makdwo", Description = "foodie", Price = 200 }
            };

            cartItems = new ObservableCollection<Shopping>();

            this.DataContext = this;
            Addcart.ItemsSource = cartItems;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Amount.Text) ||
                string.IsNullOrWhiteSpace(Product.Text) ||
                string.IsNullOrWhiteSpace(Details.Text) ||
                string.IsNullOrWhiteSpace(Presyo.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (int.TryParse(Amount.Text, out int id) && decimal.TryParse(Presyo.Text, out decimal price))
            {
                var newProduct = new Shopping()
                {
                    ID = id,
                    Name = Product.Text,
                    Description = Details.Text,
                    Price = (int)price,
                };

                string msg = $"Add this product?\n\nID: {newProduct.ID}\nName: {newProduct.Name}\nDescription: {newProduct.Description}\nPrice: {newProduct.Price}";
                if (MessageBox.Show(msg, "Confirm Add Product", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    shoppings.Add(newProduct);
                    ClearButton_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("ID and Price must be valid numbers");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Amount.Text = "";
            Product.Text = "";
            Details.Text = "";
            Presyo.Text = "";
            cart.SelectedItem = null;
            Addcart.SelectedItem = null;
        }

        private void AddtoCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (cart.SelectedItem is Shopping selectedProduct)
            {
                string msg = $"Add this product to cart?\n\nID: {selectedProduct.ID}\nName: {selectedProduct.Name}\nDescription: {selectedProduct.Description}\nPrice: {selectedProduct.Price}";
                if (MessageBox.Show(msg, "Confirm Add to Cart", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    cartItems.Add(new Shopping
                    {
                        ID = selectedProduct.ID,
                        Name = selectedProduct.Name,
                        Description = selectedProduct.Description,
                        Price = selectedProduct.Price
                    });
                }
            }
            else
            {
                MessageBox.Show("Please select an item from Available Products.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (cart.SelectedItem is Shopping selectedProduct)
            {
                string msg = $"Remove this product from Available Products?\n\nID: {selectedProduct.ID}\nName: {selectedProduct.Name}\nDescription: {selectedProduct.Description}\nPrice: {selectedProduct.Price}";
                if (MessageBox.Show(msg, "Confirm Remove Product", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    shoppings.Remove(selectedProduct);
                    ClearButton_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Please select an item from Available Products to remove.");
            }
        }

        private void RemoveFromCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (Addcart.SelectedItem is Shopping selectedCartItem)
            {
                string msg = $"Remove this product from Shopping Cart?\n\nID: {selectedCartItem.ID}\nName: {selectedCartItem.Name}\nDescription: {selectedCartItem.Description}\nPrice: {selectedCartItem.Price}";
                if (MessageBox.Show(msg, "Confirm Remove From Cart", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    cartItems.Remove(selectedCartItem);
                    ClearButton_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Please select an item from Shopping Cart to remove.");
            }
        }

        private void cart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cart.SelectedItem is Shopping selected)
            {
                Addcart.SelectedItem = null;
                Amount.Text = selected.ID.ToString();
                Product.Text = selected.Name;
                Details.Text = selected.Description;
                Presyo.Text = selected.Price.ToString();
            }
        }

        private void Addcart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Addcart.SelectedItem is Shopping selected)
            {
                cart.SelectedItem = null; 
                Amount.Text = selected.ID.ToString();
                Product.Text = selected.Name;
                Details.Text = selected.Description;
                Presyo.Text = selected.Price.ToString();
            }
        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Product_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Details_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Presyo_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}