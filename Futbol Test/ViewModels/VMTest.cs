using Futbol_Test.Models;
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
        private Pregunta _preguntaMostrada;
        private Respuesta _respuestaSeleccionada;
        private DelegateCommand _siguientePreguntaComand;
        
        

       
        #endregion

        public VMTest()
        {
            //Rellenar Testç
            TestUtilities man = new TestUtilities();
            this.Test = man.generaTestAleatorio(10);
            PreguntaMostrada = this.Test.obtenerSiguientePregunta();
            _siguientePreguntaComand = new DelegateCommand(siguientePreguntaComand_executed, siguientePreguntaComand_CanExecuted);
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
                _test.calcularTotalPreguntas();
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

                if(_respuestaSeleccionada!= null)
                {
                    if (_respuestaSeleccionada.Correcta.Equals("T"))
                    {

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
            PreguntaMostrada = Test.obtenerSiguientePregunta();
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
