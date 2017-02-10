using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Models
{
    class Pregunta
    {
   

        private int id;
        private int regla_id;
        private string contenido;
        private string anotacion;
        private List<Respuesta> respuestas;

        public Pregunta(int id, int regla_id, string contenido, string anotacion, List<Respuesta> respuestas)
        {
            Id = id;
            Regla_id= regla_id;
            Contenido = contenido;
            Anotacion = anotacion;
            Respuestas = respuestas;
        }

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

        public int Regla_id
        {
            get
            {
                return regla_id;
            }

            set
            {
                regla_id = value;
            }
        }

        public string Contenido
        {
            get
            {
                return contenido;
            }

            set
            {
                contenido = value;
            }
        }

        public string Anotacion
        {
            get
            {
                return anotacion;
            }

            set
            {
                anotacion = value;
            }
        }

        internal List<Respuesta> Respuestas
        {
            get
            {
                return respuestas;
            }

            set
            {
                respuestas = value;
            }
        }
    }
}
