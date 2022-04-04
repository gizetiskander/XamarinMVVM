using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMVVM.ViewModel
{
    public class ListProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProjectViewModel> Projects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
         
        public ICommand CreateStudentCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        ProjectViewModel selectedStudent;

        public INavigation Navigation { get; set; }

        public ListProjectViewModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
            foreach(var item in App.db.GetProjects())
            {
                Projects.Add(new ProjectViewModel { Project = item });
            }
            BackCommand = new Command(Back);
        }

        public ProjectViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    ProjectViewModel tempStudent = value;
                    tempStudent.Navigation = this.Navigation;
                    selectedStudent = null;
                    OnPropertyChanged("SelectedStudent");
                    Navigation.PushAsync(new ProjectPage(tempStudent));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

      
        private void Back()
        {
            Navigation.PopAsync();
        }
    }
}
