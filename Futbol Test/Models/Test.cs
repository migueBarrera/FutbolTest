using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Models
{
    public class Test
    {
        #region Atributos
        private int id;
        private List<Pregunta> listaPreguntas;
        private int respuestasCorrectas;
        #endregion

        #region Constructores
        public Test() { this.id = 0;this.listaPreguntas = new List<Pregunta>(); this.respuestasCorrectas = 0; }
        public Test(int id, List<Pregunta> listaPreguntas, int respuestasCorrectas)
        {
            this.id = id;
            this.listaPreguntas = listaPreguntas;
            this.respuestasCorrectas = respuestasCorrectas;
        }
        #endregion

        #region Propiedades
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public List<Pregunta> ListaPreguntas
        {
            get
            {
                return listaPreguntas;
            }

            set
            {
                listaPreguntas = value;
            }
        }

        public int RespuestasCorrectas
        {
            get
            {
                return respuestasCorrectas;
            }

            set
            {
                respuestasCorrectas = value;
            }
        }

        #endregion
    }
}
