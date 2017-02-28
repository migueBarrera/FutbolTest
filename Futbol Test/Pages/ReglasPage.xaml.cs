using Futbol_Test.InterfacesComunicacion;
using Futbol_Test.Models;
using Futbol_Test.Utilities;
using Futbol_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Futbol_Test.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ReglasPage : Page
    {
        VMReglas viewModel;
        
        public ReglasPage()
        {
            this.InitializeComponent();
            viewModel = (VMReglas)DataContext;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            List<Regla> parameters = (List<Regla>)e.Parameter;
            viewModel.ListadoReglas = parameters;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Regla regla = (Regla)e.ClickedItem;
           
           
            Frame.Navigate(typeof(TestOfReglasPage),regla);
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
