using Futbol_Test.Models;
using Futbol_Test.Utilities;
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
    public sealed partial class MenuPrincipalPage : Page
    {
        public MenuPrincipalPage()
        {
            this.InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestUtilities testUtilities = new TestUtilities();
            Test test = testUtilities.generaTestAleatorio(10);
            Frame.Navigate(typeof(TestPage), test);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TestUtilities testUtilities = new TestUtilities();
            List<Regla> litadoReglas = testUtilities.obtenerReglas();
            Frame.Navigate(typeof(ReglasPage), litadoReglas);
        }

    }
}
