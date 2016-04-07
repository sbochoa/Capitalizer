using System;
using System.Linq;
using System.Security.Cryptography;
using static System.Char;

namespace Capitalizer
{
    public interface ICamelCaseConverter
    {
        string ToPascalCase(Prefix prefix = Prefix.None);
    }

    public interface IPascalCaseConverter
    {
        string ToCamelCase(Prefix prefix = Prefix.None);
    }

    public interface ITextCaseConverter
        : ICamelCaseConverter, IPascalCaseConverter
    { }

    public class CapitalizationConverter
        : ITextCaseConverter
    {
        private readonly string _text;
        private readonly CapitalizationStyles _fromCapitalizationStyles;
        private readonly Prefix _fromPrefix;
        private readonly string _fromSeparator;

        public CapitalizationConverter(string text, CapitalizationStyles fromCapitalizationStyles, Prefix fromPrefix, string fromSeparator = null)
        {
            _text = text;
            _fromCapitalizationStyles = fromCapitalizationStyles;
            _fromPrefix = fromPrefix;
            _fromSeparator = fromSeparator;
        }

        public string ToCamelCase(Prefix prefix = Prefix.None)
        {
            if (_fromCapitalizationStyles == CapitalizationStyles.Camel)
            {
                return _text;
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Pascal)
            {
                return ConcatText(_text, _fromPrefix, prefix, ToLower);
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Text)
            {
                var fullText = GetFullTextWithSeparator(_text, _fromSeparator, _fromPrefix);

                return ConcatText(fullText, _fromPrefix, prefix, ToLower);
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
                return ConcatText(_text, _fromPrefix, prefix, ToUpper);
            }

            if (_fromCapitalizationStyles == CapitalizationStyles.Text)
            {
                var fullText = GetFullTextWithSeparator(_text, _fromSeparator, _fromPrefix);

                return ConcatText(fullText, _fromPrefix, prefix, ToUpper);
            }

            throw new InvalidOperationException(nameof(_fromCapitalizationStyles));
        }

        private static string GetFullTextWithSeparator(string text, string separator, Prefix fromPrefix)
        {
            var words = text.Split(new[] { separator }, StringSplitOptions.None | StringSplitOptions.RemoveEmptyEntries);

            return string.Join(string.Empty, words.Select(word => ConcatText(word, fromPrefix, Prefix.None, ToUpper)));
        }
        private static string ConcatText(string text, Prefix fromPrefix, Prefix prefix, Func<char, char> caseFunc)
        {
            return string.Concat
                (prefix == Prefix.UnderScore ? "_" : string.Empty
                    , fromPrefix == Prefix.UnderScore ? caseFunc(text[1]) : caseFunc(text[0])
                    , fromPrefix == Prefix.UnderScore
                        ? text.Substring(2, text.Length - 2)
                        : text.Substring(1, text.Length - 1));
        }
    }
}