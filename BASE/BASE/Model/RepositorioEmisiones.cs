using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using SQLite;

namespace BASE.Model
{
    class RepositorioEmisiones
    {
        private SQLiteConnection con;
        private static RepositorioEmisiones instanciaEmision;

        public static RepositorioEmisiones InstanciaEmision
        {
            get
            {
                if (instanciaEmision == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instanciaEmision;
            }
        }

        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instanciaEmision != null)
            {
                instanciaEmision.con.Close();
            }
            instanciaEmision = new RepositorioEmisiones(filename);
        }

        private RepositorioEmisiones(String dbPathEmisiones)
        {
            con = new SQLiteConnection(dbPathEmisiones);
            con.CreateTable<Emisiones>();
        }

        public string EstadoMensaje;

        public int AddNewEmission(string Mes, string Electricidad_consumida, string Gas_Consumido, string Cantidad_Residuos, string Tipo_Vehiculo, string Vehiculo_Consumo, string Vehiculo_Recorrido)
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = instanciaEmision.con.Insert(new Emisiones
                {
                    Mes = Mes,
                    Electricidad_consumida = Electricidad_consumida,
                    Gas_Consumido = Gas_Consumido,
                    Cantidad_Residuos = Cantidad_Residuos,
                    Tipo_Vehiculo = Tipo_Vehiculo,
                    Vehiculo_Consumo = Vehiculo_Consumo,
                    Vehiculo_Recorrido = Vehiculo_Recorrido,

                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public List<Emisiones> GetEmisiones()
        {
            return con.Table<Emisiones>().ToList();
        }


        public async Task<int> DeleteAllEmisiones()
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = await Task.Run(() => instanciaEmision.con.DeleteAll<Emisiones>());
                EstadoMensaje = string.Format("Cantidad filas eliminadas: {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }


        public int GetTotalElectricidadConsumida(string mesSeleccionado)
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = con.Table<Emisiones>().Where(x => x.Mes == mesSeleccionado).Sum(x => int.Parse(x.Electricidad_consumida));
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }


        public int GetTotalGasConsumido(string mesSeleccionado)

        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = con.Table<Emisiones>().Where(x => x.Mes == mesSeleccionado).Sum(x => int.Parse(x.Gas_Consumido));

            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public int GetTotalResiduos(string mesSeleccionado)
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = con.Table<Emisiones>().Where(x => x.Mes == mesSeleccionado).Sum(x => int.Parse(x.Cantidad_Residuos));
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public string GetTipoVehiculo(string mesSeleccionado)
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            string result = "";
            try
            {
                result = con.Table<Emisiones>().FirstOrDefault(x => x.Mes == mesSeleccionado)?.Tipo_Vehiculo.ToString() ?? "";
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        } 

        public int GetVehiculoConsumo(string mesSeleccionado)
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = con.Table<Emisiones>().Where(x => x.Mes == mesSeleccionado).Sum(x => int.Parse(x.Vehiculo_Consumo));
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public int GetVehiculoRecorrido(string mesSeleccionado)
        {
            if (instanciaEmision == null)
                throw new Exception("Debe llamar al inicializador, acción detenida");

            int result = 0;
            try
            {
                result = con.Table<Emisiones>().Where(x => x.Mes == mesSeleccionado).Select(x => int.Parse(x.Vehiculo_Recorrido)).Sum();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }







    }
}
