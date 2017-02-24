using Futbol_Test.Models;
using Futbol_Test.Pages;
using Futbol_Test.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace Futbol_Test
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class IndexPage : Page
    {
        public IndexPage()
        {

            this.InitializeComponent();
            MyFrame.Navigate(typeof(MenuPrincipalPage));

            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }

        /*private void MyFrame_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var frameType = MyFrame.SourcePageType;
            String nombreFrame = frameType.FullName;
            
            switch (nombreFrame) {
                case "Futbol_Test.Pages.MenuPrincipalPage":
                    BackButton.Visibility  = Visibility.Collapsed;
                    break;
                case "Futbol_Test.Pages.ReglasPagePage":
                    BackButton.Visibility = Visibility.Visible;
                    break;
                case "Futbol_Test.Pages.TestPage":
                    BackButton.Visibility = Visibility.Collapsed;
                    break;

            }

            

        }*/
    }
}
