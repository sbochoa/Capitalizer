using NUnit.Framework;
using Shouldly;

namespace Capitalizer.Tests
{
    [TestFixture]
    public class CapitalizerConverterTests
    {
        [TestCase("thisIsJustATest", "ThisIsJustATest")]
        [TestCase("test", "Test")]
        public void FromCamelCaseToPascalCase_WithoutTextPrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.ToPascalCase();

            result.ShouldBe(expectedResult);
        }

        [TestCase("thisIsJustATest", "_ThisIsJustATest")]
        [TestCase("test", "_Test")]
        public void FromCamelCaseToPascalCase_WithResultUnderscorePrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.ToPascalCase(Prefix.None, Prefix.UnderScore);

            result.ShouldBe(expectedResult);
        }

        [TestCase("ThisIsJustATest", "thisIsJustATest")]
        [TestCase("Test", "test")]
        public void FromPascalCaseToCamelCase_WithoutTextPrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.ToCamelCase();

            result.ShouldBe(expectedResult);
        }

        [TestCase("ThisIsJustATest", "_thisIsJustATest")]
        [TestCase("Test", "_test")]
        public void FromPascalCaseToCamelCase_WithResultUnderscorePrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.ToCamelCase(Prefix.None, Prefix.UnderScore);

            result.ShouldBe(expectedResult);
        }

        [TestCase("_thisIsJustATest", "ThisIsJustATest")]
        [TestCase("_test", "Test")]
        public void FromCamelCaseToPascalCase_WithTextUnderscorePrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.ToPascalCase(Prefix.UnderScore);

            result.ShouldBe(expectedResult);
        }

        [TestCase("_ThisIsJustATest", "thisIsJustATest")]
        [TestCase("_Test", "test")]
        public void FromPascalCaseToCamelCase_WithTextUnderscorePrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.ToCamelCase(Prefix.UnderScore);

            result.ShouldBe(expectedResult);
        }
    }
}
