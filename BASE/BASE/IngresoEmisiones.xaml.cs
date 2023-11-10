using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE.Model;
using Java.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoEmisiones : ContentPage
    {
        public IngresoEmisiones()
        {
            InitializeComponent();
            CargarEmisiones();

            btnRegistrarEmision.Clicked += BtnRegistrarEmision_Clicked;
            btnEliminarDatos.Clicked += BtnEliminarDatos_Clicked;
       
           

        }

       

        private void BtnRegistrarEmision_Clicked(object sender, EventArgs e)
        {

            var Mes = PickerMes.SelectedItem?.ToString();
            var Electricidad_consumida = txtelectricidad.Text;
            var Gas_Consumido = txtgas.Text;
            var Cantidad_Residuos = txtresiduos.Text;
            var Tipo_Vehiculo = TipoTransporte.SelectedItem.ToString();
            var Vehiculo_Consumo = txtConsumo.Text;
            var Vehiculo_Recorrido = txtKilometros.Text;

            int result = RepositorioEmisiones.InstanciaEmision.AddNewEmission(Mes, Electricidad_consumida, Gas_Consumido, Cantidad_Residuos, Tipo_Vehiculo, Vehiculo_Consumo, Vehiculo_Recorrido);
            if (result > 0)
            {
                DisplayAlert("Información", "Datos ingresados correctamente", "Aceptar");
            }
            else
            {
                DisplayAlert("Error", "Ocurrió un error al ingresar los datos", "Aceptar");
            }

            CargarEmisiones();
            PickerMes.SelectedItem = -1;
            txtelectricidad.Text = "";
            txtgas.Text = "";
            txtresiduos.Text = "";
            TipoTransporte.SelectedItem = -1;
            txtConsumo.Text = "";
            txtKilometros.Text = "";

        }



        private void CargarEmisiones()
        {
            List<Emisiones> emisiones = RepositorioEmisiones.InstanciaEmision.GetEmisiones();
            lstEmisiones.ItemsSource = emisiones;
        }


        private async void BtnEliminarDatos_Clicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlert("Confirmación", "¿Está seguro que desea eliminar todos los registros?", "Sí", "No");

            if (respuesta)
            {
                int resultado = await RepositorioEmisiones.InstanciaEmision.DeleteAllEmisiones();

                await DisplayAlert("Resultado", RepositorioEmisiones.InstanciaEmision.EstadoMensaje, "OK");
                CargarEmisiones();
            }
        }








    }
}