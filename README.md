# PlemionaBot

> Exe project requires following dependency injection bindindings in order to use `PlemionaFeatures` class:
- IWebDriverProvider | SeleniumWebDriverProvider (singleton)
- IPlemionaFeatures | PlemionaFeatures
- IPlemionaSteps | PlemionaSteps
- IWebDriverBaseMethodsService| WebDriverBaseMethodsService
- IPlemionaConfigProviderService | PlemionaConfigProviderService

> Exe project requires following nugets to work properly:
- Selenium.WebDriver (v3.141.0)
- Selenium.WebDriver.ChromeDriver (v83.0.4103.3900)
- DotNetSeleniumExtras.WaitHelpers (v3.11.0)