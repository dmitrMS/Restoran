using BLL.DTO;
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
    internal class AddDishViewModel : ViewModelBase
    {
        IdishService dishService;
        IDishStringService dishstringService;
        IOrderService orderService;
        IstolService stolService;
        IReportService reportService;
        private ClientWindow mainWindow;
        private DeliveryWindow _managerWindow;
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private string _weight;
        public string weight
        {
            get { return _weight; }
            set { _weight = value; OnPropertyChanged(); }
        }
        private string _price;
        public string price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }
        private string _time_cook;
        public string time_cook
        {
            get { return _time_cook; }
            set { _time_cook = value; OnPropertyChanged(); }
        }
        //private ObservableCollection<orderDto> _stolDto;

        //public ObservableCollection<orderDto> AllStol
        //{
        //    get { return _stolDto; }
        //    set { _stolDto = value; OnPropertyChanged(); }
        //}
        private AddOrder AddMenuDish;
        public ICommand AddDish { get; set; }

        public ObservableCollection<dishDto> AllDishes { get; set; }
        public ObservableCollection<deliveryDto> AllDeliveries { get; set; }
        //private void AddStolMenu(object obj)
        //{
        //    AddMenuStol = new AddStol(orderService, dishService, stolService, reportService);
        //    AddMenuStol.ShowDialog();

        //    AllStol = new ObservableCollection<orderDto>(orderService.GetAllOrders());
        //}
        private void AddCommandExecute(object obj)
        {
            try
            {
                dishDto temp = new dishDto();
                temp.id = Int32.Parse(_id);
                temp.weight = Int32.Parse(_weight);
                temp.price = Int32.Parse(_price);
                temp.time_cook = Int32.Parse(_time_cook);
                temp.name = _name;
                //temp.status = false;
                //temp.PassportSeries = Int32.Parse(_passport_series);
                //temp.IDPosition = SelectedPosition.Id;
                //temp.Position = SelectedPosition;

                dishService.CreateDish(temp);

                MessageBox.Show("Добавлено блюдо");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public ICommand AddCommand { get; set; }
        public AddDishViewModel(IOrderService orderService, IDishStringService dishstringService, IdishService dishService, IReportService reportService)
        {
            this.dishService = dishService;
            this.orderService = orderService;
            this.dishstringService = dishstringService;
            //this.stolService = stolService;
            this.reportService = reportService;
            AddDish = new RelayComand(AddCommandExecute);
            AllDishes = new ObservableCollection<dishDto>();
            AllDeliveries = new ObservableCollection<deliveryDto>();
        }
    }
}
