using Codemotion_DashboardLegacy.Controllers.Base;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Codemotion_DashboardLegacy.Controllers
{
    public class PraticheController : AccessController
    {
        public async Task<ActionResult> PraticheOrdinarie(string searchInput)
        {
            var result = await DataManager.GetPraticheOrdinarie(searchInput?.Trim());

            return View(result);
        }

        public async Task<ActionResult> PraticheStraordinarie(string searchInput)
        {
            var result = await DataManager.GetPraticheStraordinarie(searchInput?.Trim());

            return View(result);
        }

        public async Task<PartialViewResult> PraticheByBeneficiarioId(Guid beneficiarioId)
        {
            var result = await DataManager.GetPraticheByBeneficiarioId(beneficiarioId);

            return PartialView("_PraticheModal", result);
        }
    }
}