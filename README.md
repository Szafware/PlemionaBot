# PlemionaBot

> Exe project requires following dependency injection bindindings in order to use `PlemionaFeatures` class:
- PlemionaSettings (to self, singleton)
- IWebDriverProviderService <-> SeleniumWebDriverProviderService (singleton)
- IPlemionaFeatures <-> PlemionaDefaultFeatures
- IWebDriverBaseMethodsService <-> WebDriverBaseMethodsService
- IPlemionaMetadataProviderService <-> PlemionaMetadataProviderService
- IStepProviderService <-> StepProviderService
- IStepDelayService <-> ConstantStepDelayService|RandomStepDelayService
- ITypingDelayService <-> ConstantTypingDelayService|RandomTypingDelayService
- IFeatureLoggingService <-> FeatureLoggingService

> Exe project requires following nugets to work properly:
- Selenium.WebDriver (v3.141.0)
- Selenium.WebDriver.ChromeDriver (v83.0.4103.3900)
- DotNetSeleniumExtras.WaitHelpers (v3.11.0)
- Newtonsoft.Json (12.0.3)
- Serilog.Sinks.File (v4.1.0)