using Codemotion_DashboardLegacy.Data.API;
using Codemotion_DashboardLegacy.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.UI.WebControls;

namespace Codemotion_DashboardLegacy.Helpers
{
    public class ApiHelper
    {
        public static T Deserialize<T>(string json)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}