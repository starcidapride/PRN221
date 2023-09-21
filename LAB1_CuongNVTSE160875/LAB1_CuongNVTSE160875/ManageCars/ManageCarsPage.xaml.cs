using BussinessObjects;
using DataAccessObjects.DAOs;
using DataAccessObjects.Models;
using Repositories.CarRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

namespace WPFView
{
    public partial class ManageCarsPage : Page
    {
        public ManageCarsPage()
        {
            InitializeComponent();

            RenderCarList();
        }

        private void RenderCarList(string? searchValue = null)
        {
            if (searchValue == null)
            {
                DataGrid.ItemsSource = AdministratorBussiness.GetCars();
            } else
            {
                DataGrid.ItemsSource = AdministratorBussiness.GetCars(searchValue);
            }
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            var addCarWindow = new AddCarWindow();
            var dialog = addCarWindow.ShowDialog();
            if (dialog == true)
            {
                RenderCarList();
            }
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            var car = (CarInformation) DataGrid.SelectedItem;

            if (car == null) return;

            var updateCarWindow = new UpdateCarWindow(car);
            var dialog = updateCarWindow.ShowDialog();
            if (dialog == true)
            {
                RenderCarList();
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            var car = (CarInformation)DataGrid.SelectedItem;

            if (car == null) return;

            AdministratorBussiness.AdministratorDeleteCar(car);

            RenderCarList();
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            var searchValue = SearchValue.Text;
            
            RenderCarList(searchValue);
        }
    }
    }
