using FitnessCenter.Core;
using FitnessCenter.Views.Windows.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FitnessCenter.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        List<string> SliderImages = new List<string>();
        int SliderImagesIndex = 0;

        #region Accessors (helpers for ui design)

        #region HeaderText
        private string _headerText = "Главная";

        public string HeaderText
        {
            get => _headerText;

            set
            {
                if(_headerText != value)
                {
                    _headerText = value;
                    OnPropertyChanged(nameof(HeaderText));
                }
            }
        }
        #endregion

        #region SliderImage
        private string _sliderImage;

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

        #region LeftImageCpmmand
        public ICommand LeftImageCpmmand { get; }

        private bool CanLeftImageCommand(object p)
        {
            return SliderImages.Count > 0;
        }

        private void OnLeftImageCommand(object p)
        {
            if ((--SliderImagesIndex) < 0)
            {
                SliderImagesIndex = SliderImages.Count - 1;
            }

            SliderImage = SliderImages[SliderImagesIndex];
        }
        #endregion

        #region RightImageCpmmand
        public ICommand RightImageCpmmand { get; }

        private bool CanRightImageCommand(object p) => SliderImages.Count > 0;

        private void OnRightImageCommand(object p)
        {
            if ((++SliderImagesIndex) == (SliderImages.Count))
            {
                SliderImagesIndex = 0;
            }

            SliderImage = SliderImages[SliderImagesIndex];
        }
        #endregion

        #endregion

        public MainViewModel()
        {
            LeftImageCpmmand = new RelayCommand(OnLeftImageCommand, CanLeftImageCommand);
            RightImageCpmmand = new RelayCommand(OnRightImageCommand, CanRightImageCommand);

            //Найти словарь
            var imagesDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source?.OriginalString == "/Resources/ImagesDictionary/Images.xaml");
            
            //Переписать с него данные
            if (imagesDict != null)
            {
                foreach (string key in imagesDict.Values)
                {
                    SliderImages.Add(key);
                    // обрабатываем каждый элемент в словаре
                }
            }

            if(SliderImages.Count > 0)
            SliderImage = SliderImages[0];
        }
    }
}
