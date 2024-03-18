using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Features.ViewModels
{
    public class TipoPagamentoViewModel
    {
        public int Id { get; set; }
        public string Descrizione { get; set; } = string.Empty;
    }
}
