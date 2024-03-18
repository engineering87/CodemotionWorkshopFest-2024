using Codemotion_DashboardLegacy.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Clients
{
    /// <summary>
    /// Classe di base per l'interazione con servizi web tramite richieste HTTP.
    /// </summary>
    public class BaseClient
    {
        // Un'istanza singleton di HttpClient, inizializzata solo al primo utilizzo.
        private static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() =>
        {
            return new HttpClient();
        });

        // Proprietà per l'accesso all'istanza condivisa di HttpClient.
        protected HttpClient Client => _httpClient.Value;

        /// <summary>
        /// Esegue una richiesta HTTP GET e deserializza il contenuto della risposta nel tipo specificato.
        /// </summary>
        /// <typeparam name="T">Il tipo di oggetto da deserializzare.</typeparam>
        /// <param name="uri">L'URI del servizio da richiamare.</param>
        /// <returns>L'oggetto deserializzato risultante dalla richiesta.</returns>
        public async Task<T> DoGet<T>(Uri uri)
        {
            // Esegue la richiesta GET al servizio specificato.
            using (var response = await Client.GetAsync(uri))
            {
                // Assicura che la risposta abbia avuto successo.
                response.EnsureSuccessStatusCode();

                // Legge il contenuto della risposta come stringa.
                var content = await response.Content.ReadAsStringAsync();

                // Deserializza il contenuto della risposta nel tipo specificato.
                var result = ApiHelper.Deserialize<T>(content);

                return result;
            }
        }
    }

}