using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codemotion_DashboardLegacy.Models
{
    public class Beneficiario
    {
        public Guid Id {  get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
    }
}