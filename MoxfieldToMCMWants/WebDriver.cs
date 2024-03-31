using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MoxfieldToMCMWants;

public static class WebDriver
{
    public static ChromeDriver SetChromeDriverSettings(Settings settings)
    {
        ChromeDriverService? service = null;
        if (settings.ChromeDriverPath == null)
        {
            if (!File.Exists("./chromedriver.exe") && !File.Exists("./chromedriver"))
                throw new ArgumentException("ChromeDriver directory is not defined in appsettings.json");
            if (File.Exists("./chromedriver.exe"))
                service = ChromeDriverService.CreateDefaultService("./chromedriver.exe");
            if (File.Exists("./chromedriver"))
                service = ChromeDriverService.CreateDefaultService("./chromedriver");
        }
        else
        {
            service = ChromeDriverService.CreateDefaultService(settings.ChromeDriverPath);
        }

        service!.EnableVerboseLogging = false;
        service.SuppressInitialDiagnosticInformation = true;
        service.HideCommandPromptWindow = true;

        ChromeOptions options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Normal
        };
        options.AddArgument("--window-size=1920,1080"); // set window size to native GUI size
        options.AddArgument("--no-sandbox");
        options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--disable-crash-reporter");
        options.AddArgument("--disable-extensions");
        options.AddArgument("--disable-in-process-stack-traces");
        options.AddArgument("--disable-logging");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("start-maximized"); // ensure window is full-screen
        options.AddArgument("--log-level=3");
        options.AddArgument("--output=/dev/null");
        options.AddArgument("--blink-settings=imagesEnabled=false"); // disable images
        options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
        options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);

        return new ChromeDriver(service, options);
    }
}
