using Codemotion_DashboardLegacy.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using Codemotion_DashboardLegacy.Data.ViewModels;
using Codemotion_DashboardLegacy.Helpers;

namespace Codemotion_DashboardLegacy.Repository
{
    public class BeneficiariRepository : IBeneficiariRepository
    {
        private readonly string _connectionString;

        public BeneficiariRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PraticheLegacyDB"].ConnectionString;
        }

        public async Task<IEnumerable<BeneficiarioViewModel>> GetBeneficiari(string input)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var (query, parameters) = RepositoryHelper.BuildQueryWithParameters(input);

                var result = await db.QueryAsync<Beneficiario>(
                    sql: query,
                    param: parameters
                );

                return RepositoryHelper.MapBeneficiariToViewModel(result);
            }
        }
    }
}