using Futbol_Test.DAL.ApiRest;
using Futbol_Test.DAL.SQLite;
using Futbol_Test.Models;
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
        Trivial trivial;
        bool hayInternet;
        ClienteApi clienteApi;

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

        private SQLiteManejadora manejadora;
        public  MainPage()
        {
            this.InitializeComponent();
            manejadora = new SQLiteManejadora();
            hayInternet = NetworkInterface.GetIsNetworkAvailable();
            checkActualizacion();
            //Si Hay Internet
            if (hayInternet)
            {
                //Si existen datos
                if (manejadora.isDataExists())
                {
                    //Si existen actualizaciones
                    if(checkActualizacion())
                    //descargar y grabar trivial
                    //Si no existen
                }
                else
                {
                    //descargar y grabar trivial
                    //descargarYGrabarTrivial();
                }
                //Si no Hay internet
            }
            else
            {
                //si no existen datos
                if (manejadora.isDataExists() == false)
                {
                    //Ir a Error (Se necesita internet para descargar la base de datos la 1ªvez)
                    //Fin_Si
                }
                //Fin - Sino
            }



            //        Ir a la pantalla de inicio

            

         

        }

        public async Task descargarYGrabarTrivial()
        {
            SQLiteManejadora manejadoraSqlite = new SQLiteManejadora();

            trivial = await descargarTrivial();

            manejadoraSqlite.grabarTrivial(trivial);
            
        }

        public async Task<Trivial> descargarTrivial()
        {
            clienteApi = new ClienteApi();
            return await clienteApi.getTrivial();
        }

        public async bool checkActualizacion()
        {
            bool hayNuevaActualizacion = false;
            clienteApi = new ClienteApi();
            manejadora = new SQLiteManejadora();
            
            int versionTrivialLocal = manejadora.getVersionTrivial();
            int versionTrivialInternet = await obtenerVersionTrivialInternet();
            if (versionTrivialInternet > versionTrivialLocal)
            {
                hayNuevaActualizacion = true;
            }

            return hayNuevaActualizacion;
        }

        public async Task<int> obtenerVersionTrivialInternet()
        {
            int versionTrivialInternet = await clienteApi.getVersiontrivial();
            return versionTrivialInternet;
        }

       

    }
}
