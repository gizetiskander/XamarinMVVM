using XamarinMVVM.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMVVM.ViewModel
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public Project Project { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand EditTapCommand { protected set; get; }
        public INavigation Navigation { get; set; } 

        public ProjectViewModel() 
        {
            Project = new Project();
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

        public int Id
        {
            get { return Project.Id; }
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

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
