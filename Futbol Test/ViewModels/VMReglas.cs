using Futbol_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.ViewModels
{
    public class VMReglas : clsVMBase
    {
        private List<Regla> _listadoReglas;

        public VMReglas()
        {

        }

        public List<Regla> ListadoReglas
        {
            get
            {
                return _listadoReglas;
            }

            set
            {
                _listadoReglas = value;
                NotifyPropertyChanged("ListadoReglas");
            }
        }
    }
}
