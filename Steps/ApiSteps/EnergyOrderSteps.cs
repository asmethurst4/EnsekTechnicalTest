using EnsekTechnicalTest.Helpers;
using EnsekTechnicalTest.Models;

using FluentAssertions;

using Reqnroll;

namespace EnsekTechnicalTest.Steps.ApiSteps;

[Binding]
internal class EnergyOrderSteps(ScenarioContext scenarioContext)
{

	#region Whens

	[When("the user successfully buys (.*) units of Electric")]
	public void WhenTheUserSuccessfullyBuysUnitsOfElectric(int numberOfUnits)
	{
		var accessToken = scenarioContext.Get<LoginResponse>("LoginSuccess").AccessToken;
		var electricOrderNumber = 
			ApiRequests.GetSuccessfulElectricOrderNumber(accessToken, numberOfUnits);
		scenarioContext.Set(electricOrderNumber, "ElectricOrderNumber");
	}

	[When("the user successfully buys (.*) units of Gas")]
	public void WhenTheUserSuccessfullyBuysUnitsOfGas(int numberOfUnits)
	{
		var accessToken = scenarioContext.Get<LoginResponse>("LoginSuccess").AccessToken;
		var gasOrderNumber = 
			ApiRequests.GetSuccessfulGasOrderNumber(accessToken, numberOfUnits);
		scenarioContext.Set(gasOrderNumber, "GasOrderNumber");
	}

	[When("the user successfully buys (.*) units of Nuclear")]
	public void WhenTheUserSuccessfullyBuysUnitsOfNuclear(int numberOfUnits)
	{
		var accessToken = scenarioContext.Get<LoginResponse>("LoginSuccess").AccessToken;
		var nuclearOrderNumber =
			ApiRequests.GetSuccessfulNuclearOrderNumber(accessToken, numberOfUnits);
		scenarioContext.Set(nuclearOrderNumber, "NuclearOrderNumber");
	}

	[When("the user successfully buys (.*) units of Oil")]
	public void WhenTheUserSuccessfullyBuysUnitsOfOil(int numberOfUnits)
	{
		var accessToken = scenarioContext.Get<LoginResponse>("LoginSuccess").AccessToken;
		var oilOrderNumber =
			ApiRequests.GetSuccessfulOilOrderNumber(accessToken, numberOfUnits);
		scenarioContext.Set(oilOrderNumber, "OilOrderNumber");
	}

	#endregion

	#region Thens

	[Then("only the default Energy supply data will be present")]
	public static void ThenOnlyTheDefaultEnergySupplyDataWillBePresent()
	{
		var energyDetails = ApiRequests.GetAllEnergyDetails();
		energyDetails.Should().BeEquivalentTo(EnergyData.DefaultEnergyData);
	}

	[Then("only the default Order data will be present")]
	public static void ThenOnlyTheDefaultOrderDataWillBePresent()
	{
		var orderDetails = ApiRequests.GetAllOrderDetails();
		orderDetails.Should().BeEquivalentTo(OrderData.DefaultOrderData);
	}

	[Then("the Orders list will display all the newly created orders")]
	public void ThenTheOrdersListWillDisplayAllTheNewlyCreatedOrders()
	{
		// Commented out the Nuclear option until it is available on the API
		var orderNumbers = new List<Guid>()
		{
			scenarioContext.Get<Guid>("ElectricOrderNumber"),
			scenarioContext.Get<Guid>("GasOrderNumber"),
			//scenarioContext.Get<Guid>("NuclearOrderNumber"),
			scenarioContext.Get<Guid>("OilOrderNumber")
		};

		var orderDetails = ApiRequests.GetAllOrderDetails();
		var orderDetailsIds = orderDetails.Select(od => od.Id).ToList();
		orderDetailsIds.Should().Contain(orderNumbers);
	}

	[Then("there will be (.*) orders created before the current date")]
	public static void ThenThereWillBeOrdersCreatedBeforeTheCurrentDate(int numberOfOrders)
	{
		var orderDetails = ApiRequests.GetAllOrderDetails();
		var filteredOrderDetails = orderDetails.Where(od => od.Time < DateTime.Today).ToList();
		filteredOrderDetails.Count.Should().Be(numberOfOrders);
	}

	#endregion
}