using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using FitnessCenter.BD.EntitiesBD.Repositories;
using FitnessCenter.BD.EntitiesBD;
using System.ComponentModel;

namespace FitnessCenter.Helpers
{
    public class MyListBox : ListBox
    {
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(ICollection<Services>), typeof(MyListBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        

        public ICollection<Services> SelectedItems
        {
            get 
            {
                return (ICollection<Services>)GetValue(SelectedItemsProperty); 
            }
            set 
            {
                SetValue(SelectedItemsProperty, value); 
            }
        }



        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            if(e.AddedItems.Count != 0)
            {
                foreach (Services item in e.AddedItems)
                {
                    if (SelectedItems.Contains(item))
                        return;
                    SelectedItems.Add(item);
                }
                SelectedItems = SelectedItems;
            }

            if(e.RemovedItems.Count != 0)
            {
                foreach (Services item in e.RemovedItems)
                {
                    SelectedItems.Remove(item);
                }
                SelectedItems = SelectedItems;
            }
            

        }


        public MyListBox()
        {
            this.IsVisibleChanged += MyListBox_VisibilityChanged;
        }

        private void MyListBox_VisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(this.Visibility == Visibility.Visible)
            {
                this.SetSelectedItems(SelectedItems);
            }
        }

        
    }
}
