using EnsekTechnicalTest.Pages.Components;
using EnsekTechnicalTest.Variables;

using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages;

internal class HomePage(IWebDriver driver) : PageBase(driver)
{
	public HeaderComponent Header => new(HeaderElement);
	public List<HomeMenuComponent> MenuComponents => GetHomeMenuComponents();
	public FooterComponent Footer => new(FooterElement);

	#region Elements
	
	private IWebElement HeaderElement => FindElement(By.XPath("//div[contains(@class, 'navbar-fixed-top')]"));
	private static By TitleBy => By.CssSelector("h1");
	private IWebElement Title => FindElement(TitleBy);
	private IWebElement SubTitle => FindElement(By.ClassName("lead"));
	private IWebElement FindOutMoreButton => FindElement(By.XPath("//a[contains(@class, 'btn-primary')]"));
	private IList<IWebElement> MenuOptions => FindElements(By.ClassName("col-md-4"));
	private IWebElement FooterElement => FindElement(By.CssSelector("footer"));

	#endregion

	#region Public Properties

	public bool Displayed => (FindElements(TitleBy).Any(e => e.Displayed) 
		&& Url.Equals(GlobalVariables.BaseUrl));
	public string TitleText => Title.Text;
	public string SubTitleText => SubTitle.Text;
	public string FindOutMoreButtonText => FindOutMoreButton.Text;

	#endregion

	#region Public Methods

	public void Show()
	{
		if (Displayed)
		{
			return;
		}

		Show("");
	}

	#endregion

	#region Private Methods

	private List<HomeMenuComponent> GetHomeMenuComponents()
		=> MenuOptions.Select(mo => new HomeMenuComponent(mo)).ToList();

	#endregion
}