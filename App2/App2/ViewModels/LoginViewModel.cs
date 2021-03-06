using Care_Taker.Models;
using Care_Taker.Services;
using System.Linq;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        public string UserName
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private readonly IDataStore<Usuario> Da = DependencyService.Get<IDataStore<Usuario>>();
        private readonly IDataStore<Empleado> empleadosDataStore = DependencyService.Get<IDataStore<Empleado>>();
        private readonly IDataStore<Paciente> PacienteDataStore = DependencyService.Get<IDataStore<Paciente>>();
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                await ViewService.DisplayAlert("Falta de datos", "Por favor introducir nombre de usuario o contraseña.", "Aceptar");
                return;
            }

            var Usuarios = await Da.GetItems(true);
            var usuario = from user in Usuarios where user.UserName == UserName && user.Password == Password select user;
            if (usuario.Any())
            {
                AppData.Usuario = usuario.FirstOrDefault();
                var Empleados = await empleadosDataStore.GetItems(true);
                var empleado = from empl in Empleados where empl.CodUser == AppData.Usuario.CodUser select empl;
                if (empleado.Any()) { 
                    AppData.Empleado = empleado.FirstOrDefault();
                    ViewService.SetMainPage(new AppShell());
                }
                else
                {
                    var Pacientes = await PacienteDataStore.GetItems(true);
                    var paciente = from paci in Pacientes where paci.CodUser == AppData.Usuario.CodUser select paci;
                    if (paciente.Any()) {
                        AppData.Paciente = paciente.FirstOrDefault();
                        AppData.byPaci = true;
                        ViewService.SetMainPage(new AppShell());
                    }
                    else
                    {
                        await ViewService.DisplayAlert("Falta de privilegios", "Este usuario no tiene acceso a esta app.", "Aceptar");
                    }
                }
            }
            else
            {
                await ViewService.DisplayAlert("Usuario o contraseña incorrecta", "Introduzca valores correctos.", "Aceptar");
            }
        }
    }
}
