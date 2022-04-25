using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Care_Taker.Models;

namespace Care_Taker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacienteDetailPage : ContentPage
    {
        public PacienteDetailPage(int CodPaci)
        {
            InitializeComponent();
            this.BindingContext = new PacienteDetailViewModel(CodPaci);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((PacienteDetailViewModel)BindingContext).OnAppearing();
        }

        private void citas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new CitaDetailPage(((Cita)citas.SelectedItem).CodCita));
        }
    }
}