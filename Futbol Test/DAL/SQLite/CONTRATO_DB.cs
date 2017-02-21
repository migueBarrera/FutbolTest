using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.DAL.SQLite
{
    class CONTRATO_DB
    {

        public static class Trivial_DB
        {
            public static String TABLE_NAME = "Trivials";
            public static String ID = "Id";
            public static String VERSION = "Version";
            public static String IDIOMA = "Idioma";
            public static String DESCRIPCION = "descripcion";
        }

        public static class Regla_DB
        {
            public static String TABLE_NAME = "Reglas";
            public static String ID = "Id";
            public static String TITULO = "Titulo";
        }

        public static class Pregunta_DB
        {
            public static String TABLE_NAME = "Preguntas";
            public static String ID = "Id";
            public static String CONTENIDO = "Contenido";
            public static String ANOTACION = "Anotacion";
            public static String REGLA_ID = "Regla_id";
        }

        public static class Respuesta_DB
        {
            public static String TABLE_NAME = "Respuestas";
            public static String ID = "Id";
            public static String CONTENIDO = "Contenido";
            public static String PREGUNTA_ID = "Pregunta_id";
            public static String CORRECTA = "Correcta";
        }
    }
}
