using System;
using System.Linq;
using static System.Char;

namespace Capitalizer
{
    public interface ICamelCase
    {
        string ToPascalCase(Prefix prefix = Prefix.None);
    }

    public interface IPascalCase
    {
        string ToCamelCase(Prefix prefix = Prefix.None);
    }

    public interface ITextCase
        : ICamelCase, IPascalCase
    { }

    public class CapitalizationConverter
        : ITextCase
    {
        private readonly string _text;
        private readonly CapitalizationStyles _fromCapitalizationStyles;
        private readonly string _separator;

        public CapitalizationConverter(string text, CapitalizationStyles fromCapitalizationStyles, string separator = null)
        {
            _text = text;
            _fromCapitalizationStyles = fromCapitalizationStyles;
            _separator = separator;
        }

        public string ToCamelCase(Prefix prefix = Prefix.None)
        {
            if (_fromCapitalizationStyles == CapitalizationStyles.Camel)
            {
                return _text;
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Pascal)
            {
                return ConcatText(_text, prefix, ToLower);
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Text)
            {
                var fullText = GetFullTextWithSeparator(_text, _separator);

                return ConcatText(fullText, prefix, ToLower);
            }

            throw new InvalidOperationException(nameof(_fromCapitalizationStyles));
        }

        public string ToPascalCase(Prefix prefix = Prefix.None)
        {
            if (_fromCapitalizationStyles == CapitalizationStyles.Pascal)
            {
                return _text;
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Camel)
            {
                return ConcatText(_text, prefix, ToUpper);
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Text)
            {
                var fullText = GetFullTextWithSeparator(_text, _separator);

                return ConcatText(fullText, prefix, ToUpper);
            }

            throw new InvalidOperationException(nameof(_fromCapitalizationStyles));
        }

        private static string GetFullTextWithSeparator(string text, string separator)
        {
            var words = text.Split(new[] { separator }, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

            return string.Join(string.Empty, words.Select(word => ConcatText(word, Prefix.None, ToUpper)));
        }
        private static string ConcatText(string text, Prefix prefix, Func<char, char> caseFunc)
        {
            return string.Concat(prefix == Prefix.UnderScore ? "_" : string.Empty, caseFunc(text[0]),
                text.Substring(1, text.Length - 1));
        }
    }
}