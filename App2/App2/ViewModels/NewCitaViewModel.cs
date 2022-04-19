using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Care_Taker.Models;
using Care_Taker.Services;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Input;
using System.Diagnostics;

namespace Care_Taker.ViewModels
{
    public class NewCitaViewModel : BaseViewModel
    {
        readonly IDataStore<Cita> CitaDataStore = DependencyService.Get<IDataStore<Cita>>();
        readonly IDataStore<Paciente> PacientesDataStore = DependencyService.Get<IDataStore<Paciente>>();
        readonly IDataStore<Empleado> EmpleadosDataStore = DependencyService.Get<IDataStore<Empleado>>();
        readonly IDataStore<Tipo_Cita> TipoCitasDataStore = DependencyService.Get<IDataStore<Tipo_Cita>>();

        private ObservableCollection<Paciente> pacientes = new ObservableCollection<Paciente>();
        private ObservableCollection<Empleado> medicos = new ObservableCollection<Empleado>();
        private ObservableCollection<Tipo_Cita> tipo_Citas = new ObservableCollection<Tipo_Cita>();
        private Paciente selectedPaciente;
        private Empleado selectedEmpleado;
        private Tipo_Cita selectedTipoCita;
        private DateTime selectedDate;
        private DateTime minDate;
        public ICommand onSave;
        public ICommand onClean;

        public ObservableCollection<Paciente> Pacientes { 
            get => pacientes; 
            set => SetProperty(ref pacientes, value);
            
        }
        public ObservableCollection<Empleado> Medicos { 
            get => medicos; 
            set => SetProperty(ref medicos, value); 
        }
        public ObservableCollection<Tipo_Cita> Tipo_Citas { 
            get => tipo_Citas; 
            set => SetProperty(ref tipo_Citas, value); 
        }

        public Paciente SelectedPaciente { 
            get => selectedPaciente;
            set => SetProperty(ref selectedPaciente, value);
        }
        public Empleado SelectedEmpleado
        {
            get => selectedEmpleado;
            set => SetProperty(ref selectedEmpleado, value);
        }
        public Tipo_Cita SelectedTipoCita { 
            get => selectedTipoCita;
            set => SetProperty(ref selectedTipoCita, value);
        }
        public DateTime SelectedDate
        {
            get => selectedDate;
            set => SetProperty(ref selectedDate, value);
        }
        public DateTime MinDate
        {
            get => minDate;
            set => SetProperty(ref minDate, value);
        }

        public ICommand OnSave
        {
            get => onSave;
            set => SetProperty(ref onSave, value);
        }
        public ICommand OnClean
        {
            get => onClean;
            set => SetProperty(ref onClean, value);
        }
        public NewCitaViewModel()
        {
            Title = "Nueva cita";

            MinDate = DateTime.Now;
            DataRefresh().Wait();

            OnSave = new Command(() => Save().Wait());
            OnClean = new Command(() => DataRefresh().Wait());
        }

        public async Task Save()
        {
            IsBusy = true;

            try
            {
                CitaDataStore.AddItemAsync(new Cita()
                {
                    CodPaci = SelectedPaciente.CodPaci,
                    CodEmpl = SelectedEmpleado.CodEmpl,
                    CodTpCt = SelectedTipoCita.CodTpCt,
                    Fecha = SelectedDate,
                    Status = true,
                    Paciente = selectedPaciente,
                    Empleado = SelectedEmpleado,
                    Tipo = selectedTipoCita
                }).Wait();
                await DataRefresh();
            }
            catch (Exception ex)
            {
                await ViewService.DisplayAlert("Error",ex.Message,"Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task DataRefresh()
        {
            SelectedDate = DateTime.Now;
            MinDate = DateTime.Now;
            await LoadPacientes();
            await LoadEmpleados();
            await LoadTipoCitas();

            if (AppData.Empleado != null && Medicos.Contains(AppData.Empleado))
            {
                SelectedEmpleado = AppData.Empleado;
            }
            else
            {
                SelectedEmpleado = Medicos[0];
            }
            SelectedTipoCita = Tipo_Citas[0];
            SelectedPaciente = Pacientes[0];
        }

        private async Task LoadPacientes()
        {
            var Pacientes = await PacientesDataStore.GetItemsAsync();
            LoadCollectionsData<Paciente>(ref Pacientes, ref this.pacientes);
        }
        private async Task LoadEmpleados()
        {
            var Medicos = await EmpleadosDataStore.GetItemsAsync();
            LoadCollectionsData<Empleado>(ref Medicos, ref this.medicos);
        }
        private async Task LoadTipoCitas()
        {
            var TipoCitas = await TipoCitasDataStore.GetItemsAsync();
            LoadCollectionsData<Tipo_Cita>(ref TipoCitas, ref this.tipo_Citas);
        }



        /// <summary>
        /// Load an <see cref="IEnumerable{T}"/> to an <seealso cref="ObservableCollection{T}"/>
        /// </summary>
        /// <typeparam name="T">General type of the <see cref="IEnumerable{T}"/> and <seealso cref="ObservableCollection{T}"/></typeparam>
        /// <param name="items"><see cref="IEnumerable{T}"/> to be passed</param>
        /// <param name="collection"><seealso cref="ObservableCollection{T}"/> that recieve the data</param>
        void LoadCollectionsData<T>(ref IEnumerable<T> items, ref ObservableCollection<T> collection)
        {
            ObservableCollection<T> newCollection = new ObservableCollection<T>();

            foreach(T item in items)
            {
                newCollection.Add(item);
            }

            SetProperty(ref collection, newCollection);
        }

    }
}
