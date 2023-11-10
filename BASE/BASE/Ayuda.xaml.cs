using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ayuda : ContentPage
	{
		public Ayuda ()
		{
			InitializeComponent ();

		}

        private void HeaderLabel1(object sender, EventArgs e)
        {
            ContentView1.IsVisible = !ContentView1.IsVisible;
        }

        private void HeaderLabel2(object sender, EventArgs e)
        {
            ContentView2.IsVisible = !ContentView2.IsVisible;
        }

        private void HeaderLabel3(object sender, EventArgs e)
        {
            ContentView3.IsVisible = !ContentView3.IsVisible;
        }

        private void HeaderLabel4(object sender, EventArgs e)
        {
            ContentView4.IsVisible = !ContentView4.IsVisible;
        }

        private void Link(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://cambioclimatico.go.cr/ ", BrowserLaunchMode.SystemPreferred);
        }

    }
}