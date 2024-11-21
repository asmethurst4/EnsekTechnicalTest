using OpenQA.Selenium;

namespace EnsekTechnicalTest.Extensions;

internal static class ElementExtensions
{
	public static IWebDriver GetDriver(this IWebElement element)
		=> ((IWrapsDriver)element).WrappedDriver;
}