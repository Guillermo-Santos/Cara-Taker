using SQLite;

namespace Care_Taker.Services
{
    /// <summary>
    /// Interfaz para manejar la conexion a la base de datos.
    /// </summary>
    public interface ISQLiteDB
    {
        /// <summary>
        /// Metodo para obtener la conexion a la base de datos.
        /// </summary>
        /// <returns>Conexion a la base de datos.</returns>
        SQLiteAsyncConnection GetConnection();

        /// <summary>
        /// Metodo para generar las tablas de la base de datos
        /// </summary>
        /// <param name="connection"> conexion a la base de datos a utilizar</param>
        void CreateTables(SQLiteAsyncConnection connection);

        /// <summary>
        /// Metodo para generar la data base de la base de datos.
        /// </summary>
        /// <param name="connection"> Conexion a la base de datos a utilizar. </param>
        void BaseData(SQLiteAsyncConnection connection);
    }
}
