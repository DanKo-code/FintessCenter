using FitnessCenter.Core;
using FitnessCenter.Views.Windows.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FitnessCenter.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        #region Accessors (helpers for ui design)

        #region SliderImage
        int temp = Application.Current.Resources.Values.Count;

        ICollection<object> list = Application.Current.Resources.MergedDictionaries[1];

        private string _sliderImage = "dfvdf";

        public string SliderImage
        {
            get => _sliderImage;

            set
            {
                if (_sliderImage != value)
                {
                    _sliderImage = value;
                    OnPropertyChanged(nameof(SliderImage));
                }
            }
        }
        #endregion



        #endregion

        #region Commands

        //#region ShowLogin
        //public ICommand ShowLoginCommand { get; }

        //private bool CanShowLoginCommand(object p) => true;

        //private void OnShowLoginCommand(object p)
        //{
        //    LoginVisibility = Visibility.Visible;
        //    RegisterVisibility = Visibility.Collapsed;
        //}
        //#endregion



        #endregion

        public MainViewModel()
        {
            //ShowLoginCommand = new RelayCommand(OnShowLoginCommand, CanShowLoginCommand);
        }
    }
}
