using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages.Components;

internal class HeaderComponent(IWebElement element) : ComponentBase(element)
{
	#region Elements

	private IList<IWebElement> HeaderLinks => FindElements(By.CssSelector("a"));

	#endregion

	#region Public Properties

	public List<string> HeaderLinksText => HeaderLinks.Select(hl => hl.Text).ToList();

	#endregion
}