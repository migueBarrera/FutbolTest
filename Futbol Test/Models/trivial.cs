using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Models
{
    public class Trivial
    {
        private int id;
        private string version;
        private string idioma;
        private string descripcion;
        private List<Regla> reglas;

        public Trivial(int id, string version, string idioma, string descripcion, List<Regla> reglas)
        {
            Id = id;
            Version = version;
            Idioma = idioma;
            Descripcion = descripcion;
            Reglas = reglas;
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

        public string Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public string Idioma
        {
            get
            {
                return idioma;
            }

            set
            {
                idioma = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public List<Regla> Reglas
        {
            get
            {
                return reglas;
            }

            set
            {
                reglas = value;
            }
        }
    }
}
