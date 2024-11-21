using Newtonsoft.Json;

namespace EnsekTechnicalTest.Models;

internal class EnergyData
{
	public IndividualEnergyData Electric { get; set; }
	public IndividualEnergyData Gas { get; set; }
	public IndividualEnergyData Nuclear { get; set; }
	public IndividualEnergyData Oil { get; set; }

	public static EnergyData DefaultEnergyData => new()
	{
		Electric = new()
		{
			EnergyId = 3,
			PricePerUnit = 0.47,
			QuantityOfUnits = 4322,
			UnitType = "kWh"
		},
		Gas = new()
		{
			EnergyId = 1,
			PricePerUnit = 0.34,
			QuantityOfUnits = 3000,
			UnitType = "m³"
		},
		Nuclear = new()
		{
			EnergyId = 2,
			PricePerUnit = 0.56,
			QuantityOfUnits = 0,
			UnitType = "MW"
		},
		Oil = new()
		{
			EnergyId = 4,
			PricePerUnit = 0.5,
			QuantityOfUnits = 20,
			UnitType = "Litres"
		},
	};
}

public class IndividualEnergyData
{
	[JsonProperty("energy_id")]
    public int EnergyId { get; set; }
	[JsonProperty("price_per_unit")]
	public double PricePerUnit { get; set; }
	[JsonProperty("quantity_of_units")]
	public int QuantityOfUnits { get; set; }
    [JsonProperty("unit_type")]
	public string UnitType { get; set; }
}