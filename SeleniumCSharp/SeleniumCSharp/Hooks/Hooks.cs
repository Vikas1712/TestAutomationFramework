using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using SeleniumCSharp.Base;
using SeleniumCSharp.Config;
using SeleniumCSharp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumCSharp.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;
        private static ExtentTest _featureName;
        private static ExtentReports _extent;

        private static readonly string ReportPath = Directory.GetParent(@"../../../")?.FullName
                                                    + Path.DirectorySeparatorChar + "Result"
                                                    + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");


        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var type = _scenarioContext.ScenarioExecutionStatus.ToString();
            if (type == "UndefinedStep")
            {
                _currentScenarioName.Skip(_scenarioContext.ScenarioExecutionStatus.ToString());
            }
            DriverContext.Driver.Quit();
            if (Settings.BrowserType.ToString() == "Chrome" && DriverContext.Driver!=null)
            {
                CommonStep.KillProcessLocally("chromedriver");
            }
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            _extent  = new ExtentReports();
            var reporter = new ExtentSparkReporter(ReportPath+".html")
            {
                Config =
                {
                    DocumentTitle = "Automation Testing Report",
                    ReportName = "Regression Testing",
                    Theme = Theme.Standard
                }
            };
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName =
                _extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
        }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            ConfigReader.SetFrameworkSettings();
            OpenBrowser(Settings.BrowserType);
            _currentScenarioName = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "When":
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "Then":
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "And":
                        _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                }
            }
            else if (_scenarioContext.TestError != null)
            {
                var screenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().AsBase64EncodedString;
                var mediaEntity= MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, "screenshot").Build();
                switch (stepType)
                {
                    case "Given":
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(mediaEntity);
                        break;

                    case "When":
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(mediaEntity);
                        break;

                    case "Then":
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(mediaEntity);
                        break;
                }
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            _extent.Flush();
        }

        private static void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Edge:
                    DriverContext.Driver = new EdgeDriver();
                    break;

                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    ChromeOptions option = new();
                    option.AddArguments("start-maximized");
                    option.AddArguments("--disable-gpu");
                    Console.WriteLine("Setup");
                    DriverContext.Driver = new ChromeDriver(option);
                    break;

                case BrowserType.Safari:
                    DriverContext.Driver = new SafariDriver();
                    break;
            }
        }
    }
}