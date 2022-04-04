using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMVVM.Models;

namespace XamarinMVVM.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1(Project project)
        {
            InitializeComponent();

        }
    }
}