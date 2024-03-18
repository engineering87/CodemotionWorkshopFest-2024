using Codemotion_DashboardLegacy.Enums;
using Codemotion_DashboardLegacy.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Codemotion_DashboardLegacy.Data.ViewModels
{
    public class PraticaOrdinariaViewModel : PraticaViewModel
    {
        public TipoPagamentoViewModel Pagamento { get; set; }
    }
}