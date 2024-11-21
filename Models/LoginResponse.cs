using Newtonsoft.Json;

namespace EnsekTechnicalTest.Models;

internal class LoginResponse
{
	[JsonProperty("access_token")]
	public string AccessToken { get; set; }
	[JsonProperty("message")]
	public string Message { get; set; }
}
