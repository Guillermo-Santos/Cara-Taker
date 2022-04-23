using Care_Taker.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Care_Taker.Models;

namespace Care_Taker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCitaPage : ContentPage
    {
        public NewCitaPage()
        {
            InitializeComponent(); 
            this.BindingContext = new NewCitaViewModel();
        }
    }
}