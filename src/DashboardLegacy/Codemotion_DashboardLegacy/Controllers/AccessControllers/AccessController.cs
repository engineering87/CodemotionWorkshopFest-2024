namespace Codemotion_DashboardLegacy.Controllers.Base
{
    /// <summary>
    /// Adapter (wrapper) pattern        
    /// Il fine dell'adapter è di fornire una soluzione astratta al problema dell'interoperabilità 
    /// tra interfacce differenti. Il problema si presenta ogni qual volta nel progetto di un software
    /// si debbano utilizzare sistemi di supporto (come per esempio librerie) la cui interfaccia 
    /// non è perfettamente compatibile con quanto richiesto da applicazioni già esistenti.
    /// </summary>
    public class AccessController : DbAccessController
    {
        /// <summary>
        /// Tutti i Controller dell'applicazione ereditano da questa classe.
        /// Cambiare il Base Controller per modificare la modalità di accesso al dato.
        /// Base Controller possibili:
        /// - DbAccessController: I dati vengono recuperati dal Database Legacy.
        /// - ApiAccessController: I dati vengono recuperati mediante chiamate HTTP verso
        ///   i microservizi PraticaOrdinaria, PraticaStraordinaria e Beneficiario.
        /// - ApiGatewayAccessController: I dati vengono recuperati mediante chiamate HTTP verso
        ///   il microservizio di aggregazione ApiGateway
        /// </summary>
    }
}