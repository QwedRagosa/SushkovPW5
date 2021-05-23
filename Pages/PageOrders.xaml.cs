using SushkovPW5.BDmodel;
using SushkovPW5.OMG;
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

namespace SushkovPW5.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrders.xaml
    /// </summary>
    public partial class PageOrders : Page
    {
        public PageOrders()
        {
            InitializeComponent();
            OrderList.ItemsSource = SuperDataBase.DB.TrailerDriver.ToList();
        }

        private void Backbtn1_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new MainPage());
        }

        private void Createbtn_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new PageOrderCreate());
        }

        private void Changebtn_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new PageOrderChange());
        }

        private void Sortdisttbtn_Click(object sender, RoutedEventArgs e)
        {
            OrderList.ItemsSource = SuperDataBase.DB.TrailerDriver.OrderBy(x => x.Order.Distance).ToList();
        }

        private void Sortweightbtn_Click(object sender, RoutedEventArgs e)
        {
            OrderList.ItemsSource = SuperDataBase.DB.TrailerDriver.OrderBy(x => x.Order.Weight).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic row = OrderList.SelectedItem;
                int RemOrder = row.IDOrder;
                int RemTD = row.ID;
                var RemProcessTD = SuperDataBase.DB.TrailerDriver.FirstOrDefault(x=>x.ID == RemTD);
                var RemProcessOrd = SuperDataBase.DB.Order.FirstOrDefault(x => x.ID == RemOrder);
                SuperDataBase.DB.Order.Remove(RemProcessOrd);
                SuperDataBase.DB.TrailerDriver.Remove(RemProcessTD);
                SuperDataBase.DB.SaveChanges();
                OrderList.ItemsSource = SuperDataBase.DB.TrailerDriver.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
