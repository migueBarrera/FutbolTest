using Futbol_Test.DAL.ApiRest;
using Futbol_Test.DAL.SQLite;
using Futbol_Test.Models;
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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Futbol_Test
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Trivial trivial;
        public MainPage()
        {
            this.InitializeComponent();

            descargarYgrabarTrivial();
            
        }

        public async void descargarYgrabarTrivial()
        {
            SQLiteManejadora manejadoraSqlite = new SQLiteManejadora();
            ClienteApi clienteApi = new ClienteApi();

            trivial = await clienteApi.getTrivial();

            manejadoraSqlite.grabarTrivial(trivial);
            progress.IsActive = false;
        }
    }
}
