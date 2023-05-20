using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace RestSharpSpecFlow.Hooks
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest? _featureName;
        private static ExtentReports? _extent;
        private static readonly string ReportPath =
            $"{Directory.GetParent(@"../../../")?.FullName}\\Result\\Result_{DateTime.Now:ddMMyyyy HHmmss}";

        private readonly ScenarioContext _scenarioContext;
        private ExtentTest? _currentScenarioName;
        
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [BeforeTestRun]
        public static void InitializeReport()
        {
            _extent = new ExtentReports();
            var reporter = new ExtentSparkReporter($"{ReportPath}.html")
            {
                Config =
                {
                    DocumentTitle = "RestSharp API Automation Report",
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
                _extent?.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            _currentScenarioName = _featureName?.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }
        
        [AfterScenario]
        public void AfterScenario()
        {
            var type = _scenarioContext.ScenarioExecutionStatus.ToString();
            if (type == "UndefinedStep") _currentScenarioName?.Skip(_scenarioContext.ScenarioExecutionStatus.ToString());
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
                        _currentScenarioName?.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "When":
                        _currentScenarioName?.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "Then":
                        _currentScenarioName?.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "And":
                        _currentScenarioName?.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                }
            }
            else if (_scenarioContext.TestError != null)
            {
                //var screenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().AsBase64EncodedString;
                //var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, "screenshot").Build();
                switch (stepType)
                {
                    case "Given":
                        _currentScenarioName?.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                            .Fail();
                        break;

                    case "When":
                        _currentScenarioName?.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail();
                        break;

                    case "Then":
                        _currentScenarioName?.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail();
                        break;
                }
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            _extent?.Flush();
        }
    }
}