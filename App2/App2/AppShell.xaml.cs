using Care_Taker.Views;
using System;
using Xamarin.Forms;

namespace Care_Taker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(DocumentPage), typeof(DocumentPage));
            Routing.RegisterRoute(nameof(CitaPage), typeof(CitaPage));
            Routing.RegisterRoute(nameof(NewCitaPage), typeof(NewCitaPage));
            Routing.RegisterRoute(nameof(DetailedAgendaPage), typeof(DetailedAgendaPage));
            Routing.RegisterRoute(nameof(SimpleAgendaSettingsPage), typeof(SimpleAgendaSettingsPage));
            //logout();
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
