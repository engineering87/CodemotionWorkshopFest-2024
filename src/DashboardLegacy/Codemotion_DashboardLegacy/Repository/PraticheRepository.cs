using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Codemotion_DashboardLegacy.Models;
using Codemotion_DashboardLegacy.Enums;
using Codemotion_DashboardLegacy.Data.ViewModels;
using System.Threading.Tasks;
using Codemotion_DashboardLegacy.Helpers;

namespace Codemotion_DashboardLegacy.Repository
{
    public class PraticheRepository : IPraticheRepository
    {
        private readonly string _connectionString;

        public PraticheRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PraticheLegacyDB"].ConnectionString;
        }

        public async Task<ContatoriPratiche> GetContatoriPratiche()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Pratiche WHERE P_TYPE = 1) AS ContatorePraticheOrdinarie,
                        (SELECT COUNT(*) FROM Pratiche WHERE P_TYPE = 2) AS ContatorePraticheStraordinarie";

                var result = await db.QueryFirstOrDefaultAsync<ContatoriPratiche>(query);

                return result;
            }
        }

        public async Task<IEnumerable<PraticaOrdinariaViewModel>> GetPraticheOrdinarie(string input)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var (query, parameters) = RepositoryHelper.BuildQueryWithParameters(TipoPraticaEnum.Ordinaria, input);

                var result = await db.QueryAsync<Pratica, TipoPratica, TipoPagamento, Causali, Pratica>(
                    sql: query,
                    map: (pratica, tipo, pagamento, _) =>
                    {
                        pratica.Tipo = tipo;
                        pratica.Pagamento = pagamento;
                        return pratica;
                    },
                    param: parameters,
                    splitOn: "TipoId, PagamentoId, CausaleId"
                );

                return RepositoryHelper.MapPraticheOrdinarieToViewModel(result);
            }
        }

        public async Task<IEnumerable<PraticaStraordinariaViewModel>> GetPraticheStraordinarie(string input)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var (query, parameters) = RepositoryHelper.BuildQueryWithParameters(TipoPraticaEnum.Straordinaria, input);

                var result = await db.QueryAsync<Pratica, TipoPratica, TipoPagamento, Causali, Pratica>(
                    sql: query,
                    map: (pratica, tipo, _, causale) =>
                    {
                        pratica.Tipo = tipo;
                        pratica.Causale = causale;
                        return pratica;
                    },
                    param: parameters,
                    splitOn: "TipoId, PagamentoId, CausaleId"
                );

                return RepositoryHelper.MapPraticheStraordinarieToViewModel(result);
            }
        }

        public async Task<IEnumerable<PraticaViewModel>> GetPraticheByBeneficiarioId(Guid beneficiarioId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var (query, parameters) = RepositoryHelper.BuildQueryWithParameters(beneficiarioId);

                var result = await db.QueryAsync<Pratica, TipoPratica, Pratica>(
                    sql: query,
                    map: (pratica, tipo) =>
                    {
                        pratica.Tipo = tipo;
                        return pratica;
                    },
                    param: parameters,
                    splitOn: "TipoId"
                );

                return RepositoryHelper.MapPraticheToViewModel(result);
            }
        }
    }
}