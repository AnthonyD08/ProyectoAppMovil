using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : FlyoutPage
    {
        public MenuFlyout()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

       

            var item = e.SelectedItem as MenuFlyoutFlyoutMenuItem;
            if (item == null)
                return;


            if (item.Title == "Salir")
            {
                Application.Current.MainPage = new NavigationPage(new Login());
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;


        }

    }
}