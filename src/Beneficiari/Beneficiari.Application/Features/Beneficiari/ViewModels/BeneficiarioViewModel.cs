namespace Beneficiari.Application.Features.Beneficiari.ViewModels
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
