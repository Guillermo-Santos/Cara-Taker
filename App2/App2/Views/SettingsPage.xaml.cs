
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Care_Taker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            my.SelectedItem.ToString();
        }
    }
}