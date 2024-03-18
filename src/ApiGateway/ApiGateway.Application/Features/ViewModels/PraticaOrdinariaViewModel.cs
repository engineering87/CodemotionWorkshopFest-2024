using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Features.ViewModels
{
    public class PraticaOrdinariaViewModel : PraticaViewModel
    {
        public TipoPagamentoViewModel Pagamento { get; set; }
    }
}
