namespace Capitalizer
{
    public static class CapitalizationStyleExtensions
    {
        public static ICamelCase FromCamelCase(this string text)
        {
            return new CapitalizationConverter(text, CapitalizationStyles.Camel);
        }

        public static IPascalCase FromPascalCase(this string text)
        {
            return new CapitalizationConverter(text, CapitalizationStyles.Pascal);
        }

        public static ITextCase FromText(this string text, string separator = null)
        {
            return new CapitalizationConverter(text, CapitalizationStyles.Text, separator);
        }
    }
}
