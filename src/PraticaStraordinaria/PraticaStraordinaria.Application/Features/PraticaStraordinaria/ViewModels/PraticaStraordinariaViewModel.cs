namespace PraticaStraordinaria.Application.Features.PraticaStraordinaria.ViewModels
{
    public class PraticaStraordinariaViewModel
    {
        public Guid Id { get; set; }
        public string Protocollo { get; set; } = string.Empty;
        public Guid IdBeneficiario { get; set; }
        public DateTime DataInserimento { get; set; }
        public CausaleViewModel Causale { get; set; }
        public TipoPraticaViewModel Tipo { get; set; } = new TipoPraticaViewModel() 
        { 
            Id = 2, 
            Descrizione = "Straordinaria" 
        };
    }
}
