using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codemotion_DashboardLegacy.Extensions
{
    public static class UriExtensions
    {
        public static Uri Append(this Uri uri, string path)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            string uriString = uri.ToString().TrimEnd('/');
            string pathString = path.TrimStart('/');

            return new Uri($"{uriString}/{pathString}", UriKind.Absolute);
        }

        public static Uri AddQueryParam(this Uri uri, string key, object value)
        {
            var builder = new UriBuilder(uri);

            if (value != null)
            {
                var query = HttpUtility.ParseQueryString(builder.Query);
                query[key] = value.ToString();
                builder.Query = query.ToString();
            }

            return builder.Uri;
        }
    }
}