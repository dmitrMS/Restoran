using BLL.Services;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        IdishService dishService;
        IOrderService orderService;
        IReportService reportService;

        private MainWindow mainWindow;
        private ClientWindow _clientWindow;
        private ManagerWindow _managerWindow;
        private PreOrderWindow preorderWindow;
        private AboutMenuWindow aboutmenuWindow;
        private RelayComand clientAutCommand;
        public RelayComand ClientAutCommand
        {
            get
            {
                return clientAutCommand ??
                  (clientAutCommand = new RelayComand(obj =>
                  {
                      ToClientPage(obj);
                  }));
            }
        }

        private RelayComand managerAutCommand;
        public RelayComand ManagerAutCommand
        {
            get
            {
                return managerAutCommand ??
                  (managerAutCommand = new RelayComand(obj =>
                  {
                      ToManagerPage(obj);
                  }));
            }
        }
        private RelayComand aboutAutCommand;
        public RelayComand AboutAutCommand
        {
            get
            {
                return aboutAutCommand ??
                  (aboutAutCommand = new RelayComand(obj =>
                  {
                      ToAboutPage(obj);
                  }));
            }
        }

        public MainViewModel(MainWindow mainWindow, IOrderService orderService, IdishService dishService, IReportService reportService)
        {
            this.mainWindow = mainWindow;
            this.dishService = dishService;
            this.orderService = orderService;
            this.reportService = reportService;
        }

        private void ToClientPage(object obj)
        {
            preorderWindow = new PreOrderWindow();
            preorderWindow.Show();
            mainWindow.Close();
        }

        private void ToManagerPage(object obj)
        {
            _managerWindow = new ManagerWindow();
            _managerWindow.Show();
            mainWindow.Close();
        }
        private void ToAboutPage(object obj)
        {
            aboutmenuWindow = new AboutMenuWindow();
            aboutmenuWindow.Show();
            mainWindow.Close();
        }
    }
}
