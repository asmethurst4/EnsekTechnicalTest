using System.Net;

using EnsekTechnicalTest.Models;

using Newtonsoft.Json;

using Polly;
using Polly.Retry;

using RestSharp;

namespace EnsekTechnicalTest.Helpers;

internal class ApiRequests
{
	private static readonly Uri _apiUrl = new("https://qacandidatetest.ensek.io/ENSEK/");

	#region Login

	public static LoginResponse LoginOkResponse(UserDetails userDetails)
		=> JsonConvert.DeserializeObject<LoginResponse>(
			GetSpecificLoginResponse(HttpStatusCode.OK, userDetails).Content);

	public static LoginResponse LoginBadRequestResponse(UserDetails userDetails)
		=> JsonConvert.DeserializeObject<LoginResponse>(
			GetSpecificLoginResponse(HttpStatusCode.BadRequest, userDetails).Content);

	public static LoginResponse LoginUnauthorisedResponse(UserDetails userDetails)
		=> JsonConvert.DeserializeObject<LoginResponse>(
			GetSpecificLoginResponse(HttpStatusCode.Unauthorized, userDetails).Content);

	private static RestResponse GetSpecificLoginResponse(HttpStatusCode httpStatusCode, 
		UserDetails userDetails)
	{
		var client = new RestClient(_apiUrl);
		var request = new RestRequest("login", Method.Post);
		request.AddHeader("Accept", "application/json");
		request.AddHeader("Content-Type", "application/json");
		
		if (httpStatusCode == HttpStatusCode.BadRequest)
		{
			request.AddJsonBody("{}");
		}
		else
		{
			request.AddJsonBody(userDetails); 
		}

		return GetSpecificResponse(httpStatusCode, client, request);
	}

	#endregion

	#region Energy Details

	public static EnergyData GetAllEnergyDetails()
	{
		var client = new RestClient(_apiUrl);
		var request = new RestRequest("energy", Method.Get);
		request.AddHeader("Accept", "application/json");

		return JsonConvert.DeserializeObject<EnergyData>(
			GetSpecificResponse(HttpStatusCode.OK, client, request).Content);
	}

	#endregion

	#region Orders

	public static OrderData[] GetAllOrderDetails()
	{
		var client = new RestClient(_apiUrl);
		var request = new RestRequest("orders", Method.Get);
		request.AddHeader("Accept", "application/json");

		return JsonConvert.DeserializeObject<OrderData[]>(
			GetSpecificResponse(HttpStatusCode.OK, client, request).Content);
	}

	#endregion

	#region Buy Fuel Quantities

	public static Guid GetSuccessfulElectricOrderNumber(string accessToken, int quantity)
		=> GetSpecificBuyFuelResponse(HttpStatusCode.OK, accessToken, 3, quantity);

	public static Guid GetSuccessfulGasOrderNumber(string accessToken, int quantity)
		=> GetSpecificBuyFuelResponse(HttpStatusCode.OK, accessToken, 1, quantity);

	public static Guid GetSuccessfulNuclearOrderNumber(string accessToken, int quantity)
		=> GetSpecificBuyFuelResponse(HttpStatusCode.OK, accessToken, 2, quantity);

	public static Guid GetSuccessfulOilOrderNumber(string accessToken, int quantity)
		=> GetSpecificBuyFuelResponse(HttpStatusCode.OK, accessToken, 3, quantity);

	private static Guid GetSpecificBuyFuelResponse(HttpStatusCode httpStatusCode,
		string accessToken, int energyId, int quantity)
	{
		var client = new RestClient(_apiUrl);
		var request = new RestRequest("buy/{id}/{quantity}", Method.Put);
		request.AddHeader("Accept", "application/json");
		request.AddHeader("Authorization", $"Bearer {accessToken}");
		request.AddUrlSegment("id", energyId);
		request.AddUrlSegment("quantity", quantity);

		var response = JsonConvert.DeserializeObject<ApiResponse>(
			GetSpecificResponse(httpStatusCode, client, request).Content);

		return Guid.Parse(response.Message[^37..].Replace(".", ""));
	}

	#endregion

	#region Reset Data

	public static ApiResponse ResetOkResponse(string accessToken)
		=> JsonConvert.DeserializeObject<ApiResponse>(
			GetSpecificResetResponse(HttpStatusCode.OK, accessToken).Content);

	private static RestResponse GetSpecificResetResponse(HttpStatusCode httpStatusCode,
		string accessToken)
	{
		var client = new RestClient(_apiUrl);
		var request = new RestRequest("reset", Method.Post);
		request.AddHeader("Accept", "application/json");
		request.AddHeader("Authorization", $"Bearer {accessToken}");

		return GetSpecificResponse(httpStatusCode, client, request);
	}

	#endregion

	private static RetryPolicy<RestResponse> RetryPolicy(HttpStatusCode expectedCode) 
		=> Policy.HandleResult<RestResponse>(r => r.StatusCode != expectedCode)
			.WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(250),
				(result, timespan, retryNo, context) => Console.WriteLine("Warning: " +
					$"Failed because Status Code was {result.Result.StatusCode}. " +
					$"Retry no.{retryNo} after {timespan.TotalMilliseconds}ms."));

	private static RestResponse GetSpecificResponse(HttpStatusCode statusCode, RestClient client, RestRequest request)
		=> statusCode switch
		{
			HttpStatusCode.OK => GetOkResponse(client, request),
			HttpStatusCode.BadRequest => GetBadRequestResponse(client, request),
			HttpStatusCode.Unauthorized => GetUnauthorisedResponse(client, request),
			HttpStatusCode.InternalServerError => GetInternalServerErrorResponse(client, request),
			_ => throw new ArgumentOutOfRangeException($"Invalid status code {statusCode} found.")
		};

	// 200 OK response
	private static RestResponse GetOkResponse(RestClient client, RestRequest request)
		=> RetryPolicy(HttpStatusCode.OK).Execute(() => client.Execute(request));

	// 400 error response
	private static RestResponse GetBadRequestResponse(RestClient client, RestRequest request)
	{
		var retryPolicy = RetryPolicy(HttpStatusCode.BadRequest);
		return retryPolicy.Execute(() => client.Execute(request));
	}

	// 401 error response
	private static RestResponse GetUnauthorisedResponse(RestClient client, RestRequest request)
	{
		var retryPolicy = RetryPolicy(HttpStatusCode.Unauthorized);
		return retryPolicy.Execute(() => client.Execute(request));
	}

	// 500 error response
	private static RestResponse GetInternalServerErrorResponse(RestClient client, RestRequest request)
	{
		var retryPolicy = RetryPolicy(HttpStatusCode.InternalServerError);
		return retryPolicy.Execute(() => client.Execute(request));
	}
}

public class ApiResponse
{
	[JsonProperty("message")]
	public string Message { get; set; }
}