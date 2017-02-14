using Futbol_Test.DAL.ApiRest;
using Futbol_Test.DAL.SQLite;
using Futbol_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Futbol_Test.Utilities
{
    public class MainUtilities
    {
        Trivial trivial;
        bool hayInternet;
        ClienteApi clienteApi;
        private SQLiteManejadora manejadora;
        private Action miAccion;

        public MainUtilities(Action accion)
        {
            miAccion = accion;
        }

        public async Task descargarYGrabarTrivial()
        {
            SQLiteManejadora manejadoraSqlite = new SQLiteManejadora();

            trivial = await descargarTrivial();

            manejadoraSqlite.grabarTrivial(trivial);

        }

        public async Task<Trivial> descargarTrivial()
        {
            clienteApi = new ClienteApi();
            return await clienteApi.getTrivial();
        }

        public async void checkActualizacion()
        {
            bool hayNuevaActualizacion = false;
            clienteApi = new ClienteApi();
            manejadora = new SQLiteManejadora();

            int versionTrivialLocal = manejadora.getVersionTrivial();
            int versionTrivialInternet = await obtenerVersionTrivialInternet();
            if (versionTrivialInternet > versionTrivialLocal)
            {
                hayNuevaActualizacion = true;
            }

            manejadora = new SQLiteManejadora();
            hayInternet = NetworkInterface.GetIsNetworkAvailable();
            //Si Hay Internet
            if (hayInternet && (!manejadora.isDataExists() || hayNuevaActualizacion))
            {
                //descargar y grabar trivial
                await descargarYGrabarTrivial();

                //Si no Hay internet
            }
            else
            {
                //si no existen datos
                if (manejadora.isDataExists() == false)
                {
                    //Ir a Error (Se necesita internet para descargar la base de datos la 1ªvez)
                    //Fin_Si
                }
                //Fin - Sino
            }

            miAccion.Invoke();

        }

        public async Task<int> obtenerVersionTrivialInternet()
        {
            int versionTrivialInternet = await clienteApi.getVersiontrivial();
            return versionTrivialInternet;
        }
        
    }
}
