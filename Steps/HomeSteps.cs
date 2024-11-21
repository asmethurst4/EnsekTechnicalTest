using EnsekTechnicalTest.Pages;

using FluentAssertions;

using Reqnroll;

namespace EnsekTechnicalTest.Steps;

[Binding]
internal class HomeSteps(HomePage homePage)
{
	private readonly HomePage _homePage = homePage;

	#region StepDefinitions

	[StepDefinition("the user is on the Home page")]
	public void TheUserIsOnTheHomePage() => _homePage.Show();

	#endregion

	#region Whens

	[When("the user clicks the Buy energy button")]
	public void WhenTheUserClicksTheBuyEnergyButton() => _homePage.MenuComponents[0].ClickButton();
	
	#endregion

	#region Thens

	[Then("the user will see the header displayed properly")]
	public void ThenTheUserWillSeeTheHomePageHeaderDisplayedProperly()
		=> _homePage.Header.HeaderLinksText.Should().BeEquivalentTo(ExpectedHeaderLinksText);

	[Then("the user will see the Home page title section displayed properly")]
	public void ThenTheUserWillSeeTheHomePageTitleSectionDisplayedProperly()
	{
		_homePage.TitleText.Should().Be("ENSEK Energy Corp.");
		_homePage.SubTitleText.Should().Be("Doing all things energy since 2010!");
		_homePage.FindOutMoreButtonText.Should().Be("Find out more »");
	}

	[Then("the user will see the Home page Buy some energy section displayed properly")]
	public void ThenTheUserWillSeeTheHomePageBuySomeEnergySectionDisplayedProperly()
	{
		_homePage.MenuComponents[0].TitleText.Should().Be("Buy some energy");
		_homePage.MenuComponents[0].DescriptionText.Should()
			.Be("We have various types of energy that can be procured ranging from gas to nuclear power.");
		_homePage.MenuComponents[0].ButtonText.Should().Be("Buy energy »");
	}

	[Then("the user will see the Home page Sell some energy section displayed properly")]
	public void ThenTheUserWillSeeTheHomePageSellSomeEnergySectionDisplayedProperly()
	{
		_homePage.MenuComponents[1].TitleText.Should().Be("Sell some energy");
		_homePage.MenuComponents[1].DescriptionText.Should()
			.Be("Got some surpless energy? We'll take it off your hands for a good price.");
		_homePage.MenuComponents[1].ButtonText.Should().Be("Sell energy »");
	}

	[Then("the user will see the Home page About us section displayed properly")]
	public void ThenTheUserWillSeeTheHomePageAboutUsSectionDisplayedProperly()
	{
		_homePage.MenuComponents[2].TitleText.Should().Be("About us");
		_homePage.MenuComponents[2].DescriptionText.Should()
			.Be("We've been around for a while and have a story to tell...");
		_homePage.MenuComponents[2].ButtonText.Should().Be("Learn more »");
	}

	[Then("the user will see the footer displayed properly")]
	public void ThenTheUserWillSeeTheHomePageFooterDisplayedProperly()
		=> _homePage.Footer.TestingLabelText.Should().Be("[For Candidate Testing Purposes Only]");

	#endregion

	private static List<string> ExpectedHeaderLinksText =>
	[
		"Home",
		"About",
		"Contact",
		"Register",
		"Log in"
	];
}