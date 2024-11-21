using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages.Components;

internal class FooterComponent(IWebElement element) : ComponentBase(element)
{
	#region Elements

	private IWebElement TestingLabel => FindElement(By.CssSelector("p"));

	#endregion

	#region Public Properties

	public string TestingLabelText => TestingLabel.Text;

	#endregion
}