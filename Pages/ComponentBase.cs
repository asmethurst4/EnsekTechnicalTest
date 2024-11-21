using EnsekTechnicalTest.Helpers;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EnsekTechnicalTest.Pages;

internal class ComponentBase
{
	private const int ElementTimeoutS = 10;

	protected ISearchContext SearchContext { get; }

	protected IWebDriver Driver { get; }

	protected ComponentBase(ISearchContext context)
	{
		SearchContext = context;
		Driver = WebDriverHelper.GetWebDriver(context);
	}

	protected WebDriverWait Wait(int numberOfSeconds = ElementTimeoutS)
		=> new(Driver, TimeSpan.FromSeconds(numberOfSeconds));

	protected IWebElement FindElement(By by, int timeoutS = ElementTimeoutS)
		=> Wait(timeoutS).Until(_ => SearchContext.FindElement(by));

	protected IList<IWebElement> FindElements(By by)
		=> SearchContext.FindElements(by);
}