using BLL.DTO;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    internal class PreOrderViewModel : ViewModelBase
    {
        IdishService dishService;
        IOrderService orderService;
        IstolService stolService;
        IReportService reportService;

        private MainWindow _mainWindow;
        private ClientWindow _clientWindow;
        private DeliveryClientWindow _deliveryclientWindow;
        private ManagerWindow _managerWindow;
        private PreOrderWindow preorderWindow;
        AboutMenuWindow _aboutmenuWindow;
        private RelayComand orderAutCommand;
        public ObservableCollection<stolDto> AllStols { get; set; }
        private stolDto _selectedStol;
        public stolDto selectedStol
        {
            get { return _selectedStol; }
            set { _selectedStol = value; OnPropertyChanged(); }

        }
        private int _idUser;
        private int _id;
        public int stol
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private string _number_phone;
        public string number_phone
        {
            get { return _number_phone; }
            set { _number_phone = value; OnPropertyChanged(); }

        }
        private string _adress;
        public string adress
        {
            get { return _adress; }
            set { _adress = value; OnPropertyChanged(); }

        }
        public RelayComand OrderAutCommand
        {

            get
            {
                return orderAutCommand ??
                  (orderAutCommand = new RelayComand(obj =>
                  {
                      ToOrderPage(obj);
                  }));
            }
        }
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
        private void ToMainPage(object obj)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            preorderWindow.Close();
        }

        public PreOrderViewModel(PreOrderWindow preorderWindow, IOrderService orderService, IdishService dishService, IstolService stolService, IReportService reportService)
        {
            this.preorderWindow = preorderWindow;
            this.dishService = dishService;
            this.orderService = orderService;
            this.stolService = stolService;
            this.reportService = reportService;
            AllStols = new ObservableCollection<stolDto>();
            AllStols = new ObservableCollection<stolDto>(stolService.GetAllStols());
        }

        private void ToOrderPage(object obj)
        {
            //orderDto temp = new orderDto();
            //temp.id_stol = Int32.Parse(stol);
            //temp.order_status = "InProcess";

            //orderService.MakeOrder(temp);
            _clientWindow = new ClientWindow(selectedStol.id);
            _clientWindow.Show();
            preorderWindow.Close();
        }
        private void ToDeliveryPage(object obj)
        {
            //orderDto temp = new orderDto();
            //temp.id_stol = Int32.Parse(stol);
            //temp.order_status = "InProcess";
            //orderService.MakeOrder(temp);
            //deliveryDto tempdel = new deliveryDto();
            //tempdel.id_order = Int32.Parse(stol);
            //tempdel.adress =adress;
            //tempdel.number_cli = number;
            //orderService.MakeOrder(temp);
            _deliveryclientWindow = new DeliveryClientWindow(adress,number_phone);
            _deliveryclientWindow.Show();
            preorderWindow.Close();
        }
    }
}
