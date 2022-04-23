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

        private void calendar_InlineItemTapped(object sender, Syncfusion.SfCalendar.XForms.InlineItemTappedEventArgs e)
        {
            var appointment = e.InlineEvent;
            DisplayAlert(appointment.Subject, appointment.StartTime.TimeOfDay.ToString(@"hh\:mm") + " to " + appointment.EndTime.TimeOfDay.ToString(@"hh\:mm"), "ok");

        }
    }
}