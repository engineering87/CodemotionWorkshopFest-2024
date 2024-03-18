using Beneficiari.Domain.Common;

namespace Beneficiari.Domain.Entities
{
    public class Beneficiario : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Cellulare { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
