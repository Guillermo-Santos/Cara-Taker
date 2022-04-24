using Care_Taker.Models;
using Care_Taker.Services;
using Care_Taker.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{

    public class NewCitaViewModel : BaseViewModel
    {
        #region DataStores
        readonly IDataStore<Cita> CitaDataStore = DependencyService.Get<IDataStore<Cita>>();
        readonly IDataStore<Paciente> PacientesDataStore = DependencyService.Get<IDataStore<Paciente>>();
        readonly IDataStore<Empleado> EmpleadosDataStore = DependencyService.Get<IDataStore<Empleado>>();
        readonly IDataStore<Tipo_Cita> TipoCitasDataStore = DependencyService.Get<IDataStore<Tipo_Cita>>();
        readonly IDataStore<Tipo_Examen> TipoExamenesDataStore = DependencyService.Get<IDataStore<Tipo_Examen>>();
        readonly IDataStore<Examen_Cita> ExamenCitaDataStore = DependencyService.Get<IDataStore<Examen_Cita>>();
        #endregion
        #region Properties
        private ObservableCollection<Paciente> pacientes = new ObservableCollection<Paciente>();
        private ObservableCollection<Empleado> medicos = new ObservableCollection<Empleado>();
        private ObservableCollection<Tipo_Cita> tipo_Citas = new ObservableCollection<Tipo_Cita>();
        private ObservableCollection<Tipo_Examen> tipo_Examenes = new ObservableCollection<Tipo_Examen>();
        private ObservableCollection<Tipo_Examen> examenes_Cita = new ObservableCollection<Tipo_Examen>();
        private Paciente selectedPaciente;
        private Empleado selectedEmpleado;
        private Tipo_Cita selectedTipoCita;
        private Tipo_Examen selectedExamen;
        private Tipo_Examen selectedTipoExam;
        private DateTime selectedDate;
        private TimeSpan selectedTime = TimeSpan.Zero;
        private DateTime minDate;
        private ICommand onSave;
        private ICommand onClean;
        private ICommand onAdd;
        private ICommand onRemove;
        #endregion
        #region Fields
        public ObservableCollection<Paciente> Pacientes
        {
            get => pacientes;
            set => SetProperty(ref pacientes, value);

        }
        public ObservableCollection<Empleado> Medicos
        {
            get => medicos;
            set => SetProperty(ref medicos, value);
        }
        public ObservableCollection<Tipo_Cita> Tipo_Citas
        {
            get => tipo_Citas;
            set => SetProperty(ref tipo_Citas, value);
        }
        public ObservableCollection<Tipo_Examen> Tipo_Examenes
        {
            get => tipo_Examenes;
            set => SetProperty(ref tipo_Examenes, value);
        }
        public ObservableCollection<Tipo_Examen> Examenes_Cita
        {
            get => examenes_Cita;
            set => SetProperty(ref examenes_Cita, value);
        }
        public Paciente SelectedPaciente
        {
            get => selectedPaciente;
            set => SetProperty(ref selectedPaciente, value);
        }
        public Empleado SelectedEmpleado
        {
            get => selectedEmpleado;
            set => SetProperty(ref selectedEmpleado, value);
        }
        public Tipo_Cita SelectedTipoCita
        {
            get => selectedTipoCita;
            set => SetProperty(ref selectedTipoCita, value);
        }
        public Tipo_Examen SelectedExamen
        {
            get => selectedExamen;
            set => SetProperty(ref selectedExamen, value);
        }
        public Tipo_Examen SelectedTipoExam
        {
            get => selectedTipoExam;
            set => SetProperty(ref selectedTipoExam, value);
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
        public ICommand OnRemove
        {
            get => onRemove;
            set => SetProperty(ref onRemove, value);
        }
        #endregion

        public NewCitaViewModel()
        {
            Title = "Nueva cita";

            DataRefresh().Wait();

            OnSave = new Command(async () => await Save());
            OnClean = new Command(async () => await DataRefresh());
            OnAdd = new Command(() => AddExamn());
            OnRemove = new Command(() => RemoveExamn());
        }
        #region Methods
        public async Task<bool> Save()
        {
            if (await Validate())
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
                if (CitaDataValidator.IsAvailable(cita, await CitaDataStore.GetItems(cita.CodEmpl)))
                {
                    if (!CitaDataValidator.IsTodayInPast(cita))
                    {
                        CitaDataStore.AddItem(cita).Wait();

                        foreach (Tipo_Examen tipo in Examenes_Cita)
                        {
                            ExamenCitaDataStore.AddItem(new Examen_Cita
                            {
                                CodCita = cita.CodCita,
                                CodTpEx = tipo.CodTpEx,
                                TipoExamen = tipo,
                                Cita = cita
                            }).Wait();
                        }
                        await ClearData();
                        await ViewService.DisplayAlert("Cita agendada con exito",
                                                       "Su cita con se agendo correctamente",
                                                       "Aceptar");
                    }
                    else
                    {
                        await ViewService.DisplayAlert("Atencion",
                                                       "Introduce una hora valida.",
                                                       "Aceptar");
                    }
                }
                else
                {
                    await ViewService.DisplayAlert("Atencion",
                                                   "El medico ya tiene esta fecha ocupada, favor elegir otra.",
                                                   "Aceptar");
                }
            }
            return await Task.FromResult(true);
        }

        async Task<bool> Validate()
        {
            if(SelectedPaciente == null)
            {
                await ViewService.DisplayAlert("Alerta", "Por favor elegir un paciente", "ok");
                return false;
            }else if(SelectedEmpleado == null)
            {
                await ViewService.DisplayAlert("Alerta", "Por favor elegir un medico", "ok");
                return false;
            }else if(SelectedTipoCita == null)
            {
                await ViewService.DisplayAlert("Alerta", "Por favor elegir un tipo de cita", "ok");
                return false; 
            }
            return true;
        }
        public Task<bool> ClearData()
        {
            MinDate = DateTime.Now.Date;
            SelectedTime = MinDate.TimeOfDay;
            SelectedDate = DateTime.Now;
            SelectedPaciente = null;
            SelectedTipoCita = null;
            SelectedExamen = null;
            Examenes_Cita.Clear();
            if (AppData.Empleado != null)
            {
                SelectedEmpleado = AppData.Empleado;
            }
            else
            {
                SelectedEmpleado = null;
            }
            LoadTipoExamenes().Wait();
            return Task.FromResult(true);
        }
        public Task<bool> AddExamn()
        {
            IsBusy = true;

            Examenes_Cita.Add(selectedExamen);
            Tipo_Examenes.Remove(selectedExamen);
            SelectedExamen = null;

            IsBusy = false;
            return Task.FromResult(true);
        }
        public Task<bool> RemoveExamn()
        {
            IsBusy = true;

            Tipo_Examenes.Add(SelectedTipoExam);
            Examenes_Cita.Remove(SelectedTipoExam);
            SelectedTipoExam = null;

            IsBusy = false;

            return Task.FromResult(true);
        }
        public async Task DataRefresh()
        {
            IsBusy = true;
            MinDate = DateTime.Now;
            SelectedDate = MinDate;
            SelectedTime = MinDate.TimeOfDay;
            SelectedTipoExam = null;
            SelectedExamen = null;


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
            await LoadTipoExamenes();
            IsBusy = false;
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
        private async Task LoadTipoExamenes()
        {
            var ExamenesCitas = await TipoExamenesDataStore.GetItems();
            LoadCollectionsData<Tipo_Examen>(ref ExamenesCitas, ref this.tipo_Examenes);
        }

        #endregion

    }
}
