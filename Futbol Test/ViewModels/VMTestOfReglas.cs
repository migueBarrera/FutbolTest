using Futbol_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.ViewModels
{
    public class VMTestOfReglas : clsVMBase
    {
        List<Test> _listadoTest;

        public VMTestOfReglas()
        {

        }

        public List<Test> ListadoTest
        {
            get
            {
                return _listadoTest;
            }

            set
            {
                _listadoTest = value;
                NotifyPropertyChanged("ListadoTest");
            }
        }
    }
}
