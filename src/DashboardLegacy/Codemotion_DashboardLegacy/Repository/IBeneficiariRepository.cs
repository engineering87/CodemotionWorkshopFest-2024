using Codemotion_DashboardLegacy.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codemotion_DashboardLegacy.Repository
{
    public interface IBeneficiariRepository
    {
        Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string input);
    }
}