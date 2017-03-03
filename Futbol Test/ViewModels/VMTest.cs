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
using Windows.UI;
using Windows.UI.Xaml.Media;

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
        private bool visibleBoton;
        private bool _enabledList;



        #endregion

        public VMTest(Action action)
        {
            _siguientePreguntaComand = new DelegateCommand(siguientePreguntaComand_executed, siguientePreguntaComand_CanExecuted);
            this.funcion = action;
            EnabledList = true;
            visibleBoton = false;
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
                EnabledList = true;
                visibleBoton = false;
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
                EnabledList = false;

                visibleBoton = true;
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

        public bool EnabledList
        {
            get
            {
                return _enabledList;
            }

            set
            {
                _enabledList = value;
                NotifyPropertyChanged("EnabledList");
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
                visibleBoton = false;
                PreguntaMostrada = preguntaAMostrar;
            }
            else
            {
                
                respuestasCorrectas = Test.RespuestasCorrectas;
                funcion.Invoke();
            }

        }

        private bool siguientePreguntaComand_CanExecuted()
        {
            bool sePuedePulsarElBoton = false;

            if (visibleBoton == true)
            {
                sePuedePulsarElBoton = true;
            }
            return sePuedePulsarElBoton;
        }
        #endregion


    }
}
