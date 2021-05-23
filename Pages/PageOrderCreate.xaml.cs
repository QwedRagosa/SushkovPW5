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
    /// Логика взаимодействия для PageOrderCreate.xaml
    /// </summary>
    public partial class PageOrderCreate : Page
    {
        public PageOrderCreate()
        {
            InitializeComponent();
            DriverList.ItemsSource = SuperDataBase.DB.Driver.Select(x=>x.FullName).ToList();
        }

        private void Backbtn1_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new PageOrders());
        }

        private void DriverList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Createbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order1 = new Order()
                {
                    Name = Nametbx.Text,
                    PointDep = Deptbx.Text,
                    PointDest = Desttbx.Text,
                    Distance = int.Parse(Disttbx.Text),
                    Weight = int.Parse(Weighttbx.Text),
                };
                TrailerDriver TD1 = new TrailerDriver()
                {
                    IDTrailer = 1,
                    IDDriver = SuperDataBase.DB.Driver.FirstOrDefault(x => x.FullName == DriverList.SelectedItem.ToString()).ID,
                    IDOrder = order1.ID,
                    IDRoleInTrailer = 1
                };
                SuperDataBase.DB.Order.Add(order1);
                SuperDataBase.DB.TrailerDriver.Add(TD1);
                SuperDataBase.DB.SaveChanges();
                PagesData.pageframe.Navigate(new PageOrders());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " Убедитесь, что все поля заполнены, а расстояние и вес - цифровые значения.");
            } 
        }
    }
}
