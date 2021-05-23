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
    /// Логика взаимодействия для PageOrderChange.xaml
    /// </summary>
    public partial class PageOrderChange : Page
    {
        public PageOrderChange()
        {
            InitializeComponent();
            ChooseOrder.ItemsSource = SuperDataBase.DB.Order.Select(x => x.Name).ToList();
        }

        private void Backbtn1_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new PageOrders());
        }

        private void ChooseOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var OrderListVar = SuperDataBase.DB.Order.FirstOrDefault(x => x.Name == ChooseOrder.SelectedItem.ToString());
            Nametbx.Text = OrderListVar.Name;
            Deptbx.Text = OrderListVar.PointDep;
            Desttbx.Text = OrderListVar.PointDest;
            Disttbx.Text = OrderListVar.Distance.ToString();
            Weighttbx.Text = OrderListVar.Weight.ToString();
        }

        private void Createbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Nametbx.Text != null && Deptbx.Text != null && Desttbx.Text != null && Disttbx.Text != null && Weighttbx.Text != null)
                {
                    var ChangeVar = SuperDataBase.DB.Order.FirstOrDefault(x => x.Name == ChooseOrder.SelectedItem.ToString());
                    ChangeVar.Name = Nametbx.Text;
                    ChangeVar.PointDep = Deptbx.Text;
                    ChangeVar.PointDest = Desttbx.Text;
                    ChangeVar.Distance = int.Parse(Disttbx.Text);
                    ChangeVar.Weight = int.Parse(Weighttbx.Text);

                    SuperDataBase.DB.SaveChanges();
                    PagesData.pageframe.Navigate(new PageOrders());
                }
                else
                {
                    MessageBox.Show("Заполните все поля.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
