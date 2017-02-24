using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.InterfacesComunicacion
{
    public interface NavigationInterface
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage,object e);
    }
}
