using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BASE.Model;

namespace BASE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            btnLogin.Clicked += btnLogin_Clicked;
            
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            var user = RepositorioUsuario.Instancia.GetUserByUsernameAndPassword(txtUser.Text, txtClave.Text);
            if (user != null)
            {
                await ((NavigationPage)this.Parent).PushAsync(new MenuFlyout());
            }
            else
            {
                await DisplayAlert("Error de inicio de sesión", "El nombre de usuario o la contraseña son incorrectos", "OK");
            }
        }

        private void lblRegistro(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
    }
}