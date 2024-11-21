namespace EnsekTechnicalTest.Variables;

internal static class GlobalVariables
{
	/* Note: Ideally, things like the BaseUrl would be placed into a config file that would then be stored in 
	 * the DI, or better yet a custom implementation of the WebDriver itself that uses the URL by default.
	 * However, there wasn't time to do this with my current schedule. */

	public static Uri BaseUrl => new("https://ensekautomationcandidatetest.azurewebsites.net/");
}