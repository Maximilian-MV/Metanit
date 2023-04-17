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
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;


namespace Metanit
{
    public partial class MainWindow : Window
    {

        ApplicationContext db = new ApplicationContext();
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
                Binding binding = new Binding();
                binding.ElementName = "usersList";// Элемент-источник
                binding.Path = new PropertyPath("Text"); // Свойство эелмента-источника
                cmbFarm.SetBinding(ComboBox.TextProperty, binding); // Установка привязки для эдемента источника 

        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Users.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = new { usersList = db.Users.Local.ToObservableCollection() };


        }
        // Open
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Open Open = new Open(new User());
            if (Open.ShowDialog() == true)
            {

                User user= (User)this.Resources["cmbFarm"];
                user.Name = user.Name; // Меняем с Google на LG


                User User = Open.User;
                db.Users.Add(User);
                db.SaveChanges();
            }
        } 
        
        private void Open_Click_2(object sender, RoutedEventArgs e)
        {
            Open Open = new Open(new User());
            if (Open.ShowDialog() == true)
            { 
                User User = Open.User;
                db.Users.Add(User);
                db.SaveChanges();
            }
        }
    }
}


