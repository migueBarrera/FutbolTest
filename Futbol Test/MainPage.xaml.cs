using Futbol_Test.DAL.ApiRest;
using Futbol_Test.DAL.SQLite;
using Futbol_Test.Models;
using Futbol_Test.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Futbol_Test
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        /*
        
            Si Hay Internet
                Si existen datos 
                    Si existen actualizaciones
                        descargar y grabar trivial
                    Fin si 
                Si no existen
                     descargar y grabar trivial              
            Si no Hay internet
                si no existen datos
                    Ir a Error (Se necesita internet para descargar la base de datos la 1ªvez)
                Fin_Si
            Fin-Sino

            Ir a la pantalla de inicio
     */

        public MainPage()
        {
            this.InitializeComponent();
            SQLiteManejadora miMane = new SQLiteManejadora();
            
            MainUtilities misUtilidades = new MainUtilities(cuandoAcabe);
            misUtilidades.checkActualizacion();

            
        }

        public void cuandoAcabe()
        {
            progress.IsActive = false;

            MyFrame.Navigate(typeof(IndexPage));
        }
    }
}
