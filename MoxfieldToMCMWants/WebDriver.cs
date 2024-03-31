using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUndetectedChromeDriver;

namespace MoxfieldToMCMWants;

public static class WebDriver
{
    public static UndetectedChromeDriver SetChromeDriverSettings(Settings settings)
    {
        var options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Normal
        };
        options.AddArgument("--window-size=1920,1080"); // set window size to native GUI size
        options.AddArgument("--no-sandbox");
        //options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--disable-crash-reporter");
        options.AddArgument("--disable-extensions");
        options.AddArgument("--disable-in-process-stack-traces");
        options.AddArgument("--disable-logging");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--start-maximized"); // ensure window is full-screen
        options.AddArgument("--log-level=3");
        options.AddArgument("--output=/dev/null");
        options.AddArgument("--blink-settings=imagesEnabled=false"); // disable images
        options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                            "AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
        //options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);

        UndetectedChromeDriver? driver = null;
        if (settings.ChromeDriverPath == null)
        {
            if (!File.Exists("./chromedriver.exe") && !File.Exists("./chromedriver"))
                throw new ArgumentException("ChromeDriver directory is not defined in appsettings.json");
            if (File.Exists("./chromedriver.exe"))
            {
                driver = UndetectedChromeDriver.Create(
                    driverExecutablePath: "./chromedriver.exe",
                    options: options,
                    hideCommandPromptWindow: true
                );
            }
            if (File.Exists("./chromedriver"))
            {
                driver = UndetectedChromeDriver.Create(
                    driverExecutablePath: "./chromedriver",
                    options: options,
                    hideCommandPromptWindow: true
                );
            }
        }
        else
        {
            driver = UndetectedChromeDriver.Create(
                driverExecutablePath: $"{settings.ChromeDriverPath}/chromedriver.exe",
                options: options,
                hideCommandPromptWindow: true
            );
        }

        return driver!;
    }
}
