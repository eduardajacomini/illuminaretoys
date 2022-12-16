using System.Text.RegularExpressions;

namespace IlluminareToys.Domain.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static bool IsNullOrWhiteSpace(this string input)
            => string.IsNullOrWhiteSpace(input);

        public static string RemoveSpaces(this string input)
            => input.Trim().TrimStart().TrimEnd();

        public static string ToMoney(this string input)
            => Convert.ToDecimal(input).ToString("C");
    }
}
