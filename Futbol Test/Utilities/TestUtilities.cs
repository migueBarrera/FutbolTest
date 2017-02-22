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
        //TODO,Testear!!!
        private String PATH_DB = "Filename=sqliteFutbolTest.db";

        /// <summary>
        /// Genera un test con un número de preguntas aleatorios
        /// </summary>
        /// <param name="numeroPreguntas"></param>
        /// <returns></returns>
        public Test generaTestAleatorio(int numeroPreguntas)
        {
            Test devolver = new Test();
            int totalPreguntas = 0,aleatorio=0,preguntaID;
            bool aleatorioEnListaNegra;

            List<Pregunta> miLista = new List<Pregunta>();
            List<Respuesta> respuestas;
            List<int> listaNegra = new List<int>();

            Random generador = new Random();
            String cadenaCuentaPreguntas = "Select count(*) from " + CONTRATO_DB.Pregunta_DB.TABLE_NAME;
           
            
            SqliteCommand cuentaPreguntas,devuelvePreguntas,devuelveRespuestas;

            using (SqliteConnection db = new SqliteConnection(PATH_DB))
            {
                db.Open();
                cuentaPreguntas= new SqliteCommand(cadenaCuentaPreguntas, db);
                SqliteDataReader lectorCuentaPreguntas = cuentaPreguntas.ExecuteReader();
                lectorCuentaPreguntas.Read();
                totalPreguntas = Convert.ToInt32(lectorCuentaPreguntas[0]);
                
                for (int i = 0; i < numeroPreguntas; i++)
                {

                    do
                    {
                        aleatorio = generador.Next(0, totalPreguntas);
                        if (!listaNegra.Contains(aleatorio))
                        {
                            aleatorioEnListaNegra = false;
                            listaNegra.Add(aleatorio);
                        }else
                        {
                            aleatorioEnListaNegra = true;
                        }
                    } while (aleatorioEnListaNegra);


                    String cadenaDevuelvePreguntas = String.Format("Select {0},{1},{2},{3} from {4} where {0}={5}", 
                                                            CONTRATO_DB.Pregunta_DB.ID,
                                                            CONTRATO_DB.Pregunta_DB.REGLA_ID,
                                                            CONTRATO_DB.Pregunta_DB.CONTENIDO,
                                                            CONTRATO_DB.Pregunta_DB.ANOTACION,
                                                            CONTRATO_DB.Pregunta_DB.TABLE_NAME,
                                                            aleatorio);
                    devuelvePreguntas = new SqliteCommand(cadenaDevuelvePreguntas, db);
                    SqliteDataReader lector = devuelvePreguntas.ExecuteReader();
                    //TODO Buscar Respuestas 
                    lector.Read();
                    preguntaID = Convert.ToInt32(lector[CONTRATO_DB.Pregunta_DB.ID]);
                    String cadenaDevuelveRespuestas= String.Format("Select {0},{1},{2},{3} from {4} where {1}={5}",
                                                            CONTRATO_DB.Respuesta_DB.ID,
                                                            CONTRATO_DB.Respuesta_DB.PREGUNTA_ID,
                                                            CONTRATO_DB.Respuesta_DB.CONTENIDO,
                                                            CONTRATO_DB.Respuesta_DB.CORRECTA,
                                                            CONTRATO_DB.Respuesta_DB.TABLE_NAME,
                                                            preguntaID);

                    devuelveRespuestas = new SqliteCommand(cadenaDevuelveRespuestas, db);
                    SqliteDataReader lectorRespuestas= devuelveRespuestas.ExecuteReader();
                    respuestas = new List<Respuesta>();
                    while (lectorRespuestas.Read())
                    {
                        int idRespuesta = Convert.ToInt32(lectorRespuestas[CONTRATO_DB.Respuesta_DB.ID]);
                        int idPregunta = Convert.ToInt32(lectorRespuestas[CONTRATO_DB.Respuesta_DB.PREGUNTA_ID]);
                        String contenido = Convert.ToString(lectorRespuestas[CONTRATO_DB.Respuesta_DB.CONTENIDO]);
                        String correcta = Convert.ToString(lectorRespuestas[CONTRATO_DB.Respuesta_DB.CORRECTA]);
                        Respuesta respuesta = new Respuesta(idRespuesta, idPregunta,
                                                            contenido,correcta);
                        respuestas.Add(respuesta);
                    }
                    Pregunta miPregunta = new Pregunta(lector.GetInt32(0), lector.GetInt32(1), lector.GetString(2), lector.GetString(3),respuestas);
                    devolver.ListaPreguntas.Add(miPregunta);
                }
                
           
            }
            
           

            return devolver;
        }
    }
}
