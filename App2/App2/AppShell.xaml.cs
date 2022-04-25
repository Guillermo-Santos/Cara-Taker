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
            Routing.RegisterRoute(nameof(CitaDetailPage), typeof(CitaDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PacientesPage), typeof(PacientesPage));
            Routing.RegisterRoute(nameof(DetailedAgendaPage), typeof(DetailedAgendaPage));
            Routing.RegisterRoute(nameof(SimpleAgendaSettingsPage), typeof(SimpleAgendaSettingsPage));
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
