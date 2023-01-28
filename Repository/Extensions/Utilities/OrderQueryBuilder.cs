using System.Reflection;
using System.Text;

namespace Repository.Extensions.Utilities
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderQueryString)
        {
            var orderQueryParams = orderQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();
            foreach(var param in orderQueryParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyNameFromQueryParam = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyNameFromQueryParam, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
