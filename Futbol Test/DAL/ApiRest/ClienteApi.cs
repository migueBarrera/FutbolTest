using Futbol_Test.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Futbol_Test.DAL.ApiRest
{
    class ClienteApi
    {
        private MiHttpClient httpClient;
        private String uriTivial = "https://referee.mbarrera.ciclo.iesnervion.es/trivial/regla";
        private String uriTrivialVersion ="https://referee.mbarrera.ciclo.iesnervion.es/trivial";
        public async Task<Trivial> getTrivial()
        {
            Trivial trivial;
            httpClient = new MiHttpClient();
            Uri myUri = new Uri(uriTivial);
            try
            {
                String respuesta = await httpClient.miHttpClient.GetStringAsync(myUri);
                httpClient.miHttpClient.Dispose();
                trivial = JsonConvert.DeserializeObject<Trivial>(respuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (trivial);
        }

        public async Task<int> getVersiontrivial()
        {
            Trivial trivial;
            int version = 0;
            httpClient = new MiHttpClient();
            Uri myUri = new Uri(uriTrivialVersion);
            try
            {
                String respuesta = await httpClient.miHttpClient.GetStringAsync(myUri);
                httpClient.miHttpClient.Dispose();
                trivial = JsonConvert.DeserializeObject<Trivial>(respuesta);
                version = int.Parse(trivial.Version);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return (version);
        }
    }
}
