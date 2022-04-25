using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Care_Taker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacientesPage : ContentPage
    {
        public PacientesPage()
        {
            InitializeComponent();
            this.BindingContext = new PacientesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((PacientesViewModel)BindingContext).OnAppearing();

        }
    }
}