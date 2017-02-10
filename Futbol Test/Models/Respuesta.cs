using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Models
{
    class Respuesta
    {
        private int id;
        private int pregunta_id;
        private string contenido;
        private string correcta;

        public Respuesta(int id, int pregunta_id, string contenido, string correcta)
        {
            Id = id;
            Pregunta_id = pregunta_id;
            Contenido = contenido;
            Correcta = correcta;
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

        public int Pregunta_id
        {
            get
            {
                return pregunta_id;
            }

            set
            {
                pregunta_id = value;
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

        public string Correcta
        {
            get
            {
                return correcta;
            }

            set
            {
                correcta = value;
            }
        }
    }
}
