﻿using XamarinMVVM.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinMVVM.ViewModel
{
    public class AddProjectViewModel : INotifyPropertyChanged
    {
        public Project Project { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveCommand { protected set; get; }
        public ICommand TakePhotoCommand { protected set; get; }
        public ICommand DoPhotoCommand { protected set; get; }
        public ICommand CanselCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        public AddProjectViewModel()
        {
            Project = new Project();
            SaveCommand = new Command(AddBtn);
            TakePhotoCommand = new Command(TakePhotoAsync);
            DoPhotoCommand = new Command(AddImageBtn);
            CanselCommand = new Command(CancelBtn);
        }

        public string Name
        {
            get { return Project.Name; }
            set
            {
                Project.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Addres
        {
            get { return Project.Address; }
            set
            {
                Project.Address = value;
                OnPropertyChanged("Addres");
            }
        }

        public string Email
        {
            get { return Project.Email; }
            set
            {
                Project.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Description
        {
            get { return Project.Description; }
            set
            {
                Project.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string TelephoneNumber
        {
            get { return Project.TelephoneNumber1; }
            set
            {
                Project.TelephoneNumber1 = value;
                OnPropertyChanged("TelephoneNumber");
            }
        }

        public string ImgPath
        {
            get { return Project.ImagePath; }
            set
            {
                Project.ImagePath = value;
                OnPropertyChanged("ImgPath");
            }
        }

        private async void CancelBtn()
        {
            await Navigation.PopAsync();
        }

        private async void AddBtn()
        {
            try
            {
                App.db.SaveItem(Project);
                await Navigation.PopAsync();
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
            }

        }
        async void TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

                ImgPath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void AddImageBtn()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);

                ImgPath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
