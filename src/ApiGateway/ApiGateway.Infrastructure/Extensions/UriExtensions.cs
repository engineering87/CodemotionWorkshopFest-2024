using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiGateway.Infrastructure.Api.Extensions
{
    public static class UriExtensions
    {
        public static Uri Append(this Uri uri, string path)
        {
            ArgumentNullException.ThrowIfNull(uri);

            string uriString = uri.ToString().TrimEnd('/');
            string pathString = path.TrimStart('/');

            return new Uri($"{uriString}/{pathString}", UriKind.Absolute);
        }

        public static Uri AddQueryParam(this Uri uri, string key, object? value)
        {
            var builder = new UriBuilder(uri);

            if (value is not null and not "" && value is not null)
            {
                var query = HttpUtility.ParseQueryString(builder.Query);
                query[key] = value.ToString();
                builder.Query = query.ToString();
            }

            return builder.Uri;
        }
    }
}
