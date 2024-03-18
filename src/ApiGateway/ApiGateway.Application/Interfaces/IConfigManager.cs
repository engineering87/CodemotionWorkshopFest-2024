namespace ApiGateway.Application.Interfaces
{
    public interface IConfigManager
    {
        string BeneficiarioBaseUri { get; }
        string CountPraticheOrdinariePath { get; }
        string CountPraticheStraordinariePath { get; }
        string GetAllBeneficiariPath { get; }
        string GetAllPraticheOrdinariePath { get; }
        string GetAllPraticheStraordinariePath { get; }
        string GetBeneficiarioByIdPath { get; }
        string GetPraticaOrdinariaByIdPath { get; }
        string GetPraticaStraordinariaByIdPath { get; }
        string GetPraticheOrdinarieByBeneficiarioIdPath { get; }
        string GetPraticheStraordinarieByBeneficiarioIdPath { get; }
        string PraticaOrdinariaBaseUri { get; }
        string PraticaStraordinariaBaseUri { get; }
    }
}