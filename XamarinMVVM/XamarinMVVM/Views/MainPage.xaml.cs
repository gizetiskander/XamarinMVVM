using XamarinMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ListProjectViewModel { Navigation = this.Navigation};
        }
    }
}