using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Care_Taker.Droid.Services;
using Care_Taker.Services;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Care_Taker.Models;
using Environment = System.Environment;
using System.Collections.Generic;

[assembly: Dependency(typeof(SQLiteDB))]
namespace Care_Taker.Droid.Services
{
    /// <summary>
    /// Clase para manejar la conexion de la base de datos
    /// </summary>
    public class SQLiteDB : ISQLiteDB
    {
        
        SQLiteAsyncConnection ISQLiteDB.GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "CareTaker.db3");
            return new SQLiteAsyncConnection(path);
        }

        void ISQLiteDB.CreateTables(SQLiteAsyncConnection connection)
        {
            connection.CreateTableAsync<Tipo_Cita>();
            connection.CreateTableAsync<Tipo_Sexo>();
            connection.CreateTableAsync<Tipo_Examen>();
            connection.CreateTableAsync<Tipo_Sangre>();
            connection.CreateTableAsync<Tipo_Telefono>();
            connection.CreateTableAsync<Tipo_Usuario>();
            connection.CreateTableAsync<Dia>();
            connection.CreateTableAsync<Consultorio>();
            connection.CreateTableAsync<Puesto_Empleado>();
            connection.CreateTableAsync<Especialidad>();
            connection.CreateTableAsync<Telefono>();
            connection.CreateTableAsync<Persona>();
            connection.CreateTableAsync<Telefono_Persona>();
            connection.CreateTableAsync<Email>();
            connection.CreateTableAsync<Usuario>();
            connection.CreateTableAsync<Empleado>();
            connection.CreateTableAsync<Paciente>();
            connection.CreateTableAsync<Turno>();
            connection.CreateTableAsync<Horario_Cita>();
            connection.CreateTableAsync<Empleado_Especialidad>();
            connection.CreateTableAsync<Cita_Especialidad>();
            connection.CreateTableAsync<Cita>();
            connection.CreateTableAsync<Examen>();
            connection.CreateTableAsync<Examen_Cita>();
            connection.CreateTableAsync<Examen_Resultado>();

            BaseData(connection);
        }
        public void BaseData(SQLiteAsyncConnection connection)
        {
            if (connection.Table<Tipo_Cita>().CountAsync().Result <= 0)
            {
                List<Tipo_Cita> tipoCitas = new List<Tipo_Cita>();
                
                tipoCitas.Add(new Tipo_Cita()
                {
                    CodTpCt=0,
                    Descripcion="Pediatria",
                    Duracion=15
                });
                tipoCitas.Add(new Tipo_Cita()
                {
                    CodTpCt=0,
                    Descripcion="Ginecologia",
                    Duracion=20
                });
                tipoCitas.Add(new Tipo_Cita()
                {
                    CodTpCt=0,
                    Descripcion="Cardiologia",
                    Duracion=25
                });
                tipoCitas.Add(new Tipo_Cita()
                {
                    CodTpCt=0,
                    Descripcion="Dermatologica",
                    Duracion=30
                });
                tipoCitas.Add(new Tipo_Cita()
                {
                    CodTpCt=0,
                    Descripcion="Gastroenterologica",
                    Duracion=25
                });
                tipoCitas.Add(new Tipo_Cita()
                {
                    CodTpCt=0,
                    Descripcion="Endocrinologica",
                    Duracion=30
                });
                connection.InsertAllAsync(tipoCitas);
            }
            if (connection.Table<Tipo_Sangre>().CountAsync().Result <= 0)
            {
                List<Tipo_Sangre> tipoSangre = new List<Tipo_Sangre>();

                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "A+"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "A-"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "B+"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "B-"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "O+"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "O-"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "AB+"
                });
                tipoSangre.Add(new Tipo_Sangre()
                {
                    CodTpSg = 0,
                    Descripcion = "AB-"
                });

                connection.InsertAllAsync(tipoSangre);
            }
            if (connection.Table<Tipo_Telefono>().CountAsync().Result <= 0)
            {
                List<Tipo_Telefono> tipoTelefonos = new List<Tipo_Telefono>();

                tipoTelefonos.Add(new Tipo_Telefono()
                {
                    CodTpTf = 0,
                    Descripcion = "Hogar"
                });
                tipoTelefonos.Add(new Tipo_Telefono()
                {
                    CodTpTf = 0,
                    Descripcion = "Personal"
                });
                tipoTelefonos.Add(new Tipo_Telefono()
                {
                    CodTpTf = 0,
                    Descripcion = "Emergencia"
                });

                connection.InsertAllAsync(tipoTelefonos);
            }
            if (connection.Table<Tipo_Telefono>().CountAsync().Result <= 0)
            {
                List<Tipo_Telefono> tipoTelefonos = new List<Tipo_Telefono>();

                tipoTelefonos.Add(new Tipo_Telefono()
                {
                    CodTpTf = 0,
                    Descripcion = "Hogar"
                });
                tipoTelefonos.Add(new Tipo_Telefono()
                {
                    CodTpTf = 0,
                    Descripcion = "Personal"
                });
                tipoTelefonos.Add(new Tipo_Telefono()
                {
                    CodTpTf = 0,
                    Descripcion = "Emergencia"
                });

                connection.InsertAllAsync(tipoTelefonos);
            }
            if (connection.Table<Tipo_Sexo>().CountAsync().Result <= 0)
            {
                List<Tipo_Sexo> tipoSexo = new List<Tipo_Sexo>();

                tipoSexo.Add(new Tipo_Sexo()
                {
                    CodSexo = 0,
                    Descripcion = "Masculino"
                });
                tipoSexo.Add(new Tipo_Sexo()
                {
                    CodSexo = 0,
                    Descripcion = "Femenino"
                });

                connection.InsertAllAsync(tipoSexo);
            }
            if (connection.Table<Dia>().CountAsync().Result <= 0)
            {
                List<Dia> Dias = new List<Dia>();

                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Domingo"
                });
                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Lunes"
                });
                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Martes"
                });
                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Miercoles"
                });
                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Jueves"
                });
                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Viernes"
                });
                Dias.Add(new Dia()
                {
                    CodDia = 0,
                    Descripcion = "Sabado"
                });

                connection.InsertAllAsync(Dias);
            }
            if (connection.Table<Tipo_Usuario>().CountAsync().Result <= 0)
            {
                List<Tipo_Usuario> tipoUsuario = new List<Tipo_Usuario>();

                tipoUsuario.Add(new Tipo_Usuario()
                {
                    CodTpUs = 0,
                    Descripcion = "Medico"
                });
                tipoUsuario.Add(new Tipo_Usuario()
                {
                    CodTpUs = 0,
                    Descripcion = "Paciente"
                });

                connection.InsertAllAsync(tipoUsuario);
            }
            if (connection.Table<Consultorio>().CountAsync().Result <= 0)
            {
                List<Consultorio> consultorios = new List<Consultorio>();

                consultorios.Add(new Consultorio()
                {
                    CodConsul = 0,
                    Descripcion = "1-10"
                });
                consultorios.Add(new Consultorio()
                {
                    CodConsul = 0,
                    Descripcion = "1-12"
                });
                consultorios.Add(new Consultorio()
                {
                    CodConsul = 0,
                    Descripcion = "2-01"
                });

                connection.InsertAllAsync(consultorios);
            }
        }
    }

    
}