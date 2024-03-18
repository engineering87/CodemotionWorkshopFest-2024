using PraticaStraordinaria.Domain.Common;

namespace PraticaStraordinaria.Domain.Entities
{
    public class PraticaStraordinaria : BaseEntity
    {
        public string Protocollo { get; set; } = string.Empty;
        public DateTime DataInserimento { get; set; }
        public int IdCausale { get; set; }
        public Causale Causale { get; set; }
        public Guid IdBeneficiario { get; set; }
    }
}
