using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    internal class AboutMenuViewModel : ViewModelBase
    {
        private string _aboutText;
        public string AboutText
        {
            get { return _aboutText; }
            set { _aboutText = value; OnPropertyChanged(); }
        }
        
        private AboutMenuWindow _aboutmenuWindow;
        private MainWindow _mainWindow;
        public ICommand AboutProgramCommand { get; set; }
        public ICommand TaskInfoCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand UpdateAndDeleteTaskCommand { get; set; }
        public ICommand InfSectionInfoCommand { get; set; }
        public ICommand AddAndDeleteInfSectionCommand { get; set; }
        public ICommand PageInfoCommand { get; set; }
        public ICommand AddAndDeletePageCommand { get; set; }
        public ICommand TrackTimeInfoCommand { get; set; }
        public ICommand ReportTrackTimeInfoCommad { get; set; }
        public ICommand ReportStateTaskForCurrentProjectInfoCommand { get; set; }
        public ICommand WorkersGridProjectCommand { get; set; }
        public ICommand ProjectsGridCommand { get; set; }

        private void AboutProgramExecute(object obj)
        {
            AboutText = "Система учётов заказов клиентов в ресторане предназначена для заказа блюд в ресторане и функционирования ресторана в целом";
        }

        private void TaskInfoExecute(object obj)
        {
            AboutText = "Меню представлено как список в котором пользователь выбирает блюдо";
        }

        private void AddTaskExecute(object obj)
        {
            AboutText = "При добавлении блюда пользователь совершает клик по названию блюда, а затем в нижнем поле указывает колличество блюд для заказа ";
        }

        private void UpdateAndDeleteTaskExecute(object obj)
        {
            AboutText = "Удаление заданий проивзодится за счёт выделение в таблице той строки-проекта, который преднезначен для удаления. Редактирование производится напрямую с данными таблицы";
            AboutText += "Также следует нажать на соответствующие интуитивно понятные кнопки в верхнем меню для применения изменений";
        }

        private void InfSectionInfoExecute(object obj)
        {
            AboutText = "Когда клиент запрашивает доставку, она атоматически создаётся и высвечивается во вкладке";
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="obj"></param>
        //private void AddAndDeleteInfSectionExecute(object obj)
        //{
        //    AboutText = "Добавление инфомарционных секций производится через специальную форму, нажав на кнопку добавление '+' в верхнем меню\n";
        //    AboutText += "Удаление же проивзодится путём выделения нужной секции и нажатия соответствующей кнопки в верхнем меню\n";
        //}

        //private void PageInfoExecute(object obj)
        //{
        //    AboutText = "Страницы - это раздлы с конкретной информацией по конкретной теме, хранятся в ифномарционных секциях";
        //}

        //private void AddAndDeletePageExecute(object obj)
        //{
        //    AboutText = "Добавление проивзодится через специальную форму по средствам нажатия соответствующей кнопки в верхнем меню\n";
        //    AboutText += "Удаление проивзодится по средствам выделения нужной страницы в меню и её удаление по средствам нажатия соответствующей кнопки в верхнем меню";
        //}

        //private void TrackTimeInfoExecute(object obj)
        //{
        //    AboutText = "Трек времени - фиксация факта работы над заданием каждого ключевого сотрудника. Каждый добавляет количество часов - сколько данный работник за 1(!) день " +
        //        "проработал на данным заданием";
        //}
        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="obj"></param>
        private void ReportTrackTimeInfoExecute(object obj)
        {
            AboutText = "Вывод статистики о прибыли и выручке ресторана";
        }

        private void ReportStateTaskForCurrentProjectInfoExecute(object obj)
        {
            AboutText = "Вывод истории заказов";
        }
        /// <summary>
        /// /////////////////
        /// </summary>
        /// <param name="obj"></param>
        private void WorkersGridProjectExecute(object obj)
        {
            AboutText = "Вывод информации о столах";
        }

        //private void ProjectsGridExecute(object obj)
        //{
        //    AboutText = "Вывод информации о всех проектах в виде таблицы";
        //}
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
        
        public AboutMenuViewModel(AboutMenuWindow _aboutmenuWindow)
        {
            this._aboutmenuWindow = _aboutmenuWindow;
            AboutProgramCommand = new RelayComand(AboutProgramExecute);
            TaskInfoCommand = new RelayComand(TaskInfoExecute);
            AddTaskCommand = new RelayComand(AddTaskExecute);
            UpdateAndDeleteTaskCommand = new RelayComand(UpdateAndDeleteTaskExecute);
            InfSectionInfoCommand = new RelayComand(InfSectionInfoExecute);
            //AddAndDeleteInfSectionCommand = new RelayComand(AddAndDeleteInfSectionExecute);
            //PageInfoCommand = new RelayComand(PageInfoExecute);
            //AddAndDeletePageCommand = new RelayComand(AddAndDeletePageExecute);
            //TrackTimeInfoCommand = new RelayComand(TrackTimeInfoExecute);
            ReportTrackTimeInfoCommad = new RelayComand(ReportTrackTimeInfoExecute);
            ReportStateTaskForCurrentProjectInfoCommand = new RelayComand(ReportStateTaskForCurrentProjectInfoExecute);
            WorkersGridProjectCommand = new RelayComand(WorkersGridProjectExecute);
            //ProjectsGridCommand = new RelayComand(ProjectsGridExecute);
        }
        private void ToMainPage(object obj)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            _aboutmenuWindow.Close();
        }
    }
}
