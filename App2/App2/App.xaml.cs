using Care_Taker.Services;
using Care_Taker.Views;
using SQLite;
using Xamarin.Forms;

namespace Care_Taker
{
    public partial class App : Application
    {

        #region variables

        private static SQLiteConnection connection;
        /// <summary>
        /// Static variable used to get the connection to the database.
        /// </summary>
        public static SQLiteConnection Connection
        {
            get {
                if(connection == null)
                {
                    connection = DependencyService.Get<ISQLiteDB>().GetConnection();
                }
                return connection;
            }
        }

        #endregion

        public App()
        {
            InitializeComponent();
            
            //DataStore dependency services
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<UsuariosDataStore>();
            DependencyService.Register<CitasDataStore>();
            DependencyService.Register<EmpleadosDataStore>();
            DependencyService.Register<PacientesDataStore>();
            DependencyService.Register<TipoCitasDataStore>();
            //Utility dependency services
            DependencyService.Register<ViewService>();

            DependencyService.Get<ISQLiteDB>().CreateTables(Connection);
            DependencyService.Get<ISQLiteDB>().BaseData(Connection);

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
