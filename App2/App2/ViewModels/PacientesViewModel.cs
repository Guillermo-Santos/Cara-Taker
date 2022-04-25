using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Care_Taker.Models;
using Care_Taker.Services;
using Care_Taker.Views;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{
    public class PacientesViewModel : BaseViewModel
    {

        readonly IDataStore<Paciente> PacienteDataStore = DependencyService.Get<IDataStore<Paciente>>();

        ObservableCollection<Paciente> pacientes = new ObservableCollection<Paciente>();
        public ObservableCollection<Paciente> Pacientes
        {
            get => pacientes;
            set => SetProperty(ref pacientes, value);
        }

        public PacientesViewModel()
        {
            Title = "Pacientes";
            LoadData = new Command(async () => await LoadPacientesData());
            ItemSelected = new Command<Paciente>(OnItemSelected);
        }

        public ICommand LoadData{ get; }
        public ICommand ItemSelected { get; }

        async Task LoadPacientesData()
        {
            IsBusy = true;
            try
            {
                Pacientes.Clear();
                if(AppData.Paciente == null)
                {
                    var pacientes = await PacienteDataStore.GetItems(true);
                    foreach (Paciente paciente in pacientes)
                    {
                        Pacientes.Add(paciente);
                    }
                }
                else
                {
                    Pacientes.Add(AppData.Paciente);
                }
            }
            catch (Exception)
            {
                await ViewService.DisplayAlert("Error","No se puedo obtener los datos de los pacientes.","Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }
        async void OnItemSelected(Paciente Paciente)
        {
            await ViewService.PushAsync(new PacienteDetailPage(Paciente.CodPaci));
        }

    }
}
