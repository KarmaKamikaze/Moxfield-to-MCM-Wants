using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MoxfieldToMCMWants;

public class MoxfieldDeckGrabber
{
    private readonly ChromeDriver _driver;

    public MoxfieldDeckGrabber(Settings settings)
    {
        _driver = WebDriver.SetChromeDriverSettings(settings);
        // Implicitly wait for web elements to load
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
    }

    public Deck ExportDeck(string url, bool keepEditions)
    {
        _driver.Url = url;

        string name = _driver.FindElement(By.CssSelector("#menu-deckname > span")).Text;
        _driver.FindElement(By.CssSelector("#subheader-more")).Click();
        _driver.FindElement(
            By.CssSelector("body > div.dropdown-menu.show > div > div > div > a:nth-child(1)")).Click();

        string deckList = _driver.FindElement(By.CssSelector(
            "body > div.modal.zoom.show.d-block > div > div > div.modal-body > div > textarea:nth-child(2)")).Text;

        Deck deck = new Deck(name, url);
        deck.ConstructDeckList(deckList, keepEditions);

        return deck;
    }

    public void QuitDriver()
    {
        _driver.Quit();
    }
}
