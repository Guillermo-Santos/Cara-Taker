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
    public partial class EditCitaPage : ContentPage
    {
        public EditCitaPage(int CodCita)
        {
            InitializeComponent();
            this.BindingContext = new EditCitaViewModel(CodCita);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((EditCitaViewModel)BindingContext).OnAppearing();
        }
    }
}