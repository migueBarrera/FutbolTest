using Futbol_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.ViewModels
{
    public class VMTest : clsVMBase
    {
        #region Atributos
       // private Test _test;
        private Pregunta _preguntaMostrada;
        private int[] _preguntasCorrectas;

       
        #endregion

        public VMTest()
        {
            //Rellenar Test

            //Iniciar preguntas correctas
            
        }

       /* public Test Test
        {
            get
            {
                return _test;
            }

            set
            {
                _test = value;
            }
        }*/

        public Pregunta PreguntaMostrada
        {
            get
            {
                return _preguntaMostrada;
            }

            set
            {
                _preguntaMostrada = value;
            }
        }

        public int[] PreguntasCorrectas
        {
            get
            {
                return _preguntasCorrectas;
            }

            set
            {
                _preguntasCorrectas = value;
            }
        }


    }
}
