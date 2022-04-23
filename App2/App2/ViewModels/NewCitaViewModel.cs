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
        #region DataStores
        readonly IDataStore<Cita> CitaDataStore = DependencyService.Get<IDataStore<Cita>>();
        readonly IDataStore<Paciente> PacientesDataStore = DependencyService.Get<IDataStore<Paciente>>();
        readonly IDataStore<Empleado> EmpleadosDataStore = DependencyService.Get<IDataStore<Empleado>>();
        readonly IDataStore<Tipo_Cita> TipoCitasDataStore = DependencyService.Get<IDataStore<Tipo_Cita>>();
        readonly IDataStore<Examen_Cita> ExamenCitaDataStore = DependencyService.Get<IDataStore<Examen_Cita>>();
        #endregion
        #region Properties
        private List<Paciente> pacientes = new List<Paciente>();
        private List<Empleado> medicos = new List<Empleado>();
        private List<Tipo_Cita> tipo_Citas = new List<Tipo_Cita>();
        private List<Examen_Cita> examenes_Citas = new List<Examen_Cita>();
        private List<Examen_Cita> examenes_Cita = new List<Examen_Cita>();
        private Paciente selectedPaciente;
        private Empleado selectedEmpleado;
        private Tipo_Cita selectedTipoCita;
        private Examen_Cita selectedExamen;
        private DateTime selectedDate;
        private TimeSpan selectedTime = TimeSpan.Zero;
        private DateTime minDate;
        private ICommand onSave;
        private ICommand onClean;
        private ICommand onAdd;
        #endregion
        #region Fields
        public List<Paciente> Pacientes { 
            get => pacientes; 
            set => SetProperty(ref pacientes, value);
            
        }
        public List<Empleado> Medicos { 
            get => medicos; 
            set => SetProperty(ref medicos, value); 
        }
        public List<Tipo_Cita> Tipo_Citas { 
            get => tipo_Citas; 
            set => SetProperty(ref tipo_Citas, value); 
        }
        public List<Examen_Cita> Examenes_Citas { 
            get => examenes_Citas;
            set => SetProperty(ref examenes_Citas, value);
        }
        public List<Examen_Cita> Examenes_Cita
        {
            get => examenes_Cita;
            set => SetProperty(ref examenes_Cita, value);
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
        public Examen_Cita SelectedExamen { 
            get => selectedExamen;
            set => SetProperty(ref selectedExamen, value);
        }
        public DateTime SelectedDate
        {
            get => selectedDate;
            set => SetProperty(ref selectedDate, value);
        }
        public TimeSpan SelectedTime
        {
            get => selectedTime;
            set => SetProperty(ref selectedTime, value);
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
        public ICommand OnAdd
        {
            get => onAdd;
            set => SetProperty(ref onAdd, value);
        }
        #endregion

        public NewCitaViewModel()
        {
            Title = "Nueva cita";

            DataRefresh().Wait();

            OnSave = new Command(async() => await Save());
            OnClean = new Command(async() => await DataRefresh());
            OnAdd = new Command(async () => await AddExamn());
        }
        #region Methods
        public async Task<bool> Save()
        {
            Cita cita = new Cita()
            {
                CodPaci = SelectedPaciente.CodPaci,
                CodEmpl = SelectedEmpleado.CodEmpl,
                CodTpCt = SelectedTipoCita.CodTpCt,
                Fecha = SelectedDate.Date,
                Hora = SelectedTime,
                Status = true,
                Paciente = SelectedPaciente,
                Empleado = SelectedEmpleado,
                Tipo = selectedTipoCita
            };
            CitaDataStore.AddItem(cita).Wait();
            await ClearData();
            await ViewService.DisplayAlert("Cita agendada con exito", 
                                           "Su cita con se agendo correctamente", 
                                           "Aceptar");
            return await Task.FromResult(true);
        }
        public Task<bool> ClearData()
        {
            MinDate = DateTime.Now.Date;
            SelectedTime = MinDate.TimeOfDay;
            SelectedDate = DateTime.Now;
            SelectedPaciente = null;
            SelectedTipoCita = null;
            SelectedExamen = null;
            if (AppData.Empleado != null)
            {
                SelectedEmpleado = AppData.Empleado;
            }
            else
            {
                SelectedEmpleado = null;
            }
            LoadExamenesCitas().Wait();
            return Task.FromResult(true);
        }
        public async Task<bool> AddExamn()
        {
            if(SelectedExamen != null)
            {
                examenes_Cita.Add(SelectedExamen);
                examenes_Citas.Remove(SelectedExamen);
                SelectedExamen = null;
            }
            return await Task.FromResult(true);
        }
        public async Task DataRefresh()
        {

            MinDate = DateTime.Now;
            SelectedDate = MinDate;
            SelectedTime = MinDate.TimeOfDay;

            if (AppData.Empleado != null)
            {
                Medicos.Add(AppData.Empleado);
                SelectedEmpleado = AppData.Empleado;
            }
            else
            {
                await LoadEmpleados();
            }
            
            await LoadPacientes();
            await LoadTipoCitas();
            await LoadExamenesCitas();
        }
        private async Task LoadPacientes()
        {
            var Pacientes = await PacientesDataStore.GetItems();
            LoadCollectionsData<Paciente>(ref Pacientes, ref this.pacientes);
        }
        private async Task LoadEmpleados()
        {
            var Medicos = await EmpleadosDataStore.GetItems();
            LoadCollectionsData<Empleado>(ref Medicos, ref this.medicos);
        }
        private async Task LoadTipoCitas()
        {
            var TipoCitas = await TipoCitasDataStore.GetItems();
            LoadCollectionsData<Tipo_Cita>(ref TipoCitas, ref this.tipo_Citas);
        }
        private async Task LoadExamenesCitas()
        {
            var ExamenesCitas = await ExamenCitaDataStore.GetItems();
            LoadCollectionsData<Examen_Cita>(ref ExamenesCitas, ref examenes_Citas);
        }
        #endregion


        /// <summary>
        /// Load an <see cref="IEnumerable{T}"/> to a <seealso cref="List{T}"/>
        /// </summary>
        /// <typeparam name="T">General type of the <see cref="IEnumerable{T}"/> and <seealso cref="ObservableCollection{T}"/></typeparam>
        /// <param name="items"><see cref="IEnumerable{T}"/> to be passed</param>
        /// <param name="list"><seealso cref="List{T}"/> that recieve the data</param>
        void LoadCollectionsData<T>(ref IEnumerable<T> items, ref List<T> list)
        {
            List<T> newList = new List<T>();

            foreach(T item in items)
            {
                newList.Add(item);
            }

            SetProperty(ref list, newList);
        }

    }
}
