using ApiGateway.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ApiGateway.Application.Configuration
{
    public class ConfigManager(IConfiguration config) : IConfigManager
    {
        public string PraticaOrdinariaBaseUri { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaOrdinariaApi")?
                .GetValue<string>("BaseUri") ?? throw new Exception("La configurazione non è corretta");

        public string GetAllPraticheOrdinariePath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaOrdinariaApi")?
                .GetValue<string>("GetAllPraticheOrdinariePath") ?? throw new Exception("La configurazione non è corretta");

        public string GetPraticheOrdinarieByBeneficiarioIdPath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaOrdinariaApi")?
                .GetValue<string>("GetPraticheOrdinarieByBeneficiarioIdPath") ?? throw new Exception("La configurazione non è corretta");

        public string GetPraticaOrdinariaByIdPath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaOrdinariaApi")?
                .GetValue<string>("GetPraticaOrdinariaByIdPath") ?? throw new Exception("La configurazione non è corretta");

        public string CountPraticheOrdinariePath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaOrdinariaApi")?
                .GetValue<string>("CountPraticheOrdinariePath") ?? throw new Exception("La configurazione non è corretta");

        // ------------------------------------------------------- //

        public string PraticaStraordinariaBaseUri { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaStraordinariaApi")?
                .GetValue<string>("BaseUri") ?? throw new Exception("La configurazione non è corretta");

        public string GetAllPraticheStraordinariePath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaStraordinariaApi")?
                .GetValue<string>("GetAllPraticheStraordinariePath") ?? throw new Exception("La configurazione non è corretta");

        public string GetPraticheStraordinarieByBeneficiarioIdPath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaStraordinariaApi")?
                .GetValue<string>("GetPraticheStraordinarieByBeneficiarioIdPath") ?? throw new Exception("La configurazione non è corretta");

        public string GetPraticaStraordinariaByIdPath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaStraordinariaApi")?
                .GetValue<string>("GetPraticaStraordinariaByIdPath") ?? throw new Exception("La configurazione non è corretta");

        public string CountPraticheStraordinariePath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("PraticaStraordinariaApi")?
                .GetValue<string>("CountPraticheStraordinariePath") ?? throw new Exception("La configurazione non è corretta");

        // ------------------------------------------------------- //

        public string BeneficiarioBaseUri { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("BeneficiarioApi")?
                .GetValue<string>("BaseUri") ?? throw new Exception("La configurazione non è corretta");

        public string GetAllBeneficiariPath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("BeneficiarioApi")?
                .GetValue<string>("GetAllBeneficiariPath") ?? throw new Exception("La configurazione non è corretta");

        public string GetBeneficiarioByIdPath { get; } = config?
                .GetSection("ApiConfiguration")?
                .GetSection("BeneficiarioApi")?
                .GetValue<string>("GetBeneficiarioByIdPath") ?? throw new Exception("La configurazione non è corretta");


    }
}
