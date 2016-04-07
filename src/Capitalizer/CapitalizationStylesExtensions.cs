namespace Capitalizer
{
    public static class CapitalizationStyleExtensions
    {
        public static ICamelCaseConverter FromCamelCase(this string text, Prefix prefix = Prefix.None)
        {
            return new CapitalizationConverter(text, CapitalizationStyles.Camel, prefix);
        }

        public static IPascalCaseConverter FromPascalCase(this string text, Prefix prefix = Prefix.None)
        {
            return new CapitalizationConverter(text, CapitalizationStyles.Pascal, prefix);
        }

        public static ITextCaseConverter FromText(this string text, string separator = null)
        {
            return new CapitalizationConverter(text, CapitalizationStyles.Text, Prefix.None, separator);
        }
    }
}
