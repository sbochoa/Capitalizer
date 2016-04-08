using System;
using System.Linq;
using static System.Char;

namespace Capitalizer
{
    public static class CapitalizationConverter
    {
        private static readonly string WhiteSpace = " ";
        private static readonly string UnderScore = "_";

        public static string ToCamelCase(this string text, Prefix textPrefix = Prefix.None, Prefix resultPrefix = Prefix.None)
        {
            return ToCapitalizationStyle(text, textPrefix, resultPrefix, (textTmp, textPrefixTmp, resultPrefixTmp) => ConcatText(textTmp, textPrefixTmp, resultPrefixTmp, ToLower));
        }

        public static string ToPascalCase(this string text, Prefix textPrefix = Prefix.None, Prefix resultPrefix = Prefix.None)
        {
            return ToCapitalizationStyle(text, textPrefix, resultPrefix, (textTmp, textPrefixTmp, resultPrefixTmp) => ConcatText(textTmp, textPrefixTmp, resultPrefixTmp, ToUpper));
        }

        private static string ToCapitalizationStyle(string text, Prefix textPrefix, Prefix resultPrefix, Func<string, Prefix, Prefix, string> capitalizationStyleFunc)
        {
            var capitalizationStyle = GetCapitalizationStyle(text);

            switch (capitalizationStyle)
            {
                case CapitalizationStyles.Text:
                    var fullText = GetFullTextWithSeparator(text, WhiteSpace, textPrefix);
                    return capitalizationStyleFunc(fullText, textPrefix, resultPrefix);
                case CapitalizationStyles.Camel:
                case CapitalizationStyles.None:
                case CapitalizationStyles.Pascal:
                    return capitalizationStyleFunc(text, textPrefix, resultPrefix);
            }

            throw new InvalidOperationException(nameof(capitalizationStyle));
        }

        private static CapitalizationStyles GetCapitalizationStyle(string text)
        {
            if (text.Length <= 2)
            {
                return CapitalizationStyles.None;
            }

            var words = text.Split(new[] { ' ' }, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

            if (words.Length > 1)
            {
                return CapitalizationStyles.Text;
            }

            return IsUpper(text[0]) ? CapitalizationStyles.Pascal : CapitalizationStyles.Camel;
            
        }

        private static string GetFullTextWithSeparator(string text, string separator, Prefix fromPrefix)
        {
            var words = text.Split(new[] { separator }, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

            return string.Join(string.Empty, words.Select(word => ConcatText(word, fromPrefix, Prefix.None, ToUpper)));
        }
        private static string ConcatText(string text, Prefix fromPrefix, Prefix prefix, Func<char, char> caseFunc)
        {
            return string.Concat
                (prefix == Prefix.UnderScore ? UnderScore : string.Empty
                    , fromPrefix == Prefix.UnderScore ? caseFunc(text[1]) : caseFunc(text[0])
                    , fromPrefix == Prefix.UnderScore
                        ? text.Substring(2, text.Length - 2)
                        : text.Substring(1, text.Length - 1));
        }
    }
}