using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Care_Taker.Models;
using Care_Taker.Services;
using Xamarin.Forms;


namespace Care_Taker.ViewModels
{
    public class EditCitaViewModel : BaseViewModel
    {

        #region DataStore
        readonly IDataStore<Cita> CitaDataStore = DependencyService.Get<IDataStore<Cita>>();
        readonly IDataStore<Examen_Cita> ExamenCitaDataStore = DependencyService.Get<IDataStore<Examen_Cita>>();
        readonly IDataStore<Tipo_Examen> TipoExamenDataStore = DependencyService.Get<IDataStore<Tipo_Examen>>();
        #endregion
        #region Properties
        #region Cita Properties
        private int codCita;
        private int codEmpl;
        private int codPaci;
        private int codTpCt;
        private DateTime fecha;
        private TimeSpan hora;
        private string resultado;
        private bool status;
        private Paciente paciente;
        private Empleado empleado;
        private Tipo_Cita tipo;
        #endregion
        private ObservableCollection<Examen_Cita> examenes = new ObservableCollection<Examen_Cita>();
        private ObservableCollection<Tipo_Examen> tipoExamenes = new ObservableCollection<Tipo_Examen>();
        private Examen_Cita selectedExamen;
        private Tipo_Examen selectedTipoExamen;
        private bool refresh = false;
        #endregion
        #region Fields
        public int CodCita
        {
            get => codCita;
            set
            {
                SetProperty(ref codCita, value);
            }
        }
        public int CodEmpl
        {
            get => codEmpl;
            set => SetProperty(ref codEmpl, value);
        }
        public int CodPaci
        {
            get => codPaci;
            set => SetProperty(ref codPaci, value);
        }
        public int CodTpCt
        {
            get => codTpCt;
            set => SetProperty(ref codTpCt, value);
        }
        public DateTime Fecha
        {
            get => fecha;
            set => SetProperty(ref fecha, value);
        }
        public TimeSpan Hora
        {
            get => hora;
            set => SetProperty(ref hora, value);
        }
        public string Resultado
        {
            get => resultado;
            set => SetProperty(ref resultado, value);
        }
        public bool Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        public Paciente Paciente
        {
            get => paciente;
            set => SetProperty(ref paciente, value);
        }
        public Empleado Empleado
        {
            get => empleado;
            set => SetProperty(ref empleado, value);
        }
        public Tipo_Cita Tipo
        {
            get => tipo;
            set => SetProperty(ref tipo, value);
        }
        public ObservableCollection<Examen_Cita> Examenes
        {
            get => examenes;
            set => SetProperty(ref examenes, value);
        }
        public ObservableCollection<Tipo_Examen> Tipo_Examenes
        {
            get => tipoExamenes;
            set => SetProperty(ref tipoExamenes, value);
        }
        public Examen_Cita SelectedExamen
        {
            get => selectedExamen;
            set => SetProperty(ref selectedExamen, value);
        }
        public Tipo_Examen SelectedTipoExamen
        {
            get => selectedTipoExamen;
            set => SetProperty(ref selectedTipoExamen, value);
        }
        public DateTime MinDate => DateTime.Today;
        Cita Cita { get; set; }
        public bool Refresh
        {
            get => refresh;
            set => SetProperty(ref refresh, value);
        }
        #endregion

        /// <summary>
        /// A constructor used just to edit on xamarin
        /// </summary>
        public EditCitaViewModel() => Title = "Editar";
   
        /// <summary>
        /// Call of the ViewModel for editing a <see cref="Cita"/>
        /// </summary>
        /// <param name="CodCita">ID of the <see cref="Cita"/></param>
        public EditCitaViewModel(int CodCita){
            Title = "Editar";
            this.CodCita = CodCita;
            LoadData = new Command(async () => await LoadCitaData());
            SaveData = new Command(async () => await SaveCitaData());
            OnAdd = new Command(async () => await AddExamn());
            OnRemove = new Command(async () => await RemoveExamn());
            OnCancelCitaClick = new Command(async () => await CancelCita());
        }


        #region Commands
        public ICommand LoadData { get; }
        public ICommand SaveData { get; }
        public ICommand OnCancelCitaClick { get; }
        public ICommand OnAdd { get; }
        public ICommand OnRemove { get; }

        #endregion

        async Task LoadCitaData()
        {
            IsBusy = false;
            try
            {
                var cita = await CitaDataStore.GetItem(CodCita, true);
                if (cita != null)
                {
                    CodEmpl = cita.CodEmpl;
                    CodPaci = cita.CodPaci;
                    CodTpCt = cita.CodTpCt;
                    Fecha = cita.Fecha;
                    Hora = cita.Hora;
                    Resultado = cita.Resultado;
                    Status = cita.Status;
                    Paciente = cita.Paciente;
                    Empleado = cita.Empleado;
                    Tipo = cita.Tipo;
                    this.Cita = cita;
                    if(this.Examenes.Count <= 0)
                    {
                        var Examenes = await ExamenCitaDataStore.GetItems(CodCita, true);
                        LoadCollectionsData<Examen_Cita>(ref Examenes, ref examenes);
                    }
                    if(this.Tipo_Examenes.Count <= 0)
                    {
                        var TipoExamenes = await TipoExamenDataStore.GetItems(true);
                        LoadCollectionsData(ref TipoExamenes, ref tipoExamenes);
                    }
                    foreach (var item in this.Examenes)
                    {
                        foreach(var examen in Tipo_Examenes)
                        {
                            if (item.CodTpEx == examen.CodTpEx)
                            {
                                Tipo_Examenes.Remove(examen);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    await ViewService.PopAsync();
                }
            }
            catch (Exception)
            {
                await ViewService.DisplayAlert("Error", "Fallo al cargar la cita", "Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task SaveCitaData()
        {
            Cita.Fecha = Fecha;
            Cita.Hora = Hora;
            Cita.Resultado = Resultado;
            CitaDataStore.UpdateItem(Cita).Wait();
            foreach (var examen in Examenes)
            {
                examen.CodCita = Cita.CodCita;
                examen.Cita = Cita;
                ExamenCitaDataStore.UpdateItem(examen).Wait();
            }
            await ViewService.DisplayAlert("Cita actualizada con exito",
                                               "Su cita con se actualizo correctamente",
                                               "Aceptar");
            await ViewService.PopAsync();
        }
        async Task CancelCita()
        {
            foreach (var examen in Examenes)
            {
                ExamenCitaDataStore.DeleteItem(examen.Id).Wait();
            }

            CitaDataStore.DeleteItem(CodCita).Wait();
            await ViewService.PopAsync();
        }
        public Task<bool> AddExamn()
        {
            Refresh = true;
            Examen_Cita examen = new Examen_Cita
            {
                CodCita = CodCita,
                CodTpEx = selectedTipoExamen.CodTpEx,
                Cita = this.Cita,
                TipoExamen = SelectedTipoExamen
            };
            ExamenCitaDataStore.AddItem(examen).Wait();
            Examenes.Add(examen);
            Tipo_Examenes.Remove(SelectedTipoExamen);
            SelectedTipoExamen = null;
            Refresh = false;

            return Task.FromResult(true);
        }
        public Task<bool> RemoveExamn()
        {
            Refresh = true;
            Tipo_Examenes.Add(SelectedExamen.TipoExamen);
            Examenes.Remove(SelectedExamen);
            ExamenCitaDataStore.DeleteItem(SelectedExamen.Id).Wait();
            SelectedExamen = null;
            Refresh = false;

            return Task.FromResult(true);
        }
    }
}
