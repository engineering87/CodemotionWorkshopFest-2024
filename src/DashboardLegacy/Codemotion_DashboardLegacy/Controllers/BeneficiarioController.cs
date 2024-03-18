using Codemotion_DashboardLegacy.Controllers.Base;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Codemotion_DashboardLegacy.Controllers
{
    public class BeneficiarioController : AccessController
    {
        public async Task<ActionResult> Beneficiari(string searchInput)
        {
            var result = await DataManager.GetBeneficiari(searchInput?.Trim());

            return View(result);
        }
    }
}