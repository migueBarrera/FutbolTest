using Futbol_Test.InterfacesComunicacion;
using Futbol_Test.Models;
using Futbol_Test.Pages;
using Futbol_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class TestPage : Page
    {
        VMTest viewModel;
        public TestPage()
        {
            this.InitializeComponent();

            viewModel = new VMTest(funcion);
            this.DataContext = viewModel;

        }

        public void funcion()
        {
            Frame.Navigate(typeof(ResultadoTestPage), viewModel.respuestasCorrectas);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Test parameters = (Test)e.Parameter;
            viewModel.Test = parameters;

        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog showDialog = new MessageDialog("Si sale del modo Test se perderan las preguntas respondidas");

            showDialog.Title = "Atencion";
            showDialog.Commands.Add(new UICommand("Salir") { Id = 0 });
            showDialog.Commands.Add(new UICommand("Cerrar esta ventana") { Id = 1 });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;

            var result = await showDialog.ShowAsync();

            if ((int)result.Id == 0)

            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                }
            }

        }

        private void listaRespuestas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemModelo = e.AddedItems.FirstOrDefault();
            if (itemModelo != null)
            {
                var respuestaSeleccionada = e.AddedItems.FirstOrDefault() as Respuesta;
                ListViewItem item = listaRespuestas.ContainerFromItem(itemModelo) as ListViewItem;

                if (respuestaSeleccionada.Correcta.Equals("T"))
                {
                    item.Background = new SolidColorBrush(Colors.Green);
                    viewModel.Test.RespuestasCorrectas++;
                }
                else
                {
                    item.Background = new SolidColorBrush(Colors.Red);
                    var ListItemModeloCorrecta = listaRespuestas.Items;
                    ListViewItem itemCorrecta =  obtenerLaCorrecta(ListItemModeloCorrecta);
                    itemCorrecta.Background = new SolidColorBrush(Colors.Green);
                }

                listaRespuestas.SelectedIndex = -1;
                
                
            }
            
        }

        private ListViewItem obtenerLaCorrecta(ItemCollection listado)
        {
            ListViewItem item = null;
            for (int i =0;i<listado.Count;i++)
            {
                Respuesta r = listado[i] as Respuesta;
                if(r.Correcta == "T")
                {
                    var itemModelo = listado[i];
                    item = listaRespuestas.ContainerFromItem(itemModelo) as ListViewItem;
                }
            }
            return item;
        }
    }
}
