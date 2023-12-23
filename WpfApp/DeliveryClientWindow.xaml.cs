using BLL.Services;
using Interfaces.Services;
using Ninject;
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
using Test.Utils;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для DeliveryClientWindow.xaml
    /// </summary>
    
    public partial class DeliveryClientWindow : Window
    {
        IdishService dishService;
        IdeliveryService deliveryService;
        IOrderService orderService;
        IReportService reportService;
        IDishStringService dishstringService;
        public DeliveryClientWindow(string adress,string number_phone)
        {
            InitializeComponent();
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("Model14"));

            dishService = kernel.Get<IdishService>();
            deliveryService = kernel.Get<IdeliveryService>();
            dishstringService = kernel.Get<IDishStringService>();
            orderService = kernel.Get<IOrderService>();
            reportService = kernel.Get<IReportService>();
            DataContext = new DeliveryClientViewModel(this,adress, number_phone, orderService, dishstringService, dishService, deliveryService, reportService);
        }
    }
}
