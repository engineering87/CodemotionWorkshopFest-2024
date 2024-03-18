namespace PraticaOrdinaria.Application.Features.PraticaOrdinaria.ViewModels
{
    public class PraticaOrdinariaViewModel
    {
        public Guid Id { get; set; }
        public string Protocollo { get; set; } = string.Empty;
        public Guid IdBeneficiario { get; set; }
        public DateTime DataInserimento { get; set; }
        public TipoPagamentoViewModel Pagamento { get; set; }
        public TipoPraticaViewModel Tipo { get; set; } = new TipoPraticaViewModel()
        {
            Id = 1,
            Descrizione = "Ordinaria"
        };
    }
}
