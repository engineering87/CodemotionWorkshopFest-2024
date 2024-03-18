using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Features.ViewModels
{
    public class PraticaStraordinariaViewModel : PraticaViewModel
    {
        public CausaleViewModel Causale { get; set; }
    }
}
