using Xamarin.Forms;

namespace Care_Taker.Views
{
    public partial class SimpleAgendaPage : ContentPage
    {
        public SimpleAgendaPage()
        {
            InitializeComponent();
        }

        private void calendar_InlineItemTapped(object sender, Syncfusion.SfCalendar.XForms.InlineItemTappedEventArgs e)
        {
            var appointment = e.InlineEvent;
            DisplayAlert(appointment.Subject, appointment.StartTime.ToString() + " to " + appointment.EndTime.TimeOfDay.ToString(), "ok");

        }
    }
}