using BLL.DTO;
using BLL.Services;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    internal class ManagerViewModel : ViewModelBase
    {
        IdishService dishService;
        IDishStringService dishstringService;
        IOrderService orderService;
        IingrdientService ingredientService;
        IstolService stolService;
        IReportService reportService;
        private ClientWindow clientWindow;
        private ManagerWindow managerWindow;
        private DeliveryWindow _managerWindow;
        private MainWindow _mainWindow;
        private ObservableCollection<orderDto> _orderDto;

        public ObservableCollection<orderDto> AllOrders
        {
            get { return _orderDto; }
            set { _orderDto = value; OnPropertyChanged(); }
        }
        private orderDto _selectedOrder;
        public orderDto SelectedOrder
        {
            get { return _selectedOrder; }
            set { _selectedOrder = value; OnPropertyChanged(); }

        }
        private ObservableCollection<ingredientDto> _ingredientDto;

        public ObservableCollection<ingredientDto> AllIngredients
        {
            get { return _ingredientDto; }
            set { _ingredientDto = value; OnPropertyChanged(); }
        }
        private ingredientDto _selectedIngredient;
        public ingredientDto SelectedIngredient
        {
            get { return _selectedIngredient; }
            set { _selectedIngredient = value; OnPropertyChanged(); }

        }
        private ObservableCollection<stolDto> _stolDto;

        public ObservableCollection<stolDto> AllStol
        {
            get { return _stolDto; }
            set { _stolDto = value; OnPropertyChanged(); }
        }
        private stolDto _selectedStol;
        public stolDto SelectedStol
        {
            get { return _selectedStol; }
            set { _selectedStol = value; OnPropertyChanged(); }

        }
        private string _revenueday;
        public string revenueday
        {
            get { return _revenueday; }
            set { _revenueday = value; OnPropertyChanged(); }
        }
        private string _revenuemonth;
        public string revenuemonth
        {
            get { return _revenuemonth; }
            set { _revenuemonth = value; OnPropertyChanged(); }
        }
        private string _profitday;
        public string profitday
        {
            get { return _profitday; }
            set { _profitday = value; OnPropertyChanged(); }
        }
        private string _profitmonth;
        public string profitmonth
        {
            get { return _profitmonth; }
            set { _profitmonth = value; OnPropertyChanged(); }
        }
        private AddOrder AddMenuDish;
        private AddStol AddMenuStol;
        public ICommand AddOrder { get; set; }
        public ICommand DeleteOrder { get; set; }
        public ICommand UpdateOrder { get; set; }
        public ICommand AddStol { get; set; }
        public ICommand AddDish { get; set; }
        public ICommand DeleteStol { get; set; }
        public ICommand UpdateStol { get; set; }
        public ICommand DeleteDish { get; set; }
        public ICommand UpdateDish { get; set; }

        //public ObservableCollection<dishDto> AllDishes { get; set; }
        public ObservableCollection<deliveryDto> AllDeliveries { get; set; }

        private void AddStolMenu(object obj)
        {
            AddMenuStol = new AddStol(orderService, dishService, stolService, reportService);
            AddMenuStol.ShowDialog();

            AllStol = new ObservableCollection<stolDto>(stolService.GetAllStols());
        }
        private void AddDishMenu(object obj)
        {
            AddMenuDish = new AddOrder(orderService, dishstringService, dishService, reportService);
            AddMenuDish.ShowDialog();

            AllDishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());
        }
        private void DeleteOrderExecute(object obj)
        {
            try
            {
                orderService.DeleteOrder(SelectedOrder.id);
                AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateOrderExexute(object obj)
        {
            foreach (orderDto order in AllOrders)
            {
                orderService.UpdateOrder(order);
            }
        }
        private void DeleteStolExecute(object obj)
        {
            try
            {
                stolService.DeleteStol(SelectedStol.id);
                AllStol = new ObservableCollection<stolDto>(stolService.GetAllStols());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStolExexute(object obj)
        {
            foreach (stolDto order in AllStol)
            {
                stolService.UpdateStol(order);
            }
        }
        private ObservableCollection<dishDto> _dishDto;

        public ObservableCollection<dishDto> AllDishes
        {
            get { return _dishDto; }
            set { _dishDto = value; OnPropertyChanged(); }
        }
        private dishDto _selecteddish;
        public dishDto SelectedDish
        {
            get { return _selecteddish; }
            set { _selecteddish = value; OnPropertyChanged(); }

        }
        private void DeleteDishExecute(object obj)
        {
            try
            {
                dishService.DeleteDish(SelectedDish.id);
                AllDishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDishExexute(object obj)
        {
            foreach (dishDto order in AllDishes)
            {
                dishService.UpdateDish(order);
            }
        }
        private void ProfitExexute(object obj)
        {
            //foreach (stolDto order in AllStol)
            //{
            //    stolService.UpdateStol(order);
            //}
            reportService.revenueDay();
        }
        private RelayComand cancel;
        public RelayComand Cancell
        {
            get
            {
                return cancel ??
                  (cancel = new RelayComand(obj =>
                  {
                      ToMainPage(obj);
                  }));
            }
        }

        public ManagerViewModel(ManagerWindow managerWindow, IOrderService orderService, IdishService dishService, IstolService stolService, IingrdientService ingredientService, IingredientStringService ingredientStringService, IReportService reportService)
        {
            this.managerWindow = managerWindow;
            this.dishService = dishService;
            this.orderService = orderService;
            this.stolService = stolService;
            this.reportService = reportService;
            AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            AllStol = new ObservableCollection<stolDto>(stolService.GetAllStols());
            AllDishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());
            AllIngredients = new ObservableCollection<ingredientDto>(ingredientService.GetAllIngredients());
            DeleteDish = new RelayComand(DeleteDishExecute);
            UpdateDish = new RelayComand(UpdateDishExexute);
            AllDeliveries = new ObservableCollection<deliveryDto>();
            DeleteOrder = new RelayComand(DeleteOrderExecute);
            UpdateOrder = new RelayComand(UpdateOrderExexute);
            AddStol = new RelayComand(AddStolMenu);
            AddDish = new RelayComand(AddDishMenu);
            DeleteStol = new RelayComand(DeleteStolExecute);
            UpdateStol = new RelayComand(UpdateStolExexute);
            revenueday=reportService.revenueDay().ToString();
            revenuemonth = reportService.revenueMonth().ToString();
            profitmonth = reportService.profitMonth().ToString();
            profitday = reportService.profitDay().ToString();
        }
        private void ToMainPage(object obj)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            managerWindow.Close();
        }
    }
}
