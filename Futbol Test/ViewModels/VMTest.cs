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
        private Test _test;
        private Pregunta _preguntaMostrada;
        private Respuesta _respuestaSeleccionada;
        private Boolean _mostrarBoton;
        

       
        #endregion

        public VMTest()
        {
            //Rellenar Test

            //Iniciar preguntas correctas
            
        }

        public Test Test
        {
            get
            {
                return _test;
            }

            set
            {
                _test = value;
            }
        }

        public Pregunta PreguntaMostrada
        {
            get
            {
                return _preguntaMostrada;
            }

            set
            {
                _preguntaMostrada = value;
                NotifyPropertyChanged("PreguntaMostrada");
            }
        }



        public bool MostrarBoton
        {
            get
            {
                return _mostrarBoton;
            }

            set
            {
                _mostrarBoton = value;
                NotifyPropertyChanged("MostrarBoton");
            }
        }

        public Respuesta RespuestaSeleccionada
        {
            get
            {
                return _respuestaSeleccionada;
            }

            set
            {
                _respuestaSeleccionada = value;
                if (_respuestaSeleccionada.Correcta.Equals("T"))
                {

                }
            }
        }


        #region Metodos
        public void visibilidadBotonSiguiente(bool indicador)
        {
                MostrarBoton = indicador;
        }
        #endregion


    }
}
