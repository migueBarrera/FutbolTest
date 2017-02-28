using Futbol_Test.InterfacesComunicacion;
using Futbol_Test.Models;
using Futbol_Test.Pages;
using Futbol_Test.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.ViewModels
{
    public class VMTest : clsVMBase
    {
        #region Atributos
        private Test _test;
        public Action funcion { get; set; }
        private Pregunta _preguntaMostrada;
        private Respuesta _respuestaSeleccionada;
        private DelegateCommand _siguientePreguntaComand;
        public int respuestasCorrectas { get; set; }


        #endregion

        public VMTest(Action action)
        {
            _siguientePreguntaComand = new DelegateCommand(siguientePreguntaComand_executed, siguientePreguntaComand_CanExecuted);
            this.funcion = action;
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
                Test.calcularTotalPreguntas();
                PreguntaMostrada = Test.obtenerSiguientePregunta();
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





        public Respuesta RespuestaSeleccionada
        {
            get
            {
                return _respuestaSeleccionada;
            }

            set
            {
                _respuestaSeleccionada = value;

                if (_respuestaSeleccionada != null)
                {
                    if (_respuestaSeleccionada.Correcta.Equals("T"))
                    {
                       Test.RespuestasCorrectas++;
                    }
                    else
                    {

                    }
                }

                _siguientePreguntaComand.RaiseCanExecuteChanged();


            }
        }



        public DelegateCommand SiguientePreguntaComand
        {
            get
            {
                return _siguientePreguntaComand;
            }
        }



        #region Metodos

        #endregion

        #region Command
        private void siguientePreguntaComand_executed()
        {
            var preguntaAMostrar = Test.obtenerSiguientePregunta();
            if (preguntaAMostrar != null)
            {
                PreguntaMostrada = preguntaAMostrar;
            }
            else
            {
                // _navigationInterface.Navigate(typeof(ResultadoTestPage),Test.RespuestasCorrectas);
                respuestasCorrectas = Test.RespuestasCorrectas;
                funcion.Invoke();
            }

        }

        private bool siguientePreguntaComand_CanExecuted()
        {
            bool sePuedePulsarElBoton = false;

            if (RespuestaSeleccionada != null)
            {
                sePuedePulsarElBoton = true;
            }
            return sePuedePulsarElBoton;
        }
        #endregion


    }
}
