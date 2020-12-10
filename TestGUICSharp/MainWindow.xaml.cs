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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestGUICSharp.Data;

namespace TestGUICSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ProductDbContext context;
        readonly ScheduleDbContext scheduleDbContext;
        Product NewProduct = new Product();
        Schedule NewSchedule = new Schedule();
        Product selectedProduct = new Product();
        Schedule selectedSchedule = new Schedule();
        public MainWindow(ProductDbContext context, ScheduleDbContext scheduleDbContext)
        {
            this.context = context;
            this.scheduleDbContext = scheduleDbContext;
            InitializeComponent();
            GetProducts();
            NewProductGrid.DataContext = NewProduct;
            NewScheduleGrid.DataContext = NewSchedule;
        }
        private void GetProducts()
        {
            ProductDG.ItemsSource = context.Products.ToList();
            ScheduleDG.ItemsSource = scheduleDbContext.Schedules.ToList();
        }
        private void AddItem(object s, RoutedEventArgs e)
        {
            context.Products.Add(NewProduct);
            context.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            NewProductGrid.DataContext = NewProduct;
        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedProduct);
            context.SaveChanges();
            GetProducts();
        }
        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Product;
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            GetProducts();
        }

        private void AddSchedule(object s, RoutedEventArgs e)
        {
            NewSchedule.Time = DateTime.Now;
            scheduleDbContext.Schedules.Add(NewSchedule);
            scheduleDbContext.SaveChanges();
            GetProducts();
            NewSchedule = new Schedule();
            NewScheduleGrid.DataContext = NewSchedule;
        }
        private void UpdateSchedule(object s, RoutedEventArgs e)
        {
            selectedSchedule.Time = DateTime.Now;
            scheduleDbContext.Update(selectedSchedule);
            scheduleDbContext.SaveChanges();
            GetProducts();
        }
        private void SelectScheduleToEdit(object s, RoutedEventArgs e)
        {
            selectedSchedule = (s as FrameworkElement).DataContext as Schedule;
            UpdateScheduleGrid.DataContext = selectedSchedule;
        }
        private void DeleteSchedule(object s, RoutedEventArgs e)
        {
            var scheduleToDelete = (s as FrameworkElement).DataContext as Schedule;
            scheduleDbContext.Schedules.Remove(scheduleToDelete);
            scheduleDbContext.SaveChanges();
            GetProducts();
        }
    }
}
