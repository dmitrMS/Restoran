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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    /// 
    public partial class ManagerWindow : Window
    {
        IdishService dishService;
        IOrderService orderService;
        IstolService stolService;
        IReportService reportService;
        IingrdientService ingredientService;
        IingredientStringService ingredientStringService;
        public ManagerWindow()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("Model14"));

            dishService = kernel.Get<IdishService>();
            orderService = kernel.Get<IOrderService>();
            reportService = kernel.Get<IReportService>();
            stolService = kernel.Get<IstolService>();
            ingredientService = kernel.Get<IingrdientService>();
            ingredientStringService = kernel.Get<IingredientStringService>();
            DataContext = new ManagerViewModel(this, orderService, dishService, stolService, ingredientService, ingredientStringService, reportService);
        }
    }
}
