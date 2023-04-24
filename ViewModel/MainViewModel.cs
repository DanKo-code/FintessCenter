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
using FitnessCenter.Models;

namespace FitnessCenter.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        //Для слайдера
        List<string> SliderImages = new List<string>();
        int SliderImagesIndex = 0;

        //Для абонементов
        

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

        #region AbonementItems
        private List<Abonement> _abonementItems = new List<Abonement> 
        {
            new Abonement{ Name = "Взрослая карта на 1 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 2 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 3 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 4 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 5 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 6 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 7 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 8 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 9 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 10 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 11 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 12 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 13 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 14 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
            new Abonement{ Name = "Взрослая карта на 15 месяца", Age = 14, Amount = 0, Price=17000, Validity = 3, VisitingTime = 17},
        };

        public List<Abonement> AbonementItems
        {
            get => _abonementItems;

            set
            {
                if (_abonementItems != value)
                {
                    _abonementItems = value;
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

        #region GoAbonements
        public ICommand GoAbonements { get; }

        private bool CanGoAbonementsCommand(object p) => true;

        private void OnGoAbonementsCommand(object p)
        {
            
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
