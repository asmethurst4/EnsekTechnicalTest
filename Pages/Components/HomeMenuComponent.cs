using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages.Components;

internal class HomeMenuComponent(IWebElement element) : ComponentBase(element)
{
	#region Elements

	private IWebElement Title => FindElement(By.CssSelector("h2"));
	private IWebElement Description => FindElement(By.XPath("(.//p)[1]"));
	private IWebElement Button => FindElement(By.XPath(".//a[contains(@class, 'btn-default')]"));

	#endregion

	#region Elements

	public string TitleText => Title.Text;
	public string DescriptionText => Description.Text;
	public string ButtonText => Button.Text;

	#endregion

	#region Public Properties

	public void ClickButton() => Button.Click();

	#endregion
}
