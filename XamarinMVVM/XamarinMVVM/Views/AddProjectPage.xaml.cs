using XamarinMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProjectPage : ContentPage
    {
        private string path;
        public AddProjectPage(AddProjectViewModel projectViewModel)
        {
            InitializeComponent();
            BindingContext = projectViewModel;
        }
    }
}