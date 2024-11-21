using EnsekTechnicalTest.Pages.Components;
using EnsekTechnicalTest.Variables;

using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages;

internal class BuyEnergyPage(IWebDriver driver) : PageBase(driver)
{
	public BuyEnergyTable BuyEnergyTable => new(TableElement);

	/* In a full implementation of this page, there would be a lot more elements and methods, but the task was
	 * only to do one scenario hence why the page is a little light right now. */
	#region Elements

	private static By TitleBy => By.CssSelector("h2");
	private IWebElement Title => FindElement(TitleBy);
	private IWebElement TableElement => FindElement(By.ClassName("table"));
	
	#endregion

	#region Public Properties

	public bool Displayed => FindElements(TitleBy).Any(e => e.Displayed)
		&& Url.Equals($"{GlobalVariables.BaseUrl}Energy/Buy");
	public string TitleText => Title.Text;

	#endregion

	#region Public Methods

	public void Show()
	{
		if (Displayed)
		{
			return;
		}

		Show("Energy/Buy");
	}

	#endregion
}