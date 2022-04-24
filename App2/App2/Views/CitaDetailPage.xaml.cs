using Care_Taker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Care_Taker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitaDetailPage : ContentPage
    {
        public CitaDetailPage(int CodCita)
        {
            InitializeComponent();
            this.BindingContext = new CitaDetailViewModel(CodCita);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((CitaDetailViewModel)BindingContext).OnAppearing();
        }
    }
}