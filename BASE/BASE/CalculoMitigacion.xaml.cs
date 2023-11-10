using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculoMitigacion : ContentPage
    {
        private string _mesSeleccionado;
        public string MesSeleccionado
        {
            get { return _mesSeleccionado; }
            set
            {
                if (_mesSeleccionado != value)
                {
                    _mesSeleccionado = value;
                    OnPropertyChanged(nameof(MesSeleccionado));
                }
            }
        }

        public CalculoMitigacion()
        {
            InitializeComponent();
            PickerMes.SelectedIndexChanged += PickerMes_SelectedIndexChanged;
            CalcularMitigacion();
        }


        private void PickerMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var mesSeleccionado = picker.SelectedItem as string;

            switch (mesSeleccionado)
            {
                case "Enero":
                    MesSeleccionado = "Enero";
                    break;
                case "Febrero":
                    MesSeleccionado = "Febrero";
                    break;
                case "Marzo":
                    MesSeleccionado = "Marzo";
                    break;

                case "Abril":
                    MesSeleccionado = "Abril";
                    break;

                case "Mayo":
                    MesSeleccionado = "Mayo";
                    break;

                case "Junio":
                    MesSeleccionado = "Junio";
                    break;

                case "Julio":
                    MesSeleccionado = "Julio";
                    break;

                case "Agosto":
                    MesSeleccionado = "Agosto";
                    break;

                case "Septiembre":
                    MesSeleccionado = "Septiembre";
                    break;

                case "Octubre":
                    MesSeleccionado = "Octubre";
                    break;

                case "Noviembre":
                    MesSeleccionado = "Noviembre";
                    break;


                case "Diciembre":
                    MesSeleccionado = "Diciembre";
                    break;
            }



            CalcularMitigacion();









        }

        private void CalcularMitigacion()
        {

            if (string.IsNullOrEmpty(MesSeleccionado))
            {
                lblElectricidad.Text = "Emisiones de electricidad consumida:";
                lblResiduos.Text = "Emisiones de residuos producidos:";
                lblGas.Text = "Emisiones de gas utilizado:";
                lblvehiculo.Text = "Emisiones de transporte: ";
                
                return;
            }

            string mesSeleccionado = MesSeleccionado;
            double totalElectricidadConsumida = RepositorioEmisiones.InstanciaEmision.GetTotalElectricidadConsumida(mesSeleccionado);
            double totalResiduos = RepositorioEmisiones.InstanciaEmision.GetTotalResiduos(mesSeleccionado);
            double totalGas = RepositorioEmisiones.InstanciaEmision.GetTotalGasConsumido(mesSeleccionado);
            double vehiculoConsumo = RepositorioEmisiones.InstanciaEmision.GetVehiculoConsumo(mesSeleccionado);
            double vehiculoRecorrido = RepositorioEmisiones.InstanciaEmision.GetVehiculoRecorrido(mesSeleccionado);

            double factorEmision = 0;
            string tipo_vehiculo = RepositorioEmisiones.InstanciaEmision.GetTipoVehiculo(mesSeleccionado);

            if (tipo_vehiculo == "Automovil (Gasolina)")
            {
                factorEmision = 2.32;
            }
            else if (tipo_vehiculo == "Automovil (Diesel)")
            {
                factorEmision = 2.60;
            }
            else if (tipo_vehiculo == "Bus público")
            {
                factorEmision = 0.04;
            }
            else if (tipo_vehiculo == "Bicicleta")
            {
                factorEmision = 0;
            }
            else if (tipo_vehiculo == "Caminando")
            {
                factorEmision = 0;
            }

            double electricidadEmision = totalElectricidadConsumida * 0.41;    //Factor de emision de electricidad
            double residuosEmision = totalResiduos * 3;
            double gasEmision = totalGas * 2.70;

            double emisionesVehiculo = vehiculoRecorrido * factorEmision / vehiculoConsumo;
            double emisionesVehiculoRedondeado = Math.Round(emisionesVehiculo, 2);


            if(double.IsNaN(emisionesVehiculo))
            {
                emisionesVehiculoRedondeado = 0;
            }
            
         

            lblElectricidad.Text = "Emisiones de electricidad consumida: " + electricidadEmision.ToString() + " Co2/Kg";
            lblGas.Text = "Emisiones de Gas utilizado: " + gasEmision.ToString() + " Co2/Kg";
            lblResiduos.Text = "Emisiones de residuos producidos: " + residuosEmision.ToString() + " Co2/Kg";
            lblvehiculo.Text = "Emisiones de vehiculo utilizado: " + emisionesVehiculoRedondeado.ToString() + " Co2/Kg";

            //Recomendaciones Electricidad
            if (electricidadEmision == 0)
            {
                lblRecomendacionesElectricidad.Text = "";
                
            }
            else if (electricidadEmision < 25)
            {
                // Recomendación para emisiones eléctricas bajas
                lblRecomendacionesElectricidad.Text = " Tu consumo eléctrico es eficiente.";
            }
            else if (electricidadEmision >= 25 && electricidadEmision < 45)
            {
                // Recomendación para emisiones eléctricas medias
                lblRecomendacionesElectricidad.Text = "Considera apagar y desconectar los equipos electricos cuando no se esten utilizando.";
            }
            else
            {
                // Recomendación para emisiones eléctricas altas
                lblRecomendacionesElectricidad.Text = "Considera cambiar los equipos electricos por otros mas eficientes. Evitar usar el aire acondicionado o utilizar equipos mas eficientes.";
            }




            //Recomendaciones Gas

            if (gasEmision == 0)
            {
                lblRecomendacionesGas.Text = "";

            }


            else if (gasEmision < 25)
            {
             
                lblRecomendacionesGas.Text = " Tu consumo de gas es eficiente.";
            }
            else if (gasEmision >= 25 && gasEmision < 55)
            {

                lblRecomendacionesGas.Text = " Utilizar equipos mas eficientes para ayudar a reducir el consumo de gas.";
            }
            else
            {

                lblRecomendacionesGas.Text = "Realizar el mantemiento requerido a las tuberias de gas para identificar fugas, pues el consumo es muy alto.";
            }


            //Recomendaciones de residuos

            if (residuosEmision == 0)
            {
                lblRecomendacionesResiduos.Text = "";

            }

            else if (residuosEmision < 30)
            {
              
                lblRecomendacionesResiduos.Text = "Los residuos producidos son bajos.";
            }
            else if (residuosEmision >= 30 && residuosEmision < 55)
            {

                lblRecomendacionesResiduos.Text = "Evitar el uso de papel y utilizar productos reciclables.";
            }
            else
            {

                lblRecomendacionesResiduos.Text = "Evitar comprar productos con envoltorios y cooperar con el reciclaje ";
            }

            //Recomendaciones de transporte

            if (emisionesVehiculoRedondeado == 0)
            {
                lblRecomendacionesTransporte.Text = "";

            }
            
            else  if (emisionesVehiculoRedondeado < 25)
            {

                lblRecomendacionesTransporte.Text = "El metodo de transporte es eficiente";
            }
            else if (emisionesVehiculoRedondeado >= 25 && emisionesVehiculoRedondeado < 45)
            {

                lblRecomendacionesTransporte.Text = "Utilizar preferiblemente transporte publico o si es posible, un automovil electrico o bicicleta.";
            }
            else
            {

                lblRecomendacionesTransporte.Text = "Revisar que el automovil que se utilize este al dia con el mantenimiento. Evitar utilizar el aire acondicionado en el automovil.";
            }



        }



    }
        }
    
