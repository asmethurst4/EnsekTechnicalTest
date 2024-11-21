using System.Diagnostics;

using EnsekTechnicalTest.Drivers;

using Reqnroll;
using Reqnroll.BoDi;

namespace EnsekTechnicalTest.Hooks;

[Binding]
internal class Hooks
{
	[BeforeFeature("TechnicalTest")]
	public static void SetUpTest(IObjectContainer featureContainer)
	{
		var headlessMode = false;
		var driver = new BrowserDriver(headlessMode).Current;

		featureContainer.RegisterInstanceAs(driver, dispose: true);
	}

	[AfterTestRun]
	public static void KillWebDriverProcesses()
		=> Process.GetProcesses()
			.Where(p => p.ProcessName.EndsWith("driver"))
			.ToList()
			.ForEach(p => p.Kill());
}