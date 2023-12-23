using BLL.DTO;
using BLL.Services;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        IdishService dishService;
        IingrdientService ingredientService;
        IOrderService orderService;
        IReportService reportService;
        IDishStringService dishstringService;

        private ClientWindow clientWindow;
        private DeliveryWindow _managerWindow;
        private MainWindow _mainWindow;
        private ObservableCollection<dishDto> _dish;
        public ObservableCollection<dishDto> Dishes
        {
            get { return _dish; }
            set { _dish = value; OnPropertyChanged(); }
        }
        private dishDto _dishSelected;
        public dishDto dishSelected
        {
            get { return _dishSelected; }
            set { _dishSelected = value; OnPropertyChanged(); }
        }
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public ICommand CatalogCommand { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }

        }
        private int _number;
        public int number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(); }

        }
        private void Catalog(object obj) => CurrentView = new CatalogViewModel(IdUser,temp,orderService, dishstringService, dishService, reportService);
        private RelayComand deliveryAutCommand;
        public RelayComand DeliveryAutCommand
        {
            get
            {
                return deliveryAutCommand ??
                  (deliveryAutCommand = new RelayComand(obj =>
                  {
                      ToDeliveryPage(obj);
                  }));
            }
        }
        private RelayComand mainAutCommand;
        public RelayComand MainAutCommand
        {
            get
            {
                return mainAutCommand ??
                  (mainAutCommand = new RelayComand(obj =>
                  {
                      ToMainDonePage(obj);
                  }));
            }
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
        private ObservableCollection<orderDto> _orderDto;

        public ObservableCollection<orderDto> AllOrders
        {
            get { return _orderDto; }
            set { _orderDto = value; OnPropertyChanged(); }
        }
        public ICommand Delete { get; set; }
        public ICommand Update { get; set; }
        private ObservableCollection<dishstringDto> _dishstringDto;
        public ObservableCollection<dishstringDto> AllDishStrings
        {
            get { return _dishstringDto; }
            set
            {
                _dishstringDto = value; OnPropertyChanged();
            }
        }
        private dishstringDto _selectedDishstring;
        public dishstringDto SelectedDishString
        {
            get { return _selectedDishstring; }
            set { _selectedDishstring = value; OnPropertyChanged(); }

        }
        public ObservableCollection<deliveryDto> AllDeliveries { get; set; }
        public ICommand AddInCart { get; set; }
        public void AddInCartExecute(object obj)
        {
            if (dishSelected != null)
            {
                dishstringService.CreateDishString(dishSelected, IdUser, number);
                orderService.UpdateOrder(temp);
                temp = orderService.GetDoneOrder();
                AllOrders.Clear();
                AllOrders.Add(orderService.GetDoneOrder());
                AllDishStrings = new ObservableCollection<dishstringDto>(dishstringService.GetOrderDishString(temp.id));
                
                //foreach(var i in orderService.GetAllOrders())
                //{
                //    AllOrders.Add(i);
                //}
                //AllOrders = new ObservableCollection<orderDto>(new List<orderDto>() { orderService.GetDoneOrder() });
                //AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            }

        }
        private void DeleteDishStringExecute(object obj)
        {
            try
            {
                dishstringService.DeleteDishString(SelectedDishString.id);
                AllDishStrings = new ObservableCollection<dishstringDto>(dishstringService.GetOrderDishString(temp.id));
                //AllDishStrings = new ObservableCollection<dishstringDto>(dishstringService.GetOrderDishString(temp.id));
                //ingredientService.UpdateIngredient();
                orderService.UpdateOrder(temp);
                AllOrders = new ObservableCollection<orderDto>(new List<orderDto>() { orderService.GetDoneOrder() });
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDishStringExexute(object obj)
        {
            foreach (dishstringDto order in AllDishStrings)
            {
                dishstringService.UpdateDishString(order);
            }
            //dishstringService.UpdateDishString();
            orderService.UpdateOrder(temp);
            //AllOrders.Clear();
            //AllOrders.Add(orderService.GetDoneOrder());
            AllDishStrings = new ObservableCollection<dishstringDto>(dishstringService.GetOrderDishString(temp.id));
            AllOrders = new ObservableCollection<orderDto>(new List<orderDto>() { orderService.GetDoneOrder() });
        }
        private int stol;

        private orderDto temp;
        public ClientViewModel(ClientWindow clientWindow,int newstol, IOrderService orderService, IDishStringService dishstringService, IdishService dishService, IReportService reportService)
        {
            temp=new orderDto();
            this.stol = newstol;
            //temp.id = (int)db.dishes.Local.ToBindingList().Max(x => x.id);
            temp.id_stol = newstol;
            temp.order_status = "InProcess";

            temp=orderService.MakeOrder(temp);
            this.clientWindow = clientWindow;
            this.dishstringService = dishstringService;
            this.dishService = dishService;
            this.orderService = orderService;
            this.reportService = reportService;
            AllOrders = new ObservableCollection<orderDto>(new List<orderDto>() { orderService.GetDoneOrder() });
            //AllOrders = new ObservableCollection<orderDto>(orderService.GetAllOrders());
            CatalogCommand = new RelayComand(Catalog);
            IdUser = temp.id;
            //number =0 ;
            Delete = new RelayComand(DeleteDishStringExecute);
            Update = new RelayComand(UpdateDishStringExexute);
            CurrentView = new CatalogViewModel(IdUser,temp, orderService, dishstringService, dishService, reportService);
            //AllDishStrings = new ObservableCollection<dishstringDto>(dishstringService.GetOrderDishString(temp.id));
            AllDishStrings = new ObservableCollection<dishstringDto>(dishstringService.GetOrderDishString(temp.id));
            AllDeliveries = new ObservableCollection<deliveryDto>();
            AddInCart = new RelayComand(AddInCartExecute);

            Dishes = new ObservableCollection<dishDto>(dishService.GetAllDishes());
        }
       
        private void ToDeliveryPage(object obj)
        {
            _managerWindow = new DeliveryWindow();
            _managerWindow.Show();
            clientWindow.Close();
        }
        private void ToMainPage(object obj)
        {
            orderService.DeleteOrder(temp.id);
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            clientWindow.Close();
        }
        private void ToMainDonePage(object obj)
        {
            //orderService.DeleteOrder(temp.id);
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            clientWindow.Close();
        }
    }
}

