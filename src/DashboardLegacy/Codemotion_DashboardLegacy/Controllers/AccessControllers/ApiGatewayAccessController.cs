using Codemotion_DashboardLegacy.Managers;
using System.Web.Mvc;

namespace Codemotion_DashboardLegacy.Controllers.Base
{
    /// <summary>
    /// I dati vengono recuperati mediante chiamata HTTP verso il microservizio di aggregazione ApiGateway
    /// </summary>
    public class ApiGatewayAccessController : Controller
    {
        protected IDataManager DataManager = new ApiGatewayDataManager();
    }
}