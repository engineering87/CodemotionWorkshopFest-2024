using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Features.ViewModels
{
    public class BeneficiarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Cellulare { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
