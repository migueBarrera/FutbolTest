using Futbol_Test.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.DAL.SQLite
{
    public class SQLiteManejadora
    {

        static SqliteTransaction miTransaccion;
        private SqliteConnection db;
        private String PATH_DB = "Filename=sqliteFutbolTest.db";

        public SQLiteManejadora()
        {
           
        }

        public void borrarDataBase()
        {
            String cadenaTrivial = String.Format("Drop table {0}",CONTRATO_DB.Trivial_DB.TABLE_NAME);
            String cadenaRegla = String.Format("Drop table {0}", CONTRATO_DB.Regla_DB.TABLE_NAME);
            String cadenaPregunta = String.Format("Drop table {0}", CONTRATO_DB.Pregunta_DB.TABLE_NAME);
            String cadenaRespuesta = String.Format("Drop table {0}", CONTRATO_DB.Respuesta_DB.TABLE_NAME);

           // SqliteEngine.UseWinSqlite3(); //Configuring library to use SDK version of SQLite
            using (db = new SqliteConnection(PATH_DB))
            {
                db.Open();

                SqliteCommand TableTrivials = new SqliteCommand(cadenaTrivial, db);
                SqliteCommand TableReglas = new SqliteCommand(cadenaRegla, db);
                SqliteCommand TablePreguntas = new SqliteCommand(cadenaPregunta, db);
                SqliteCommand TableRespuestas = new SqliteCommand(cadenaRespuesta, db);
                try
                {
                    TableTrivials.ExecuteReader();
                    TableReglas.ExecuteReader();
                    TablePreguntas.ExecuteReader();
                    TableRespuestas.ExecuteReader();
                }
                catch (SqliteException e)
                {
                    //Do nothing
                }
            }
        }
        public void CreateDatabaseIfNotExists()
        {
           
            using (db = new SqliteConnection(PATH_DB))
            {
                db.Open();
                
                String tablaTrivials = String.Format("Create table if not exists {0} ({1} Integer Primary Key,{2} Nvarchar(2048),{3} Nvarchar(2048),{4} Nvarchar(2048))",
                                            CONTRATO_DB.Trivial_DB.TABLE_NAME, CONTRATO_DB.Trivial_DB.ID, CONTRATO_DB.Trivial_DB.VERSION, CONTRATO_DB.Trivial_DB.IDIOMA,CONTRATO_DB.Trivial_DB.DESCRIPCION);
                String tablaReglas = String.Format("Create table if not exists {0} ({1} Integer Primary Key,{2} Nvarchar(2048))",
                                            CONTRATO_DB.Regla_DB.TABLE_NAME, CONTRATO_DB.Regla_DB.ID, CONTRATO_DB.Regla_DB.TITULO);
                String tablaPreguntas = String.Format("Create table if not exists {0} ({1} Integer Primary Key,{2} Integer,{3} Nvarchar(2048),{4} Nvarchar(2048))",
                                            CONTRATO_DB.Pregunta_DB.TABLE_NAME, CONTRATO_DB.Pregunta_DB.ID, CONTRATO_DB.Pregunta_DB.REGLA_ID, CONTRATO_DB.Pregunta_DB.CONTENIDO,CONTRATO_DB.Pregunta_DB.ANOTACION);
                String tablaRespuestas = String.Format("Create table if not exists {0} ({1} Integer Primary Key,{2} Integer,{3} Nvarchar(2048),{4} Nvarchar(10))",
                                            CONTRATO_DB.Respuesta_DB.TABLE_NAME, CONTRATO_DB.Respuesta_DB.ID, CONTRATO_DB.Respuesta_DB.PREGUNTA_ID, CONTRATO_DB.Respuesta_DB.CONTENIDO, CONTRATO_DB.Respuesta_DB.CORRECTA);
                
                SqliteCommand createTableTrivials = new SqliteCommand(tablaTrivials, db);
                SqliteCommand createTableReglas = new SqliteCommand(tablaReglas, db);
                SqliteCommand createTablePreguntas= new SqliteCommand(tablaPreguntas, db);
                SqliteCommand createTableRespuestas = new SqliteCommand(tablaRespuestas, db);
                try
                {
                    createTableTrivials.ExecuteReader();
                    createTableReglas.ExecuteReader();
                    createTablePreguntas.ExecuteReader();
                    createTableRespuestas.ExecuteReader();
                }
                catch (SqliteException e)
                {
                    //Do nothing
                }
            }
        }

        public int getVersionTrivial()
        {
            int version = 0;
            using (db = new SqliteConnection(PATH_DB))
            {
                db.Open();
                String consulta = String.Format("Select {0} From {1}",CONTRATO_DB.Trivial_DB.VERSION,CONTRATO_DB.Trivial_DB.TABLE_NAME);

                SqliteCommand comand = new SqliteCommand(consulta, db);
                try
                {
                    SqliteDataReader lector = comand.ExecuteReader();

                    if (lector.HasRows)
                    {
                        lector.Read();
                        version = int.Parse(lector[CONTRATO_DB.Trivial_DB.VERSION].ToString());
                    }
                }
                catch (SqliteException e)
                {

                    throw;
                }
            }
            return version;
        }

        public void grabarTrivial(Trivial trivial)
        {
            using(db = new SqliteConnection(PATH_DB))
            {
                db.Open();

                 miTransaccion= db.BeginTransaction();
                try
                {
                    insertarTrivial(trivial, db);

                    List<Regla> reglas = trivial.Reglas;
                    for (int i = 0; i < reglas.Count; i++)
                    {
                        Regla regla = reglas[i];
                        insertarRegla(regla, db);

                        for (int j = 0; j < regla.Preguntas.Count; j++)
                        {
                            Pregunta pregunta = regla.Preguntas[j];
                            insertarPregunta(pregunta, db);
                        
                              List<Respuesta> respuestas = pregunta.Respuestas;
                              for (int k = 0; k < respuestas.Count; k++)
                              {
                                  Respuesta respuesta = respuestas[k];
                                  insertarRespuesta(respuesta,db);
                              }
                        }
                    }

                    miTransaccion.Commit();
                }
                catch (Exception)
                {
                    miTransaccion.Rollback();
                    throw;
                }
               
               
            }
                 
        }

        public  void insertarRespuesta(Respuesta respuesta,SqliteConnection db)
        {
            String cadenainsert = String.Format("Insert into {0}({1},{2},{3},{4}) Values ({5},{6},'{7}','{8}')",
                                    CONTRATO_DB.Respuesta_DB.TABLE_NAME,
                                    CONTRATO_DB.Respuesta_DB.ID,
                                    CONTRATO_DB.Respuesta_DB.PREGUNTA_ID,
                                    CONTRATO_DB.Respuesta_DB.CONTENIDO,
                                    CONTRATO_DB.Respuesta_DB.CORRECTA,
                                    respuesta.Id,
                                    respuesta.Pregunta_id,
                                    respuesta.Contenido,
                                    respuesta.Correcta);

          //  using (db = new SqliteConnection(PATH_DB))
           // {
              //  db.Open();

                SqliteCommand insertRespuestaCommand = new SqliteCommand(cadenainsert, db,miTransaccion);

                try
                {
                    insertRespuestaCommand.ExecuteNonQuery();
                }
                catch (SqliteException e)
                {
                    //Do nothing
                }
          //  }
        }

        public void insertarPregunta(Pregunta pregunta, SqliteConnection db)
        {
            String cadenainsert = String.Format("Insert into {0}({1},{2},{3},{4}) Values ({5},{6},'{7}','{8}')",
                                    CONTRATO_DB.Pregunta_DB.TABLE_NAME,
                                    CONTRATO_DB.Pregunta_DB.ID,
                                    CONTRATO_DB.Pregunta_DB.REGLA_ID,
                                    CONTRATO_DB.Pregunta_DB.CONTENIDO,
                                    CONTRATO_DB.Pregunta_DB.ANOTACION,
                                    pregunta.Id,
                                    pregunta.Regla_id,
                                    pregunta.Contenido,
                                    pregunta.Anotacion);

           // using (db = new SqliteConnection(PATH_DB))
           // {
             //   db.Open();
                SqliteCommand insertPreguntaCommand = new SqliteCommand(cadenainsert, db,miTransaccion);

                try
                {
                    insertPreguntaCommand.ExecuteNonQuery();
                }
                catch (SqliteException e)
                {
                    //Do nothing
                }
         //   }

        }

        public void insertarRegla(Regla regla, SqliteConnection db)
        {
            String cadenainsert = String.Format("Insert into {0} ({1},{2}) Values ({3},'{4}')",
                                    CONTRATO_DB.Regla_DB.TABLE_NAME,
                                    CONTRATO_DB.Regla_DB.ID,
                                    CONTRATO_DB.Regla_DB.TITULO,
                                    regla.Id,
                                    regla.Titulo);

         //   using (db = new SqliteConnection(PATH_DB))
         //   {
          //      db.Open();
                SqliteCommand insertReglaCommand = new SqliteCommand(cadenainsert, db,miTransaccion);

                try
                {
                    insertReglaCommand.ExecuteNonQuery();
                }
                catch (SqliteException e)
                {
                    
                }
          //  }
        }

        public void insertarTrivial(Trivial trivial, SqliteConnection db)
        {
            String cadenainsert = String.Format("Insert into {0} ({1},{2},{3},{4}) Values ({5},'{6}','{7}','{8}')",
                                    CONTRATO_DB.Trivial_DB.TABLE_NAME,
                                    CONTRATO_DB.Trivial_DB.ID,
                                    CONTRATO_DB.Trivial_DB.IDIOMA,
                                    CONTRATO_DB.Trivial_DB.VERSION,
                                    CONTRATO_DB.Trivial_DB.DESCRIPCION,
                                    trivial.Id,
                                    trivial.Idioma,
                                    trivial.Version,
                                    trivial.Descripcion);

          //  using (db = new SqliteConnection(PATH_DB))
          //  {
           //     db.Open();
                SqliteCommand insertTrivialCommand = new SqliteCommand(cadenainsert, db,miTransaccion);

                try
                {
                    insertTrivialCommand.ExecuteNonQuery();
                }
                catch (SqliteException e)
                {
                    throw e;
                }
            }
       
        public bool isDataExists()
        {
            bool existe = false;

            using (db = new SqliteConnection(PATH_DB))
            {
                db.Open();
                String cadena = "Select * from Trivials";

                SqliteCommand comand = new SqliteCommand(cadena, db);

                try
                {
                   SqliteDataReader reader = comand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        existe = true;
                    }

                }
                catch (SqliteException e)
                {
                    existe = false;
                }
            }

                return existe;
        }


    }
}
