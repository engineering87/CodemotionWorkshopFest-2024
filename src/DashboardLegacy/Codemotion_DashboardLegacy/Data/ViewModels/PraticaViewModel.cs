using Codemotion_DashboardLegacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codemotion_DashboardLegacy.Data.ViewModels
{
    public class PraticaViewModel
    {
        public Guid Id { get; set; }
        public string Protocollo { get; set; }
        public Guid IdBeneficiario { get; set; }
        public DateTime DataInserimento { get; set; }
        public TipoPraticaViewModel Tipo { get; set; }
    }
}