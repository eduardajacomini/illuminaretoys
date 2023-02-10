using IlluminareToys.Domain.Outputs.Age;
using IlluminareToys.Domain.Outputs.Product;

namespace IlluminareToys.Application.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<GetProductGroupAgeOutput> ToOrderedByAge(this IEnumerable<GetProductGroupAgeOutput> list)
        {
            var byYear = list.Where(x => x.Age.Type is Domain.Enums.AgeType.YEARS);
            var byMonth = list.Where(x => x.Age.Type is Domain.Enums.AgeType.MONTHS);

            var orderedByYear = byYear.OrderBy(x => x.Age.Quantity);
            var orderedByMonth = byMonth.OrderBy(x => x.Age.Quantity);

            var finalList = new List<GetProductGroupAgeOutput>();

            finalList.AddRange(orderedByMonth);
            finalList.AddRange(orderedByYear);

            return finalList;
        }

        public static IEnumerable<GetAgeOutput> ToOrderedByAge(this IEnumerable<GetAgeOutput> list)
        {
            var byYear = list.Where(x => x.Type is Domain.Enums.AgeType.YEARS);
            var byMonth = list.Where(x => x.Type is Domain.Enums.AgeType.MONTHS);

            var orderedByYear = byYear.OrderBy(x => x.Quantity);
            var orderedByMonth = byMonth.OrderBy(x => x.Quantity);

            var finalList = new List<GetAgeOutput>();

            finalList.AddRange(orderedByMonth);
            finalList.AddRange(orderedByYear);

            return finalList;
        }
    }
}
