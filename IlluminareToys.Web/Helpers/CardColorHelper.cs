using IlluminareToys.Domain.Shared.Extensions;

namespace IlluminareToys.Web.Helpers
{
    public static class CardColorHelper
    {
        public static string PrimaryClass = "button-menu-bg-primary";
        public static string SecondaryClass = "button-menu-bg-secondary";
        public static string TertiaryClass = "button-menu-bg-tertiary";

        public static string GetCurrentClass(string prevClass, string currentClass)
        {
            if (currentClass.IsNullOrWhiteSpace() && prevClass.IsNullOrWhiteSpace())
            {
                return PrimaryClass;
            }
            else if (currentClass.Equals(PrimaryClass))
            {
                return SecondaryClass;
            }
            else if (currentClass.Equals(SecondaryClass))
            {
                return TertiaryClass;
            }

            return PrimaryClass;
        }
    }
}
