using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages;

internal class SaleConfirmedPage(IWebDriver driver) : PageBase(driver)
{
	#region Elements

	private IWebElement Title => FindElement(By.CssSelector("h2"));
	private IWebElement Description => FindElement(By.ClassName("well"));

	#endregion

	#region Public Properties

	public string TitleText => Title.Text;
	public string DescriptionText => Description.Text;

	#endregion
}