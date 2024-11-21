using EnsekTechnicalTest.Helpers;
using EnsekTechnicalTest.Models;
using FluentAssertions;

using Reqnroll;

namespace EnsekTechnicalTest.Steps.ApiSteps;

[Binding]
internal class LoginApiSteps(ScenarioContext scenarioContext)
{
	#region Givens

	[Given("the user has logged in and received a valid authorisation token")]
	public void GivenTheUserHasLoggedInAndReceivedAValidAuthorisationToken()
	{
		var validUser = new UserDetails()
		{
			Username = "test",
			Password = "testing"
		};

        WhenTheUserSubmitsAnAuthorisedLoginRequestWithTheFollowingDetails(validUser);
        ThenTheSystemReturnsASuccessResponseAndAnAccessToken();
	}

	#endregion

	#region Whens

	[When("the user submits an authorised login request with the following details")]
    public void WhenTheUserSubmitsAnAuthorisedLoginRequestWithTheFollowingDetails(UserDetails userDetails)
        => scenarioContext.Set(ApiRequests.LoginOkResponse(userDetails), "LoginSuccess");

    [When("the user submits a bad login request with the following details")]
    public void WhenTheUserSubmitsABadLoginRequestWithTheFollowingDetails()
    {
        var badUser = new UserDetails()
        {
            Username = "not",
            Password = "used"
        };

        scenarioContext.Set(ApiRequests.LoginBadRequestResponse(badUser), "LoginBadRequest");
    }

    [When("the user submits an unauthorised login request with the following details")]
    public void WhenTheUserSubmitsAnUnauthorisedLoginRequestWithTheFollowingDetails(UserDetails userDetails)
        => scenarioContext.Set(ApiRequests.LoginUnauthorisedResponse(userDetails), "LoginUnauthorised");

    #endregion

    #region Thens

    [Then("the system returns a 200 Success response and an access token")]
    public void ThenTheSystemReturnsASuccessResponseAndAnAccessToken()
    {
        var response = scenarioContext.Get<LoginResponse>("LoginSuccess");
        response.AccessToken.Should().NotBeNullOrEmpty();
        response.Message.Should().Be("Success");
    }

    [Then("the system returns a 400 Bad Request response and no access token")]
    public void ThenTheSystemReturnsABadRequestResponseAndNoAccessToken()
    {
        var response = scenarioContext.Get<LoginResponse>("LoginBadRequest");
        response.AccessToken.Should().BeNullOrEmpty();
        response.Message.Should().Be("Bad Request");
    }

    [Then("the system returns a 401 Unauthorised response and no access token")]
    public void ThenTheSystemReturnsAnUnauthorisedRequestResponseAndNoAccessToken()
    {
        var response = scenarioContext.Get<LoginResponse>("LoginUnauthorised");
        response.AccessToken.Should().BeNullOrEmpty();
        response.Message.Should().Be("Unauthorized");
    }

    #endregion
}