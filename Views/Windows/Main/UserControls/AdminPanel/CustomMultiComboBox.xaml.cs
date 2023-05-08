using FitnessCenter.BD.EntitiesBD;
using FitnessCenter.Core;
using FitnessCenter.Helpers;
using System;
using System.Collections;
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
        //public CustomMultiComboBox()
        //{
        //    InitializeComponent();

        //    //LB.ItemsSource = new List<string> { "Бассейн", "Сауна", "Тренажерный зал" };
        //    LB.Visibility = Visibility.Collapsed;

        //    this.DataContext = this;
        //}

        //#region DP

        //#region SelectedItems
        //public static readonly DependencyProperty SelectedItemsProperty =
        //    DependencyProperty.Register("SelectedItems", typeof(List<string>), typeof(CustomMultiComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //public List<string> SelectedItems
        //{
        //    get { return (List<string>)GetValue(SelectedItemsProperty); }
        //    set { SetValue(SelectedItemsProperty, value); }
        //}

        //private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedItems = new List<string>();

        //    foreach (var item in LB.SelectedItems)
        //    {
        //        SelectedItems.Add(item.ToString());
        //    }
        //}
        //#endregion

        //#region NewItemName
        //public static readonly DependencyProperty NewItemNameProperty =
        //    DependencyProperty.Register("NewItemName", typeof(string), typeof(CustomMultiComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //public string NewItemName
        //{
        //    get { return (string)GetValue(NewItemNameProperty); }
        //    set 
        //    {
        //        SetValue(NewItemNameProperty, value);
        //    }
        //}

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    NewItemName = TB.Text;
        //}
        //#endregion

        //#region ItemSource
        //public static readonly DependencyProperty ItemsSourceProperty =
        //DependencyProperty.Register("ItemsSource", typeof(List<string>), typeof(CustomMultiComboBox),
        //new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnItemsSourceChanged));

        //public List<string> ItemsSource
        //{
        //    get { return (List<string>)GetValue(ItemsSourceProperty); }
        //    set { SetValue(ItemsSourceProperty, value); }
        //}

        //private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var comboBox = d as CustomMultiComboBox;
        //    if (comboBox != null)
        //    {
        //        comboBox.LB.ItemsSource = e.NewValue as List<string>;
        //    }
        //}
        //#endregion

        //#region ButtonCommand
        //public ICommand ButtonCommand
        //{
        //    get { return (ICommand)GetValue(ButtonCommandProperty); }
        //    set { SetValue(ButtonCommandProperty, value); }
        //}

        //public static readonly DependencyProperty ButtonCommandProperty =
        //        DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CustomMultiComboBox));

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonCommand.Execute(null);
        //}
        //#endregion

        //#endregion





        //private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (LB.Visibility == Visibility.Collapsed)
        //    {
        //        LB.Visibility = Visibility.Visible;
        //        return;
        //    }


        //    if (LB.Visibility == Visibility.Visible)
        //    {
        //        LB.Visibility = Visibility.Collapsed;
        //        return;
        //    }
        //}

        public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(List<string>), typeof(CustomMultiComboBox), new PropertyMetadata(null));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CustomMultiComboBox), new PropertyMetadata(null));

        public static readonly DependencyProperty TextChangedProperty =
            DependencyProperty.Register("TextChanged", typeof(Action<string>), typeof(CustomMultiComboBox), new PropertyMetadata(null));

        public CustomMultiComboBox()
        {
            InitializeComponent();
            DataContext = this;
            LB.Visibility = Visibility.Collapsed;
        }

        public List<string> ItemsSource
        {
            get { return (List<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #region NewItemName
        public static readonly DependencyProperty NewItemNameProperty =
            DependencyProperty.Register("NewItemName", typeof(string), typeof(CustomMultiComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string NewItemName
        {
            get { return (string)GetValue(NewItemNameProperty); }
            set
            {
                SetValue(NewItemNameProperty, value);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewItemName = textBox.Text;
        }
        #endregion

        private void Grid_MouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (LB.Visibility == Visibility.Collapsed)
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
