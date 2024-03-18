using Codemotion_DashboardLegacy.Managers;
using System.Web.Mvc;

namespace Codemotion_DashboardLegacy.Controllers.Base
{
    /// <summary>
    /// I dati vengono letti con accesso diretto al Database Legacy.
    /// </summary>
    public class DbAccessController : Controller
    {
        protected IDataManager DataManager = new DbDataManager();
    }
}