using Domain.Constants;
using System.Net;

namespace Services.Helpers
{
    public static class QueryStringHelper
    {
        public static Uri AppendQueryString(string path, Dictionary<string, object> parameter)
        {
            return CreateUrl(path, parameter);
        }

        public static Uri AppendQueryString(string path)
        {
            return CreateUrl(path, new Dictionary<string, object>());
        }

        private static Uri CreateUrl(string path, Dictionary<string, object> parameter)
        {
            var urlParameters = new List<string>();
            foreach (var par in parameter)
            {
                urlParameters.Add(par.Value == null || string.IsNullOrWhiteSpace(par.Value.ToString())
                    ? null
                    : $"{par.Key}={par.Value.ToString().ToLower()}");
            }

            var encodedParams = urlParameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(WebUtility.HtmlEncode)
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                .ToArray();
            var url = encodedParams.Length > 0 ? $"{path}{string.Join(string.Empty, encodedParams)}" : path;
            return new Uri(CoinGecoAPIEndPoints.ApiEndPoint, url);
        }
    }
}
