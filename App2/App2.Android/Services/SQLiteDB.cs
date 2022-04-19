using Android.OS;
using Care_Taker.Models;
using Care_Taker.Services;
using SQLite;
using SQLiteNetExtensions.Extensions;
//using Environment = System.Environment;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Care_Taker.Droid.Services.SQLiteDB))]
namespace Care_Taker.Droid.Services
{
    /// <summary>
    /// Clase para manejar la conexion de la base de datos
    /// </summary>
    public class SQLiteDB : ISQLiteDB
    {

        SQLiteConnection ISQLiteDB.GetConnection()
        {
            //var documentsPath = Environment.DirectoryDocuments;
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentsPath, "CareTaker.db3");
            return new SQLiteConnection(path);
        }

        async Task<bool> ISQLiteDB.CreateTables(SQLiteConnection connection)
        {

            connection.DropTable<Tipo_Cita>();
            connection.DropTable<Tipo_Sexo>();
            connection.DropTable<Tipo_Examen>();
            connection.DropTable<Tipo_Sangre>();
            connection.DropTable<Tipo_Telefono>();
            connection.DropTable<Tipo_Usuario>();
            connection.DropTable<Dia>();
            connection.DropTable<Consultorio>();
            connection.DropTable<Puesto_Empleado>();
            connection.DropTable<Especialidad>();
            connection.DropTable<Telefono>();
            connection.DropTable<Persona>();
            connection.DropTable<Telefono_Persona>();
            connection.DropTable<Email>();
            connection.DropTable<Usuario>();
            connection.DropTable<Empleado>();
            connection.DropTable<Paciente>();
            connection.DropTable<Turno>();
            connection.DropTable<Empleado_Especialidad>();
            connection.DropTable<Horario_Cita>();
            connection.DropTable<Cita_Especialidad>();
            connection.DropTable<Cita>();

            connection.CreateTable<Tipo_Cita>();
            connection.CreateTable<Tipo_Sexo>();
            connection.CreateTable<Tipo_Examen>();
            connection.CreateTable<Tipo_Sangre>();
            connection.CreateTable<Tipo_Telefono>();
            connection.CreateTable<Tipo_Usuario>();
            connection.CreateTable<Dia>();
            connection.CreateTable<Consultorio>();
            connection.CreateTable<Puesto_Empleado>();
            connection.CreateTable<Especialidad>();
            connection.CreateTable<Telefono>();
            connection.CreateTable<Persona>();
            connection.CreateTable<Telefono_Persona>();
            connection.CreateTable<Email>();
            connection.CreateTable<Usuario>();
            connection.CreateTable<Empleado>();
            connection.CreateTable<Paciente>();
            connection.CreateTable<Turno>();
            connection.CreateTable<Horario_Cita>();
            connection.CreateTable<Empleado_Especialidad>();
            connection.CreateTable<Cita_Especialidad>();
            connection.CreateTable<Cita>();
            //connection.CreateTab<Examen>();
            //connection.CreateTab<Examen_Cita>();
            //connection.CreateTab<Examen_Resultado>();

            return await Task.FromResult(true);
        }
        async Task<bool> ISQLiteDB.BaseData(SQLiteConnection connection)
        {
            if (connection.Table<Tipo_Cita>().Count() <= 0)
            {
                List<Tipo_Cita> tipoCitas = new List<Tipo_Cita>
                {
                    new Tipo_Cita()
                    {
                        CodTpCt = 0,
                        Descripcion = "Pediatria",
                        Duracion = 15
                    },
                    new Tipo_Cita()
                    {
                        CodTpCt = 0,
                        Descripcion = "Ginecologia",
                        Duracion = 20
                    },
                    new Tipo_Cita()
                    {
                        CodTpCt = 0,
                        Descripcion = "Cardiologia",
                        Duracion = 25
                    },
                    new Tipo_Cita()
                    {
                        CodTpCt = 0,
                        Descripcion = "Dermatologica",
                        Duracion = 30
                    },
                    new Tipo_Cita()
                    {
                        CodTpCt = 0,
                        Descripcion = "Gastroenterologica",
                        Duracion = 25
                    },
                    new Tipo_Cita()
                    {
                        CodTpCt = 0,
                        Descripcion = "Endocrinologica",
                        Duracion = 30
                    }
                };
                connection.InsertAll(tipoCitas);
            }
            if (connection.Table<Tipo_Sangre>().Count() <= 0)
            {
                List<Tipo_Sangre> tipoSangre = new List<Tipo_Sangre>
                {
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "A+"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "A-"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "B+"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "B-"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "O+"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "O-"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "AB+"
                    },
                    new Tipo_Sangre()
                    {
                        CodTpSg = 0,
                        Descripcion = "AB-"
                    }
                };

                connection.InsertAll(tipoSangre);
            }
            if (connection.Table<Tipo_Telefono>().Count() <= 0)
            {
                List<Tipo_Telefono> tipoTelefonos = new List<Tipo_Telefono>
                {
                    new Tipo_Telefono()
                    {
                        CodTpTf = 0,
                        Descripcion = "Hogar"
                    },
                    new Tipo_Telefono()
                    {
                        CodTpTf = 0,
                        Descripcion = "Personal"
                    },
                    new Tipo_Telefono()
                    {
                        CodTpTf = 0,
                        Descripcion = "Emergencia"
                    }
                };

                connection.InsertAll(tipoTelefonos);
            }
            if (connection.Table<Tipo_Telefono>().Count() <= 0)
            {
                List<Tipo_Telefono> tipoTelefonos = new List<Tipo_Telefono>
                {
                    new Tipo_Telefono()
                    {
                        CodTpTf = 0,
                        Descripcion = "Hogar"
                    },
                    new Tipo_Telefono()
                    {
                        CodTpTf = 0,
                        Descripcion = "Personal"
                    },
                    new Tipo_Telefono()
                    {
                        CodTpTf = 0,
                        Descripcion = "Emergencia"
                    }
                };

                connection.InsertAll(tipoTelefonos);
            }
            if (connection.Table<Tipo_Sexo>().Count() <= 0)
            {
                List<Tipo_Sexo> tipoSexo = new List<Tipo_Sexo>
                {
                    new Tipo_Sexo()
                    {
                        CodSexo = 0,
                        Descripcion = "Masculino"
                    },
                    new Tipo_Sexo()
                    {
                        CodSexo = 0,
                        Descripcion = "Femenino"
                    }
                };

                connection.InsertAll(tipoSexo);
            }
            if (connection.Table<Dia>().Count() <= 0)
            {
                List<Dia> Dias = new List<Dia>
                {
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Domingo"
                    },
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Lunes"
                    },
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Martes"
                    },
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Miercoles"
                    },
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Jueves"
                    },
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Viernes"
                    },
                    new Dia()
                    {
                        CodDia = 0,
                        Descripcion = "Sabado"
                    }
                };

                connection.InsertAll(Dias);
            }
            if (connection.Table<Tipo_Usuario>().Count() <= 0)
            {
                List<Tipo_Usuario> tipoUsuario = new List<Tipo_Usuario>
                {
                    new Tipo_Usuario()
                    {
                        CodTpUs = 0,
                        Descripcion = "Medico"
                    },
                    new Tipo_Usuario()
                    {
                        CodTpUs = 0,
                        Descripcion = "Paciente"
                    }
                };

                connection.InsertAll(tipoUsuario);
            }
            if (connection.Table<Consultorio>().Count() <= 0)
            {
                List<Consultorio> consultorios = new List<Consultorio>
                {
                    new Consultorio()
                    {
                        CodConsul = 0,
                        Descripcion = "1-10"
                    },
                    new Consultorio()
                    {
                        CodConsul = 0,
                        Descripcion = "1-12"
                    },
                    new Consultorio()
                    {
                        CodConsul = 0,
                        Descripcion = "2-01"
                    }
                };

                connection.InsertAll(consultorios);
            }
            if (connection.Table<Puesto_Empleado>().Count() <= 0)
            {
                List<Puesto_Empleado> puestoEmpleados = new List<Puesto_Empleado>
                {
                    new Puesto_Empleado()
                    {
                        CodPtEm = 0,
                        Descripcion = "Pediatra"
                    },
                    new Puesto_Empleado(){
                        CodPtEm = 0,
                        Descripcion = "Ginecologo/a"
                    },
                    new Puesto_Empleado(){
                        CodPtEm = 0,
                        Descripcion = "Cardiologo/a"
                    },
                    new Puesto_Empleado(){
                        CodPtEm = 0,
                        Descripcion = "Dermatologo/a"
                    },
                    new Puesto_Empleado(){
                        CodPtEm = 0,
                        Descripcion = "Gastroenterologo/a"
                    },
                    new Puesto_Empleado(){
                        CodPtEm = 0,
                        Descripcion = "Endoencrinologo/a"
                    }
                };

                connection.InsertAll(puestoEmpleados);
            }
            if (connection.Table<Especialidad>().Count() <= 0)
            {
                List<Especialidad> Especialidades = new List<Especialidad>
                {
                    new Especialidad()
                    {
                        CodEspe = 0,
                        Descripcion = "Pediatria"
                    },
                    new Especialidad()
                    {
                        CodEspe = 0,
                        Descripcion = "Ginecologia"
                    },
                    new Especialidad()
                    {
                        CodEspe = 0,
                        Descripcion = "Cardiologia"
                    },
                    new Especialidad()
                    {
                        CodEspe = 0,
                        Descripcion = "Dermatologia"
                    },
                    new Especialidad()
                    {
                        CodEspe = 0,
                        Descripcion = "Gastroenterologia"
                    },
                    new Especialidad()
                    {
                        CodEspe = 0,
                        Descripcion = "Endocrinologia"
                    }
                };
                connection.InsertAll(Especialidades);
            }
            if (connection.Table<Telefono>().Count() <= 0)
            {
                List<Telefono> telefonos = new List<Telefono>
                {
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8096964034",
                        CodTpTf = 2
                    },
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8493923432",
                        CodTpTf = 3
                    },
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8294567895",
                        CodTpTf = 2
                    },
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8294788523",
                        CodTpTf = 1
                    },
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8098966985",
                        CodTpTf = 2
                    },
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8299547523",
                        CodTpTf = 2
                    },
                    new Telefono()
                    {
                        CodTelf = 0,
                        telefono = "8292026323",
                        CodTpTf = 2
                    }
                };
                connection.InsertAll(telefonos);
            }
            if (connection.Table<Persona>().Count() <= 0)
            {
                List<Persona> personas = new List<Persona>
                {
                    new Persona()
                    {
                        CodPers = 0,
                        Nombre = "Guillermo",
                        Apellidos = "Santos Marzan",
                        FecNaci = new System.DateTime(2001, 5, 28),
                        CodSexo = 1
                    },
                    new Persona()
                    {
                        CodPers = 0,
                        Nombre = "Luis",
                        Apellidos = "Martinez Sanchez",
                        FecNaci = new System.DateTime(1998, 2, 2),
                        CodSexo = 1
                    },
                    new Persona()
                    {
                        CodPers = 0,
                        Nombre = "Lisbeth",
                        Apellidos = "Martinez Santos",
                        FecNaci = new System.DateTime(2000, 10, 22),
                        CodSexo = 2
                    },
                    new Persona()
                    {
                        CodPers = 0,
                        Nombre = "Maria",
                        Apellidos = "Martinez Sanchez",
                        FecNaci = new System.DateTime(2005, 12, 13),
                        CodSexo = 2
                    },
                    new Persona()
                    {
                        CodPers = 0,
                        Nombre = "Miguel",
                        Apellidos = "Rodriguez Perez",
                        FecNaci = new System.DateTime(1995, 1, 24),
                        CodSexo = 1
                    },
                    new Persona()
                    {
                        CodPers = 0,
                        Nombre = "Christian",
                        Apellidos = "Diaz Gomez",
                        FecNaci = new System.DateTime(2002, 8, 18),
                        CodSexo = 1
                    }
                };
                connection.InsertAll(personas);
            }
            if (connection.Table<Telefono_Persona>().Count() <= 0)
            {
                List<Telefono_Persona> telefonos_persona = new List<Telefono_Persona>
                {
                    new Telefono_Persona()
                    {
                        CodPers = 1,
                        CodTelf = 1
                    },
                    new Telefono_Persona()
                    {
                        CodPers = 1,
                        CodTelf = 2
                    },
                    new Telefono_Persona()
                    {
                        CodPers = 2,
                        CodTelf = 3
                    },
                    new Telefono_Persona()
                    {
                        CodPers = 3,
                        CodTelf = 4
                    },
                    new Telefono_Persona()
                    {
                        CodPers = 4,
                        CodTelf = 5
                    },
                    new Telefono_Persona()
                    {
                        CodPers = 5,
                        CodTelf = 6
                    },
                    new Telefono_Persona()
                    {
                        CodPers = 6,
                        CodTelf = 7
                    }
                };
                connection.InsertAll(telefonos_persona);
            }
            if (connection.Table<Email>().Count() <= 0)
            {
                List<Email> Emails = new List<Email>
                {
                    new Email()
                    {
                        CodEmail = 0,
                        email = "santosguillermo360@gmail.com",
                        CodPers = 1
                    },
                    new Email()
                    {
                        CodEmail = 0,
                        email = "luisSM@gmail.com",
                        CodPers = 2
                    },
                    new Email()
                    {
                        CodEmail = 0,
                        email = "lisbethMS@gmail.com",
                        CodPers = 3
                    },
                    new Email()
                    {
                        CodEmail = 0,
                        email = "mariaMS@gmail.com",
                        CodPers = 4
                    },
                    new Email()
                    {
                        CodEmail = 0,
                        email = "miguelRP360@gmail.com",
                        CodPers = 5
                    },
                    new Email()
                    {
                        CodEmail = 0,
                        email = "DGChristian@gmail.com",
                        CodPers = 6
                    }
                };
                connection.InsertAll(Emails);
            }
            if (connection.Table<Usuario>().Count() <= 0)
            {
                List<Usuario> Usuarios = new List<Usuario>
                {
                    new Usuario()
                    {
                        CodUser = 0,
                        UserName = "Guillermo Santos",
                        Password = "Soultron34",
                        CodTpUs = 1
                    },
                    new Usuario()
                    {
                        CodUser = 0,
                        UserName = "Luis Martinez",
                        Password = "Soultron34",
                        CodTpUs = 1
                    },
                    new Usuario()
                    {
                        CodUser = 0,
                        UserName = "Lisbeth Martinez",
                        Password = "Soultron34",
                        CodTpUs = 1
                    },
                    new Usuario()
                    {
                        CodUser = 0,
                        UserName = "Maria Martinez",
                        Password = "Soultron34",
                        CodTpUs = 2
                    },
                    new Usuario()
                    {
                        CodUser = 0,
                        UserName = "Miguel Rodriguez",
                        Password = "Soultron34",
                        CodTpUs = 2
                    },
                    new Usuario()
                    {
                        CodUser = 0,
                        UserName = "Christian Diaz",
                        Password = "Soultron34",
                        CodTpUs = 2
                    }
                };
                connection.InsertAll(Usuarios);
            }
            if (connection.Table<Empleado>().Count() <= 0)
            {
                List<Empleado> Empleados = new List<Empleado>
                {
                    new Empleado()
                    {
                        CodEmpl = 0,
                        CodPers = 1,
                        CodPtEm = 1,
                        CodUser = 1,
                        FecEntr = new System.DateTime(2015, 5, 20)
                    },
                    new Empleado()
                    {
                        CodEmpl = 0,
                        CodPers = 2,
                        CodPtEm = 2,
                        CodUser = 2,
                        FecEntr = new System.DateTime(2009, 2, 10)
                    },
                    new Empleado()
                    {
                        CodEmpl = 0,
                        CodPers = 3,
                        CodPtEm = 3,
                        CodUser = 3,
                        FecEntr = new System.DateTime(2018, 9, 15)
                    }
                };
                connection.InsertAll(Empleados);
            }
            if (connection.Table<Paciente>().Count() <= 0)
            {
                List<Paciente> Pacientes = new List<Paciente>
                {
                    new Paciente()
                    {
                        CodPaci = 0,
                        CodPers = 4,
                        CodTpSg = 5,
                        CodUser = 4
                    },
                    new Paciente()
                    {
                        CodPaci = 0,
                        CodPers = 5,
                        CodTpSg = 5,
                        CodUser = 5
                    },
                    new Paciente()
                    {
                        CodPaci = 0,
                        CodPers = 6,
                        CodTpSg = 3,
                        CodUser = 6
                    }
                };
                connection.InsertAll(Pacientes);
            }
            if (connection.Table<Turno>().Count() <= 0)
            {
                List<Turno> Turnos = new List<Turno>
                {
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Lunes Diurno",
                        CodDia = 2,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Lunes Nocturno",
                        CodDia = 2,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Martes Diurno",
                        CodDia = 3,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Martes Nocturno",
                        CodDia = 3,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Miercoles Diurno",
                        CodDia = 4,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Miercoles Nocturno",
                        CodDia = 4,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Jueves Diurno",
                        CodDia = 5,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Jueves Nocturno",
                        CodDia = 5,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Viernes Diurno",
                        CodDia = 6,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Viernes Nocturno",
                        CodDia = 6,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Sabado Diurno",
                        CodDia = 7,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Sabado Nocturno",
                        CodDia = 7,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Domingo Diurno",
                        CodDia = 1,
                        TimeIn = new System.DateTime(2000,1,1,7,0,0),
                        TimeOut = new System.DateTime(2000, 1, 1, 18, 30, 0)
                    },
                    new Turno()
                    {
                        CodTurn = 0,
                        Descripcion = "Domingo Nocturno",
                        CodDia = 1,
                        TimeIn = new System.DateTime(2000,1,1,18,0,0),
                        TimeOut = new System.DateTime(2000, 1, 2, 7, 0, 0)
                    }
                };
                connection.InsertAll(Turnos);
            }
            if (connection.Table<Horario_Cita>().Count() <= 0)
            {
                List<Horario_Cita> Horario_Citas = new List<Horario_Cita>
                {
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 1,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 3,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 5,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 7,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 9,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 11,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 1,
                        CodEmpl = 1,
                        CodTurn = 13,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 1,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 2,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 4,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 6,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 8,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 10,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 12,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 2,
                        CodEmpl = 2,
                        CodTurn = 14,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 1,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 2,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 4,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 6,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 7,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 8,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 10,
                    },
                    new Horario_Cita()
                    {
                        CodConsul = 3,
                        CodEmpl = 3,
                        CodTurn = 12,
                    }
                };
                connection.InsertAll(Horario_Citas);
            }
            if (connection.Table<Empleado_Especialidad>().Count() <= 0)
            {
                List<Empleado_Especialidad> Empleado_Especialidades = new List<Empleado_Especialidad>
                {
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 1,
                        CodEspe = 1,
                    },
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 1,
                        CodEspe = 3,
                    },
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 2,
                        CodEspe = 2,
                    },
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 2,
                        CodEspe = 5,
                    },
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 3,
                        CodEspe = 3,
                    },
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 3,
                        CodEspe = 1,
                    },
                    new Empleado_Especialidad()
                    {
                        CodEmpl = 3,
                        CodEspe = 2,
                    }
                };
                connection.InsertAll(Empleado_Especialidades);
            }
            if (connection.Table<Cita_Especialidad>().Count() <= 0)
            {
                List<Cita_Especialidad> Cita_Especialidades = new List<Cita_Especialidad>
                {
                    new Cita_Especialidad()
                    {
                        CodTpCt = 1,
                        CodEspe = 1
                    },
                    new Cita_Especialidad()
                    {
                        CodTpCt = 2,
                        CodEspe = 2
                    },
                    new Cita_Especialidad()
                    {
                        CodTpCt = 3,
                        CodEspe = 3
                    },
                    new Cita_Especialidad()
                    {
                        CodTpCt = 4,
                        CodEspe = 4
                    },
                    new Cita_Especialidad()
                    {
                        CodTpCt = 5,
                        CodEspe = 5
                    },
                    new Cita_Especialidad()
                    {
                        CodTpCt = 6,
                        CodEspe = 6
                    }
                };
                connection.InsertAll(Cita_Especialidades);
            }
            if (connection.Table<Tipo_Examen>().Count() <= 0)
            {
                List<Tipo_Examen> Tipo_Examenes = new List<Tipo_Examen>
                {
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Biometria hematica (Examen de sangre)"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Perfil de lipidos"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Quimica sanguinea"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Hemoglobina glicosilada"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Prueba ELISA"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Prueba de anticuerpos antinucleares (ANA)"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Prueba ELISA"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Examen general de orina"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Examen de funcion hepatica"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Marcadores tumorales"
                    },
                    new Tipo_Examen()
                    {
                        CodTpEx = 0,
                        Descripcion = "Marcadores cardiacos"
                    }
                };
                connection.InsertAll(Tipo_Examenes);
            }
            return await Task.FromResult(true);
        }

    }


}