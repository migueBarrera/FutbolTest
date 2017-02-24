using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Futbol_Test.InterfacesComunicacion
{
    public sealed class ImpInterfaceComunicacion : NavigationInterface
    {
        public void Navigate(Type sourcePage)
        {
            this.Navigate(sourcePage);
        }
        //NOME VALEE ESTOO MIGUE UHAY QUE USAR UN EVNENTO PARA COMUNICAR DESDE EL VIEWMODEL A LA V.cs QUE CAMBIE DE FRAME PERO EL DEL PADRE Y NO EL DDE WINDOWS
        public void Navigate(Type sourcePage, object e)
        {
            this.Navigate(sourcePage, e);
            
        }
    }
}
