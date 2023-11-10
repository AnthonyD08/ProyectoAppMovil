using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BASE.Model;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
   
        public Registro()
        {
            InitializeComponent();
            btnRegistrarse.Clicked += BtnRegistrarse_Clicked;
        }

        private void BtnRegistrarse_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            RepositorioUsuario.Instancia.AddNewUser(txtNombre.Text, txtApellido.Text, txtProvincia.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, txtInscrito.Text, txtUser.Text, txtClave.Text);
            StatusMessage.Text = RepositorioUsuario.Instancia.EstadoMensaje;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtProvincia.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtInscrito.Text = "";
            txtUser.Text = "";
            txtClave.Text = "";
        }

        /*private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }*/
    }
}