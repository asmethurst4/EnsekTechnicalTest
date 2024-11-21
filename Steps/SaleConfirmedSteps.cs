using EnsekTechnicalTest.Pages;
using EnsekTechnicalTest.Variables;

using FluentAssertions;

using Reqnroll;

namespace EnsekTechnicalTest.Steps;

[Binding]
internal class SaleConfirmedSteps(ScenarioContext scenarioContext, SaleConfirmedPage saleConfirmedPage)
{
	private readonly SaleConfirmedPage _saleConfirmedPage = saleConfirmedPage;

	#region StepDefinitions

	[StepDefinition("the user has been taken to the Sale Confirmed page")]
	[StepDefinition("the user will be taken to the Sale Confirmed page")]
	public void TheUserWillBeTakenToTheSaleConfirmedPage()
	{
		var initialUnitsAvailable = scenarioContext.Get<int>("initialUnitsAvailable");
		var unitsBought = scenarioContext.Get<int>("unitsBought");
		var expectedUnitsAvailable = initialUnitsAvailable - unitsBought;
		scenarioContext.Set(expectedUnitsAvailable, "expectedUnitsAvailable");

		_saleConfirmedPage.Url.Should()
			.Be($"{GlobalVariables.BaseUrl}Energy/SaleConfirmed?amountBought={unitsBought}" +
			$"&energyType=Gas&amountLeft={expectedUnitsAvailable}");
		_saleConfirmedPage.TitleText.Should().Be("Sale Confirmed!");
	}

	#endregion

	#region Thens

	[Then("the correct number of units of Gas being bought and remaining will be displayed")]
	public void ThenTheCorrectNumberOfUnitsOfGasBeingBoughtWillBeDisplayed()
	{
		var unitsBought = scenarioContext.Get<int>("unitsBought");
		var expectedUnitsAvailable = scenarioContext.Get<int>("expectedUnitsAvailable");
		/* Done in two separate statements because of the line break. If doing it properly I would have requested
		 * IDs for each line, but that isn't an option for this test. */
		_saleConfirmedPage.DescriptionText.Should()
			.StartWith($"Thank you for your purchase of {unitsBought} units of Gas We have popped it in " +
				$"the post and it will be with you shortly.");
		_saleConfirmedPage.DescriptionText.Should()
			.EndWith($"There are now {expectedUnitsAvailable} units of Gas left in our stores.");
	}

	#endregion
}