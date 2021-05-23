﻿using SushkovPW5.OMG;
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
    /// Логика взаимодействия для PageDrivers.xaml
    /// </summary>
    public partial class PageDrivers : Page
    {
        public PageDrivers()
        {
            InitializeComponent();
            DriverList.ItemsSource = SuperDataBase.DB.Driver.ToList();
            
        }

        private void Backbtn1_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new MainPage());
        }
    }
}
