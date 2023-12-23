﻿using Interfaces.Services;
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
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder(IOrderService orderService, IDishStringService dishstringService, IdishService dishService, IReportService reportService)
        {
            InitializeComponent();
            DataContext = new AddDishViewModel( orderService, dishstringService, dishService, reportService);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
