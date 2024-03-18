using Codemotion_DashboardLegacy.Managers;
using System.Web.Mvc;

namespace Codemotion_DashboardLegacy.Controllers.Base
{
    /// <summary>
    /// I dati vengono recuperati mediante chiamate HTTP verso i microservizi PraticaOrdinaria, PraticaStraordinaria e Beneficiario.
    /// </summary>
    public class ApiAccessController : Controller
    {
        protected IDataManager DataManager = new ApiDataManager();
    }
}