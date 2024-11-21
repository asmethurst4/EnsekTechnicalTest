using EnsekTechnicalTest.Helpers;
using EnsekTechnicalTest.Models;

using FluentAssertions;

using Reqnroll;

namespace EnsekTechnicalTest.Steps.ApiSteps;

[Binding]
internal class ResetApiSteps(ScenarioContext scenarioContext)
{
	#region Givens

	[Given("the user has reset the test data")]
	public void GivenTheUserHasResetTheTestData()
	{
		WhenTheUserSendsAResetRequestWithAValidAuthorisationToken();
		ThenTheSystemWillReturnASuccessResponseForTheResetRequest();
	}

	#endregion

	#region Whens

	[When("the user sends a Reset request with a valid authorisation token")]
	public void WhenTheUserSendsAResetRequestWithAValidAuthorisationToken()
	{
		var accessToken = scenarioContext.Get<LoginResponse>("LoginSuccess").AccessToken;
		var resetResponse = ApiRequests.ResetOkResponse(accessToken);
		scenarioContext.Set(resetResponse, "ResetSuccess");
	}

	#endregion

	#region Thens

	[Then("the system will return a 200 Success response for the Reset request")]
	public void ThenTheSystemWillReturnASuccessResponseForTheResetRequest()
	{
		var resetResponse = scenarioContext.Get<ApiResponse>("ResetSuccess");
		resetResponse.Message.Should().Be("Success");
	}

	#endregion
}
