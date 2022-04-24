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
using System.Threading.Tasks;

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
            LoadDataCommand = new Command(async () => await LoadData());
        }

        public ICommand LoadDataCommand { get; }
        public ICommand OnNewCitaButton_Click { get; }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task LoadData()
        {
            IsBusy = true;
            citasAppointments.Clear();
            var Citas = await data.GetItems(AppData.Empleado.CodEmpl, true);
            foreach(Cita cita in Citas)
            {
                if((cita.Fecha.Date.Add(cita.Hora)) < DateTime.Now && cita.Status)
                {
                    cita.Status = false;
                    await data.UpdateItem(cita);
                }
                CitasAppointments.Add(new CalendarInlineEvent()
                {
                    StartTime = cita.Fecha.Date.Add(cita.Hora),
                    EndTime = cita.Fecha.Date.Add(cita.Hora).AddMinutes(cita.Tipo.Duracion),
                    Subject = $"Cita {cita.Tipo.Descripcion} con {cita.Paciente.Persona.Nombre} {cita.Paciente.Persona.Apellidos}",
                    AutomationId=cita.CodCita.ToString()
                });
            }
            IsBusy = false;
        }

    }
}