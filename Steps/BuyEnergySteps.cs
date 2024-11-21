using EnsekTechnicalTest.Pages;
using EnsekTechnicalTest.Variables;

using FluentAssertions;

using Reqnroll;

namespace EnsekTechnicalTest.Steps;

[Binding]
internal class BuyEnergySteps(ScenarioContext scenarioContext, BuyEnergyPage buyEnergyPage)
{
	private readonly BuyEnergyPage _buyEnergyPage = buyEnergyPage;

	#region Step Definitions

	[StepDefinition("the user is on the Buy Energy page")]
	[StepDefinition("the user returns to the Buy Energy page")]
	public void TheUserIsOnTheBuyEnergyPage() => _buyEnergyPage.Show();

	#endregion

	#region Givens

	[Given("the user has bought some Gas from the Buy Energy page")]
	public void GivenTheUserHasBoughtSomeGasFromTheBuyEnergyPage()
	{
		WhenTheUserAttemptsToBuyUnitsOfGasFromTheBuyEnergyPage(75);
	}

	#endregion

	#region Whens

	[When("the user attempts to buy (.*) units of Gas from the Buy Energy page")]
	public void WhenTheUserAttemptsToBuyUnitsOfGasFromTheBuyEnergyPage(int unitsBought)
	{
		var initialUnitsAvailable = _buyEnergyPage.BuyEnergyTable.TableRows[0].QuantityAvailableValue;
		scenarioContext.Set(initialUnitsAvailable, "initialUnitsAvailable");
		scenarioContext.Set(unitsBought, "unitsBought");

		_buyEnergyPage.BuyEnergyTable.TableRows[0].EnterNumberOfUnitsRequired(unitsBought.ToString());
		_buyEnergyPage.BuyEnergyTable.TableRows[0].ClickBuyButton();
	}

	#endregion

	#region Thens

	[Then("the user is taken to the Buy energy page")]
	public void ThenTheUserIsTakenToTheBuyEnergyPage()
	{
		_buyEnergyPage.Url.Should().Be($"{GlobalVariables.BaseUrl}Energy/Buy");
		_buyEnergyPage.TitleText.Should().Be("Buy Energy");
	}

	[Then("the Buy Energy table will be updated to reflect the current amount of available Gas")]
	public void ThenTheBuyEnergyTableWillBeUpdatedToReflectTheCurrentAmountOfAvailableGas()
	{
		var expectedUnitsAvailable = scenarioContext.Get<int>("expectedUnitsAvailable");
		_buyEnergyPage.BuyEnergyTable.TableRows[0].QuantityAvailableValue.Should()
			.Be(expectedUnitsAvailable);
	}

	#endregion
}