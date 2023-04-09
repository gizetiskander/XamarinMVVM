using XamarinMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
    {
        public EditProjectViewModel ViewModel { get; private set; }

        public EditProjectPage(EditProjectViewModel proj)
        {
            InitializeComponent();
            ViewModel = proj;
            this.BindingContext = proj;
        }
    }
}