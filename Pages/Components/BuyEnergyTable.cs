using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages.Components;

internal class BuyEnergyTable(IWebElement element) : ComponentBase(element)
{
	#region Elements

	private IList<IWebElement> TableRowElements => FindElements(By.CssSelector("tr"));

	#endregion

	#region Public Properties

	/* Ignores the first row which is the table header. For a more complete solution the header would be 
	 * added just for a page check test. */
	public List<BuyEnergyTableRow> TableRows 
		=> TableRowElements.Select(tr => new BuyEnergyTableRow(tr)).Skip(1).ToList();

	#endregion
}

internal class BuyEnergyTableRow(IWebElement element) : ComponentBase(element)
{
	#region Elements

	private IList<IWebElement> Columns => FindElements(By.CssSelector("td"));
	private static By UnitsRequiredFieldBy => By.Id("energyType_AmountPurchased");
	private IWebElement UnitsRequiredField => Columns[3].FindElement(UnitsRequiredFieldBy);
	private IWebElement BuyButton => Columns[4].FindElement(By.Name("Buy"));

	#endregion

	#region Public Properties

	public int QuantityAvailableValue => int.Parse(Columns[2].Text);

	#endregion

	#region Public Methods

	/* Setting this as a string in case testing with invalid characters is done later. Also because the field can be removed
	 * if there are no units available added an exception to handle this. */
	public void EnterNumberOfUnitsRequired(string numberOfUnits)
	{
		if (!UnitsRequiredFieldDisplayed)
		{
			throw new ElementNotVisibleException("Number of Units Required field is not displayed");
		}

		UnitsRequiredField.SendKeys(numberOfUnits);
	}

	public void ClickBuyButton() => BuyButton.Click();

	#endregion

	#region Private Methods

	private bool UnitsRequiredFieldDisplayed
		=> FindElements(UnitsRequiredFieldBy).Any(ur => ur.Displayed);

	#endregion
}