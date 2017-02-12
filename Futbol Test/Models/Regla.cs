using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Models
{
    public class Regla
    {
        private int id ;
        private string titulo;
        private List<Pregunta> preguntas;

        public Regla(int id, string titulo, List<Pregunta> preguntas)
        {
            Id = id;
            Titulo = titulo;
            Preguntas = preguntas;
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

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public List<Pregunta> Preguntas
        {
            get
            {
                return preguntas;
            }

            set
            {
                preguntas = value;
            }
        }
    }
}
