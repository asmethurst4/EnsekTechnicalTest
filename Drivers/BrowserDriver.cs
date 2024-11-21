using EnsekTechnicalTest.Extensions;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EnsekTechnicalTest.Drivers;

internal class BrowserDriver(bool headlessMode) : IDisposable
{
    private readonly Lazy<IWebDriver> _currentWebDriverLazy = new(GetChromeDriver(headlessMode));
    private bool _isDisposed;

    public IWebDriver Current => _currentWebDriverLazy.Value;

    private static ChromeDriver GetChromeDriver(bool headlessMode)
    {
        var chromeDriverPath = Environment.GetEnvironmentVariable("CHROMEWEBDRIVER");

        var chromeDriverService = string.IsNullOrEmpty(chromeDriverPath)
            ? ChromeDriverService.CreateDefaultService()
            : ChromeDriverService.CreateDefaultService(chromeDriverPath);

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("incognito");
        chromeOptions.AddArgument("--start-maximized");
        chromeOptions.AddArgument("--window-size=1920,1080");
        chromeOptions.AddArgument("--disable-notifications");
        chromeOptions.AddArgument("disable-infobars");

        if (headlessMode)
        {
            chromeOptions.AddArguments("headless");
        }

        var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

        return chromeDriver;
    }

	public static IWebDriver GetDriver(ISearchContext searchContext)
		=> searchContext switch
		{
			IWebDriver driver => driver,
			IWebElement element => element.GetDriver(),
			_ => throw new NotImplementedException($"Invalid type {searchContext.GetType()} provided.")
		};

	public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        try
        {
            Current.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        _isDisposed = true;
    }
}