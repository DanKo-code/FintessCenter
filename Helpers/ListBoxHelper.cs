using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace FitnessCenter.Helpers
{
    public static class ListBoxHelper
    {
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(IList),
                typeof(ListBoxHelper),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemsChanged)
            );

        public static IList GetSelectedItems(ListBox listBox)
        {
            return (IList)listBox.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(ListBox listBox, IList value)
        {
            listBox.SetValue(SelectedItemsProperty, value);
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox listBox = d as ListBox;
            if (listBox != null)
            {
                listBox.SelectionChanged -= OnListBoxSelectionChanged;
                listBox.SelectionChanged += OnListBoxSelectionChanged;
            }
        }

        private static void OnListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                IList selectedItems = GetSelectedItems(listBox);
                selectedItems.Clear();
                foreach (object selectedItem in listBox.SelectedItems)
                {
                    selectedItems.Add(selectedItem);
                }
            }
        }
    }
}
