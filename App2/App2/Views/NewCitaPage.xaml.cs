using Care_Taker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Care_Taker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCitaPage : ContentPage
    {
        public NewCitaPage()
        {
            InitializeComponent();
            this.BindingContext = new NewCitaPage();
        }
    }
}