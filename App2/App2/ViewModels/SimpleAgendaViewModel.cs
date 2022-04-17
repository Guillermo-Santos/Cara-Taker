using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Care_Taker.Models;
using Care_Taker.Services;
using Care_Taker.Views;

namespace Care_Taker.ViewModels
{
    public class SimpleAgendaViewModel : BaseViewModel
    {
        private List<DateTime> selectedDates = new List<DateTime>();
        private CalendarEventCollection citasAppointments = new CalendarEventCollection();
        private ScheduleAppointmentCollection scheduleAppointments = new ScheduleAppointmentCollection();
        readonly IDataStore<Cita> data = DependencyService.Get<IDataStore<Cita>>();

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

        public SimpleAgendaViewModel()
        {
            Title = "Agenda";
            FillData();
            //CitasAppointments.Add(new CalendarInlineEvent());
            //CitasAppointments[0].StartTime = DateTime.Now;
            //CitasAppointments[0].EndTime = DateTime.Now.AddHours(2);
            //CitasAppointments[0].Subject = "Cita con Ana Rosa";
            //ScheduleAppointments.Add(new ScheduleAppointment()
            //{
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now.AddHours(2),
            //    Subject = "Cita con Ana Rosa",
            //    Location = "Hutchison road",
            //    i
            //});
            OnNewCitaButton_Click = new Command(async () => await ViewService.PushAsync(new NewCitaPage()));
        }

        public ICommand OnNewCitaButton_Click { get; }

        async void FillData()
        {

            var Citas = await data.GetItemsAsync(AppData.Empleado.CodEmpl);
            foreach (Cita cita in Citas)
            {
                CitasAppointments.Add(new CalendarInlineEvent()
                {
                    StartTime = cita.Fecha,
                    EndTime = (cita.Fecha).AddMinutes(cita.Tipo.Duracion),
                    Subject = $"Cita con {cita.Paciente.Persona.Nombre} {cita.Paciente.Persona.Apellidos}"
                });
            }


        }

    }
}