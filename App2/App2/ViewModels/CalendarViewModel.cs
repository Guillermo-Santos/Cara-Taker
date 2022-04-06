using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {

        private List<DateTime> selectedDates = new List<DateTime>();
        private CalendarEventCollection citasAppointments = new CalendarEventCollection();
        private ScheduleAppointmentCollection scheduleAppointments = new ScheduleAppointmentCollection();
        public List<DateTime> SelectedDates
        {
            get => selectedDates;
            set => SetProperty(ref selectedDates, value);
        }
        public CalendarEventCollection CitasAppointments
        {
            get => citasAppointments;
            set => SetProperty(ref citasAppointments, value);
        }
        public ScheduleAppointmentCollection ScheduleAppointments
        {
            get => scheduleAppointments;
            set => SetProperty(ref scheduleAppointments, value);
        }

        public CalendarViewModel()
        {
            Title = "Agenda";
            CitasAppointments.Add(new CalendarInlineEvent());
            CitasAppointments[0].StartTime = DateTime.Now;
            CitasAppointments[0].EndTime = DateTime.Now.AddHours(2);
            CitasAppointments[0].Subject = "Cita con Ana Rosa";
            ScheduleAppointments.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                Subject = "Cita con Ana Rosa",
                Location = "Hutchison road",
            });
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}