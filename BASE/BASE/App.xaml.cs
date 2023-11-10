using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BASE.Model;

namespace BASE
{
    public partial class App : Application
    {

        public App(string filename)
        {
            
            InitializeComponent();
            RepositorioUsuario.Inicializador(filename);
            RepositorioEmisiones.Inicializador(filename);
            MainPage = new NavigationPage(new MainPage());

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
