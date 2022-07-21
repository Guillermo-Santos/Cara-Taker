using Care_Taker.Models;
using Care_Taker.Services;
using Care_Taker.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{
    public class CitaDetailViewModel : BaseViewModel
    {
        #region DataStore
        readonly IDataStore<Cita> CitaDataStore = DependencyService.Get<IDataStore<Cita>>();
        readonly IDataStore<Examen_Cita> ExamenCitaDataStore = DependencyService.Get<IDataStore<Examen_Cita>>();
        #endregion
        #region Properties
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
        private ObservableCollection<Examen_Cita> examenes = new ObservableCollection<Examen_Cita>();
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
        public string Resultado { 
            get => resultado; 
            set => SetProperty(ref resultado, value); 
        }
        public bool Status { 
            get => status; 
            set => SetProperty(ref status, value); 
        }
        public Paciente Paciente { 
            get => paciente; 
            set => SetProperty(ref paciente, value); 
        }
        public Empleado Empleado { 
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
        #endregion

        public bool Editable
        {
            get
            {
                return (AppData.Paciente == null);
            }
        }

        public CitaDetailViewModel() => Title = "Detalle de cita";
        public CitaDetailViewModel(int CodCita)
        {
            this.CodCita = CodCita;
            Title = "Detalle de cita";
            LoadData = new Command(async() => await LoadCitaData());
            OnEditClick = new Command(async () => await ViewService.PushAsync(new EditCitaPage(CodCita)));
        }

        public ICommand LoadData { get; }
        public ICommand OnEditClick { get; }

        async Task LoadCitaData()
        {
            IsBusy = false;
            try
            {
                var cita = await CitaDataStore.GetItem(CodCita,true);
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
                    var Examenes = await ExamenCitaDataStore.GetItems(CodCita, true);
                    LoadCollectionsData<Examen_Cita>(ref Examenes, ref examenes);

                    if (AppData.Paciente != null)
                    {
                        Status = false;
                    }
                }
                else
                {
                    await ViewService.PopAsync();
                }
            }
            catch (Exception)
            {
                await ViewService.PopAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
