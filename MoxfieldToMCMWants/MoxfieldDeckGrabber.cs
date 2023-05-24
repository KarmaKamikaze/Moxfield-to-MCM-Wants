using OpenQA.Selenium.Chrome;

namespace MoxfieldToMCMWants;

public class MoxfieldDeckGrabber
{
    private ChromeDriver _driver;

    public MoxfieldDeckGrabber(Settings settings)
    {
        _driver = WebDriver.SetChromeDriverSettings(settings);
    }
}
