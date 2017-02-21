using Futbol_Test.DAL.SQLite;
using Futbol_Test.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Utilities
{
    public class TestUtilities
    {
        //TODO, usar una lista negra a la hora de generar los aleatorios, y sólo llamar a la base de datos con los números generados
        private String PATH_DB = "Filename=sqliteFutbolTest.db";

        /// <summary>
        /// Genera un test con un número de preguntas aleatorios
        /// </summary>
        /// <param name="numeroPreguntas"></param>
        /// <returns></returns>
        public Test generaTestAleatorio(int numeroPreguntas)
        {
            Test devolver = new Test();
            int totalPreguntas = 0;
            List<Pregunta> miLista = new List<Pregunta>();
            String cadenaCuentaPreguntas = "Select count(*) from " + CONTRATO_DB.Pregunta_DB.TABLE_NAME;
            String cadenaDevuelvePreguntas = String.Format("Select {0},{1},{2},{3} from {4} where id={5}", CONTRATO_DB.Pregunta_DB.ID,
                                                            CONTRATO_DB.Pregunta_DB.REGLA_ID,
                                                            CONTRATO_DB.Pregunta_DB.CONTENIDO,
                                                            CONTRATO_DB.Pregunta_DB.ANOTACION,
                                                            CONTRATO_DB.Pregunta_DB.TABLE_NAME,
                                                            ALEATORIO);
            SqliteCommand cuentaPreguntas,devuelvePreguntas;

            using (SqliteConnection db = new SqliteConnection(PATH_DB))
            {
                db.Open();
                cuentaPreguntas= new SqliteCommand(cadenaCuentaPreguntas, db);
                totalPreguntas = cuentaPreguntas.ExecuteReader().GetInt32(0);
                devuelvePreguntas = new SqliteCommand(cadenaCuentaPreguntas, db);
                SqliteDataReader lector= devuelvePreguntas.ExecuteReader();
                while(lector.Read())
                {
                    //TODO Otro bucle para recoger las respuestas de esa pregunta
                    Pregunta miPregunta = new Pregunta(lector.GetInt32(0), lector.GetInt32(1), lector.GetString(2), lector.GetString(3),new List<Respuesta>());
                }
            }
            
            for(int i = 0; i < numeroPreguntas; i++)
            {
                Random aleatorio = new Random();
                //Ponemos totalPreguntas-i, porque en cada iteración, el total de preguntas
                aleatorio.Next(0, totalPreguntas - i);
            }

            return devolver;
        }
    }
}
