using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Futbol_Test.DAL.ApiRest
{
    public class MiHttpClient
    {
        public HttpClient miHttpClient { get; set; }
        public HttpBaseProtocolFilter filtro;

        public MiHttpClient()
        {
            filtro = new HttpBaseProtocolFilter();
            filtro.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
            filtro.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;
            miHttpClient = new HttpClient(filtro);
        }
    }
}
