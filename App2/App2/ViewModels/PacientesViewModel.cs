using System;
using System.Collections.Generic;
using System.Text;
using Care_Taker.Models;
using Care_Taker.Services;
using Xamarin.Forms;

namespace Care_Taker.ViewModels
{
    public class PacientesViewModel : BaseViewModel
    {

        readonly IDataStore<Paciente> PacienteDataStore = DependencyService.Get<IDataStore<Paciente>>();

        public PacientesViewModel()
        {

        }

    }
}
