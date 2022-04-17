using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Care_Taker.Models;
using Care_Taker.Services;
using System.Threading.Tasks;
using System.Collections;

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


        public NewCitaViewModel()
        {
            DataRefresh();
        }

        public void DataRefresh()
        {
            LoadPacientes().Wait();
            LoadEmpleados().Wait();
            LoadTipoCitas().Wait();
        }

        private async Task LoadPacientes()
        {
            var Pacientes = await PacientesDataStore.GetItemsAsync();
            LoadCollectionsData<Paciente>(Pacientes.GetEnumerator(), ref this.pacientes);
        }
        private async Task LoadEmpleados()
        {
            var Medicos = await EmpleadosDataStore.GetItemsAsync();
            LoadCollectionsData<Empleado>(Medicos.GetEnumerator(), ref this.medicos);
        }
        private async Task LoadTipoCitas()
        {
            var TipoCitas = await TipoCitasDataStore.GetItemsAsync();
            LoadCollectionsData<Tipo_Cita>(TipoCitas.GetEnumerator(), ref this.tipo_Citas);
        }

        /// <summary>
        /// Load an <see cref="IEnumerator{T}"/> to an <seealso cref="ObservableCollection{T}"/>
        /// </summary>
        /// <typeparam name="T">General type of the <see cref="IEnumerator{T}"/> and <seealso cref="ObservableCollection{T}"/></typeparam>
        /// <param name="items"><see cref="IEnumerator{T}"/> to be passed</param>
        /// <param name="collection"><seealso cref="ObservableCollection{T}"/> that recieve the data</param>
        void LoadCollectionsData<T>(IEnumerator<T> items, ref ObservableCollection<T> collection)
        {
            ObservableCollection<T> newCollection = new ObservableCollection<T>();
            if (items.Current == null)
                items.MoveNext();
            while (items.Current != null)
            {
                newCollection.Add(items.Current);
                items.MoveNext();
            }
            SetProperty(ref collection, newCollection);
        }

    }
}
