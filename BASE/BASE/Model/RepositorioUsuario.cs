using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace BASE.Model
{
    class RepositorioUsuario
    {
        private SQLiteConnection con; private static RepositorioUsuario instancia;

        public static RepositorioUsuario Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }

        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new RepositorioUsuario(filename);
        }


        private RepositorioUsuario(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Usuario>();
        }

        public string EstadoMensaje;
        public int AddNewUser(string Nombre, string Apellido1, string Provincia, string Direccion, string Teléfono, string Correo, string Inscrito, string User, string Clave)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Usuario
                {
                    Nombre = Nombre,
                    Apellido1 = Apellido1,
                    Provincia = Provincia,
                    Direccion = Direccion,
                    Teléfono = Teléfono,
                    Correo = Correo,
                    Inscrito = Inscrito,
                    User = User,
                    Clave = Clave
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;



        }


        public IEnumerable<Usuario> GetAllUsers()
        {
            try
            {
                return con.Table<Usuario>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }


        public Usuario GetUserByUsernameAndPassword(string User, string Clave)
        {
            try
            {
                return con.Table<Usuario>()
                    .Where(u => u.User == User && u.Clave == Clave)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return null;
        }



       





    }
}
