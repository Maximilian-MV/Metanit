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
using Microsoft.EntityFrameworkCore;
using Metanit;

namespace Metanit
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
   
    
    public partial class UserWindow : Window
    {
        public User User { get; private set; }

        public UserWindow(User user)
        {
            InitializeComponent();
          


            User = user;
            DataContext = User;
      
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            
            if(Ima.Text.Trim() == "" || vozrast.Text == null)
            {
                MessageBox.Show("Заполните все поля");
                DialogResult = false;
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
