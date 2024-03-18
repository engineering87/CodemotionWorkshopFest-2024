using Codemotion_DashboardLegacy.Enums;
using Codemotion_DashboardLegacy.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codemotion_DashboardLegacy.Data.ViewModels
{
    public class PraticaStraordinariaViewModel : PraticaViewModel
    {
        public CausaleViewModel Causale { get; set; }
    }
}