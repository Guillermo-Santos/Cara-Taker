using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Care_Taker.Models;
using Care_Taker.Services;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{
    public class PacienteDetailViewModel : BaseViewModel
    {
        readonly IDataStore<Paciente> PacienteDataStore = DependencyService.Get<IDataStore<Paciente>>();
        readonly IDataStore<Cita> CitasDataStore = DependencyService.Get<IDataStore<Cita>>();
        readonly IDataStore<Telefono> TelefonosDataStore = DependencyService.Get<IDataStore<Telefono>>();
        readonly IDataStore<Email> EmailsDataStore = DependencyService.Get<IDataStore<Email>>();

        private int codPaci;
        private Persona persona;
        private Tipo_Sangre tipoSangre;
        private ObservableCollection<Cita> citas = new ObservableCollection<Cita>();
        private ObservableCollection<Telefono> telefonos = new ObservableCollection<Telefono>();
        private ObservableCollection<Email> emails = new ObservableCollection<Email>();

        public Persona Persona
        {
            get => persona;
            set => SetProperty(ref persona, value);
        }
        public Tipo_Sangre TipoSangre
        {
            get => tipoSangre;
            set => SetProperty(ref tipoSangre, value);
        }
        public int CodPaci
        {
            get => codPaci;
            set => SetProperty(ref codPaci, value);
        }
        public ObservableCollection<Cita> Citas
        {
            get => citas;
            set => SetProperty(ref citas, value);
        }
        public ObservableCollection<Telefono> Telefonos
        {
            get => telefonos;
            set => SetProperty(ref telefonos, value);
        }
        public ObservableCollection<Email> Emails
        {
            get => emails;
            set => SetProperty(ref emails, value);
        }
        public PacienteDetailViewModel() => Title = "Detalles de paciente";
        public PacienteDetailViewModel(int CodPaci)
        {
            this.CodPaci = CodPaci;
            Title = "Detalles de paciente";
            LoadData = new Command(async () => await LoadPacienteData());
        }

        public ICommand LoadData { get; }

        async Task LoadPacienteData()
        {
            IsBusy = true;
            var Paciente = await PacienteDataStore.GetItem(CodPaci,true);
            Persona = Paciente.Persona;
            TipoSangre = Paciente.TipoSangre;
            Emails.Clear();
            var emails = await EmailsDataStore.GetItems(CodPaci);
            foreach(var email in emails)
            {
                Emails.Add(email);
            }
            Telefonos.Clear();
            var telefonos = await TelefonosDataStore.GetItems(CodPaci);
            foreach (var telefon in telefonos)
            {
                Telefonos.Add(telefon);
            }
            if (AppData.byPaci != true)
            {
                AppData.byPaci = true;
            }
            var citas = await CitasDataStore.GetItems(CodPaci, true);
            Citas.Clear();
            foreach (var cita in citas)
            {
                cita.Fecha = cita.Fecha.Date.Add(cita.Hora);
                Citas.Add(cita);
            }
            AppData.byPaci = (AppData.Paciente != null);
            IsBusy = false;
        }
    }
}
