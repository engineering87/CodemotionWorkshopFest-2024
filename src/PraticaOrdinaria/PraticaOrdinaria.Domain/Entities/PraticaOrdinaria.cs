using PraticaOrdinaria.Domain.Common;

namespace PraticaOrdinaria.Domain.Entities
{
    public class PraticaOrdinaria : BaseEntity
    {
        public string Protocollo { get; set; } = string.Empty;
        public DateTime DataInserimento { get; set; }
        public int TipoPagamento { get; set; }
        public TipoPagamento Pagamento { get; set; }
        public Guid IdBeneficiario { get; set; }
    }
}
