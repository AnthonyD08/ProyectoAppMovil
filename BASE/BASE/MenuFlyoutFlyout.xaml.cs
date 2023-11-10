using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyoutFlyout : ContentPage
    {
        public ListView ListView;

        public MenuFlyoutFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuFlyoutFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuFlyoutFlyoutViewModel : INotifyPropertyChanged
        {

            public ObservableCollection<MenuFlyoutFlyoutMenuItem> MenuItems { get; set; }

      


            public MenuFlyoutFlyoutViewModel()
            {


                MenuItems = new ObservableCollection<MenuFlyoutFlyoutMenuItem>(new[]
                {

                    new MenuFlyoutFlyoutMenuItem { Id = 0, Title = "Inicio", IconSource="home.png", TargetType=typeof(MenuFlyoutDetail)},
                    new MenuFlyoutFlyoutMenuItem { Id = 1, Title = "Base técnica", IconSource="hoja.png", TargetType=typeof(BaseTecnica) },
                    new MenuFlyoutFlyoutMenuItem { Id = 2, Title = "Ingresar emisiones", IconSource="registro.png", TargetType=typeof(IngresoEmisiones) },
                    new MenuFlyoutFlyoutMenuItem { Id = 3, Title = "Calcular mitigación", IconSource="calculadora.png", TargetType=typeof(CalculoMitigacion) },
                    new MenuFlyoutFlyoutMenuItem { Id = 5, Title = "Ayuda", IconSource="ayuda.png", TargetType=typeof(Ayuda) },
                    new MenuFlyoutFlyoutMenuItem { Id = 6, Title = "Salir", IconSource="salida.png", TargetType=typeof(Login) },
                });

           

            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}