using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codemotion_DashboardLegacy.Models
{
    public class Pratica
    {
        public Guid Id { get; set; }
        public string Protocollo { get; set; }
        public Guid IdBeneficiario { get; set; }
        public DateTime DataInserimento { get; set; }
        public TipoPratica Tipo { get; set; }
        public TipoPagamento Pagamento { get; set; }
        public Causali Causale { get; set; }
    }
}