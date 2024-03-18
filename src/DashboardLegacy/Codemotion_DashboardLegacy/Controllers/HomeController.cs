using Codemotion_DashboardLegacy.Controllers.Base;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Codemotion_DashboardLegacy.Controllers
{
    public class HomeController : AccessController
    {
        public async Task<ActionResult> Index()
        {
            var result = await DataManager.GetContatoriPratiche();

            return View(result);
        }
    }
}