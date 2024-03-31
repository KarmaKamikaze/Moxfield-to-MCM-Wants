using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MoxfieldToMCMWants;

public class MCMWantListPopulator
{
    private const string MCMMagicUrl = "https://www.cardmarket.com/en/Magic";
    private readonly ChromeDriver _driver;
    private readonly string _mcmUsername;
    private readonly string _mcmPassword;

    public MCMWantListPopulator(Settings settings)
    {
        if (settings.MCMUsername == null || settings.MCMPassword == null)
        {
            throw new ArgumentException("MCM credentials are not defined in appsettings.json");
        }

        _mcmUsername = settings.MCMUsername;
        _mcmPassword = settings.MCMPassword;
        _driver = WebDriver.SetChromeDriverSettings(settings);
        // Implicitly wait for web elements to load
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
    }

    public void AddWantedList(Deck deck)
    {
        Login();
        // Navigate to Wants
        _driver.FindElement(By.CssSelector("#buying-dropdown")).Click();
        _driver.FindElement(By.CssSelector("#menu > li.nav-item.dropdown.hvr-sweep-to-top.d-none.d-md-inline > " +
                                           "ul > li:nth-child(2) > a")).Click();
        // Create new list
        _driver.FindElement(By.CssSelector("#swWantsListName")).SendKeys(
            RemoveNonAlphanumericCharacters(deck.Name[..Math.Min(deck.Name.Length, 30)]));
        _driver.FindElement(By.CssSelector("body > main > div.offset-lg-2.col-lg-8.px-0 > form > " +
                                           "div > div > button")).Click();
        // Add deck list
        _driver.FindElement(By.CssSelector("body > main > div.d-none.d-lg-flex.flex-column.flex-lg-row." +
                                           "justify-content-between.align-items-center.mb-4 > div > " +
                                           "a.btn.btn-outline-success")).Click();
        _driver.FindElement(By.CssSelector("#AddDecklist")).SendKeys(deck.ToString());
        _driver.FindElement(By.CssSelector("#AddDecklistForm > div > button")).Click();
        Thread.Sleep(10000); // Wait for site to process deck list
        _driver.FindElement(By.CssSelector("body > main > div:nth-child(7) > a")).Click();
    }

    public void QuitDriver()
    {
        _driver.Quit();
    }

    private void Login()
    {
        _driver.Url = MCMMagicUrl;

        // Log in using MCM credentials
        _driver.FindElement(By.CssSelector("#header-login > div:nth-child(3) > div > input")).SendKeys(_mcmUsername);
        _driver.FindElement(By.CssSelector("#header-login > div:nth-child(4) > div > input")).SendKeys(_mcmPassword);
        _driver.FindElement(By.CssSelector("#header-login > input.btn.btn-outline-primary.btn-sm")).Click();
    }

    private static string RemoveNonAlphanumericCharacters(string input)
    {
        // Use a regular expression to replace all non-alphanumeric characters with an empty string
        string pattern = "[^a-zA-Z0-9 ]";
        return Regex.Replace(input, pattern, "");
    }
}
