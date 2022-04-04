using XamarinMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : TabbedPage
    {

        public ProjectPage(ProjectViewModel project)
        {
            InitializeComponent();
            BindingContext = project;
        }

    }
}