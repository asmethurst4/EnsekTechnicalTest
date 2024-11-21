using EnsekTechnicalTest.Variables;

using OpenQA.Selenium;

namespace EnsekTechnicalTest.Pages;

internal class PageBase(ISearchContext context) : ComponentBase(context)
{
	public void Show(string url) => Driver.Navigate().GoToUrl($"{GlobalVariables.BaseUrl}{url}");

	public string Url => Driver.Url;
}
