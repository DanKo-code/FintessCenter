using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.Core;
using FitnessCenter.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FitnessCenter.Views.Windows.Main.UserControls.AdminPanel
{
    /// <summary>
    /// Interaction logic for CustomMultiComboBox.xaml
    /// </summary>
    public partial class CustomMultiComboBox : UserControl
    {
        public CustomMultiComboBox()
        {
            InitializeComponent();

            LB.ItemsSource = new List<string> { "Бассейн", "Сауна", "Тренажерный зал" };
            LB.Visibility = Visibility.Collapsed;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LB.Visibility == Visibility.Collapsed)
            {
                LB.Visibility = Visibility.Visible;
                return;
            }
                

            if (LB.Visibility == Visibility.Visible)
            {
                LB.Visibility = Visibility.Collapsed;
                return;
            }
                
        }
    }
}
