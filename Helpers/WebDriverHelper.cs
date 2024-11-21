using EnsekTechnicalTest.Extensions;

using OpenQA.Selenium;

namespace EnsekTechnicalTest.Helpers;

internal static class WebDriverHelper
{
	public static IWebDriver GetWebDriver(ISearchContext searchContext)
		=> searchContext switch
		{
			IWebDriver driver => driver,
			IWebElement element => element.GetDriver(),
			_ => throw new NotImplementedException($"Invalid type {searchContext.GetType()} provided.")
		};
}