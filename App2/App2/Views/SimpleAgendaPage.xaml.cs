using Xamarin.Forms;
using Care_Taker.ViewModels;
namespace Care_Taker.Views
{
    public partial class SimpleAgendaPage : ContentPage
    {
        public SimpleAgendaPage()
        {
            InitializeComponent();
            this.BindingContext = new SimpleAgendaViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((SimpleAgendaViewModel)BindingContext).OnAppearing();
        }
        async void calendar_InlineItemTapped(object sender, Syncfusion.SfCalendar.XForms.InlineItemTappedEventArgs e)
        {
            var appointment = e.InlineEvent;
            await ((SimpleAgendaViewModel)BindingContext).ViewService.PushAsync(new CitaDetailPage(int.Parse(appointment.AutomationId)));
        }
    }
}