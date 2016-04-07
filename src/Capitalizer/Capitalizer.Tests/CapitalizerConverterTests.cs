using NUnit.Framework;
using Shouldly;

namespace Capitalizer.Tests
{
    [TestFixture]
    public class CapitalizerConverterTests
    {
        [TestCase("thisIsJustATest", "ThisIsJustATest")]
        [TestCase("test", "Test")]
        public void FromCamelCaseToPascalCase_WithoutPrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.FromCamelCase().ToPascalCase();

            result.ShouldBe(expectedResult);
        }

        [TestCase("thisIsJustATest", "_ThisIsJustATest")]
        [TestCase("test", "_Test")]
        public void FromCamelCaseToPascalCase_WithUnderscorePrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.FromCamelCase().ToPascalCase(Prefix.UnderScore);

            result.ShouldBe(expectedResult);
        }

        [TestCase("ThisIsJustATest", "thisIsJustATest")]
        [TestCase("Test", "test")]
        public void FromPascalCaseToCamelCase_WithoutPrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.FromPascalCase().ToCamelCase();

            result.ShouldBe(expectedResult);
        }

        [TestCase("ThisIsJustATest", "_thisIsJustATest")]
        [TestCase("Test", "_test")]
        public void FromPascalCaseToCamelCase_WithUnderscorePrefix_MadeCorrectly(string text, string expectedResult)
        {
            var result = text.FromPascalCase().ToCamelCase(Prefix.UnderScore);

            result.ShouldBe(expectedResult);
        }

        [TestCase("This is Just a Test", "thisIsJustATest", " ")]
        [TestCase("This-is-Just-a-Test", "thisIsJustATest", "-")]
        [TestCase("This*is*Just*a*Test", "thisIsJustATest", "*")]
        [TestCase("Test working", "testWorking", " ")]
        public void FromTextToCamelCase_WithCustomSeparatorWithoutPrefix_MadeCorrectly(string text, string expectedResult, string separator)
        {
            var result = text.FromText(separator).ToCamelCase();

            result.ShouldBe(expectedResult);
        }
    }
}
