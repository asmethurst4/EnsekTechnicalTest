using EnsekTechnicalTest.Models;

using Reqnroll;

namespace EnsekTechnicalTest.Steps;

[Binding]
internal class StepArgumentTransformations
{
	[StepArgumentTransformation]
	public static UserDetails MapTableToUserDetails(Table table)
		=> table.CreateInstance<UserDetails>();
}