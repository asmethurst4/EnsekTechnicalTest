using Newtonsoft.Json;

namespace EnsekTechnicalTest.Models;
internal class OrderData
{
	[JsonProperty("fuel")]
    public string Fuel { get; set; }
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
    [JsonProperty("time")]
    public DateTime Time { get; set; }

	public static OrderData[] DefaultOrderData =>
	[
		new()
		{
			Fuel = "oil",
			Id = Guid.Parse("080d9823-e874-4b5b-99ff-2021f2a59b24"),
			Quantity = 25,
			Time = DateTime.Parse("Thu, 10 Mar 2022 00:01:24 GMT")
		},
		new()
		{
			Fuel = "gas",
			Id = Guid.Parse("31fc32da-bccb-44ab-9352-4f43fc44ed4b"),
			Quantity = 5,
			Time = DateTime.Parse("Thu, 10 Mar 2022 09:23:24 GMT")
		},
		new()
		{
			Fuel = "electric",
			Id = Guid.Parse("080d9823-e874-4b5b-99ff-2021f2a59b25"),
			Quantity = 23,
			Time = DateTime.Parse("Mon, 7 Feb 2022 00:01:24 GMT")
		},
		new()
		{
			Fuel = "nuclear",
			Id = Guid.Parse("2cdd6f69-95df-437e-b4d3-e772472db8de"),
			Quantity = 15,
			Time = DateTime.Parse("Tue, 08 Feb 2022 01:01:24 GMT")
		},
		new()
		{
			Fuel = "gas",
			Id = Guid.Parse("31fc32da-bccb-44ab-9352-4f43fc44ed4b"),
			Quantity = 5,
			Time = DateTime.Parse("Thu, 10 Mar 2022 09:01:24 GMT")
		}
	];
 }