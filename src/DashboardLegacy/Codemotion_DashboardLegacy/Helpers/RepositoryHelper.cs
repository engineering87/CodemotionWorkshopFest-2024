using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Enums;
using Codemotion_DashboardLegacy.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codemotion_DashboardLegacy.Helpers
{
    public class RepositoryHelper
    {
        public static IEnumerable<PraticaViewModel> MapPraticheToViewModel(IEnumerable<Pratica> pratiche)
        {
            var praticheMap = new List<PraticaViewModel>();

            foreach (var pratica in pratiche)
            {
                var praticaMap = new PraticaViewModel()
                {
                    Id = pratica.Id,
                    Protocollo = pratica.Protocollo,
                    IdBeneficiario = pratica.IdBeneficiario,
                    DataInserimento = pratica.DataInserimento,
                    Tipo = new TipoPraticaViewModel()
                    {
                        Id = pratica.Tipo.TipoId,
                        Descrizione = pratica.Tipo.TipoDescrizione
                    }
                };

                praticheMap.Add(praticaMap);
            }

            return praticheMap;
        }

        public static IEnumerable<PraticaOrdinariaViewModel> MapPraticheOrdinarieToViewModel(IEnumerable<Pratica> pratiche)
        {
            var praticheMap = new List<PraticaOrdinariaViewModel>();

            foreach (var pratica in pratiche)
            {
                var praticaMap = new PraticaOrdinariaViewModel()
                {
                    Id = pratica.Id,
                    Protocollo = pratica.Protocollo,
                    IdBeneficiario = pratica.IdBeneficiario,
                    DataInserimento = pratica.DataInserimento,
                    Tipo = new TipoPraticaViewModel()
                    {
                        Id = pratica.Tipo.TipoId,
                        Descrizione = pratica.Tipo.TipoDescrizione
                    },
                    Pagamento = new TipoPagamentoViewModel()
                    {
                        Id = pratica.Pagamento.PagamentoId,
                        Descrizione = pratica.Pagamento.PagamentoDescrizione
                    }
                };

                praticheMap.Add(praticaMap);
            }

            return praticheMap;
        }

        public static IEnumerable<PraticaStraordinariaViewModel> MapPraticheStraordinarieToViewModel(IEnumerable<Pratica> pratiche)
        {
            var praticheMap = new List<PraticaStraordinariaViewModel>();

            foreach (var pratica in pratiche)
            {
                var praticaMap = new PraticaStraordinariaViewModel()
                {
                    Id = pratica.Id,
                    Protocollo = pratica.Protocollo,
                    IdBeneficiario = pratica.IdBeneficiario,
                    DataInserimento = pratica.DataInserimento,
                    Tipo = new TipoPraticaViewModel()
                    {
                        Id = pratica.Tipo.TipoId,
                        Descrizione = pratica.Tipo.TipoDescrizione
                    },
                    Causale = new CausaleViewModel()
                    {
                        Id = pratica.Causale.CausaleId,
                        Descrizione = pratica.Causale.CausaleDescrizione
                    }
                };

                praticheMap.Add(praticaMap);
            }

            return praticheMap;
        }

        public static IEnumerable<BeneficiarioViewModel> MapBeneficiariToViewModel(IEnumerable<Beneficiario> beneficiari)
        {
            var beneficiariMap = new List<BeneficiarioViewModel>();

            foreach (var beneficiario in beneficiari)
            {
                var beneficiarioMap = new BeneficiarioViewModel()
                {
                    Id = beneficiario.Id,
                    Nome = beneficiario.Nome,
                    Cognome = beneficiario.Cognome,
                    Cellulare = beneficiario.Cellulare,
                    Email = beneficiario.Email
                };

                beneficiariMap.Add(beneficiarioMap);
            }

            return beneficiariMap;
        }

        public static (string, DynamicParameters) BuildQueryWithParameters(Guid beneficiarioId)
        {
            string query = @"
                    SELECT 
                        p.P_GUID AS Id, 
                        p.P_PTC as Protocollo, 
                        p.BEN_GUID as IdBeneficiario, 
                        p.P_DATAINS as DataInserimento, 
                        tp.ID as TipoId, 
                        tp.DESCRIPTION as TipoDescrizione
                    FROM Pratiche p 
                    INNER JOIN TipoPratica tp ON p.P_TYPE = tp.ID 
                    WHERE p.BEN_GUID = @BeneficiarioId";

            var parameters = new DynamicParameters();

            parameters.Add("BeneficiarioId", beneficiarioId);

            return (query, parameters);
        }

        public static (string, DynamicParameters) BuildQueryWithParameters(TipoPraticaEnum tipoPratica, string input)
        {
            string query = @"
                    SELECT 
                        p.P_GUID AS Id, 
                        p.P_PTC as Protocollo, 
                        p.BEN_GUID as IdBeneficiario, 
                        p.P_DATAINS as DataInserimento, 
                        tp.ID as TipoId, 
                        tp.DESCRIPTION as TipoDescrizione, 
                        tpag.ID as PagamentoId, 
                        tpag.DESCRIPTION as PagamentoDescrizione, 
                        c.ID as CausaleId, 
                        c.DESCRIPTION as CausaleDescrizione 
                    FROM Pratiche p 
                    INNER JOIN TipoPratica tp ON p.P_TYPE = tp.ID 
                    LEFT JOIN TipoPagamento tpag ON p.P_PAG_TYPE = tpag.ID 
                    LEFT JOIN Causali c ON p.P_CAU = c.ID 
                    WHERE tp.ID = @TipoPratica";

            var parameters = new DynamicParameters();

            parameters.Add("TipoPratica", (int)tipoPratica);

            if (input != null && input != string.Empty)
            {
                parameters.Add("Protocollo", $"%{input}%");
                parameters.Add("Guid", input);

                query += " AND (p.P_PTC LIKE @Protocollo OR p.P_GUID = @Guid)";
            }

            return (query, parameters);
        }

        public static (string, DynamicParameters) BuildQueryWithParameters(string input)
        {
            string query = @"
                    SELECT 
                        B_GUID as Id, 
                        B_NOME as Nome, 
                        B_COGNOME as Cognome, 
                        B_CELL as Cellulare,
                        B_EMAIL as Email
                    FROM Beneficiari";

            var parameters = new DynamicParameters();

            if (input != null && input != string.Empty)
            {
                parameters.Add("Cognome", $"%{input}%");
                parameters.Add("Email", $"%{input}%");

                query += " WHERE B_COGNOME LIKE @Cognome OR B_EMAIL LIKE @Email";
            }

            return (query, parameters);
        }
    }
}