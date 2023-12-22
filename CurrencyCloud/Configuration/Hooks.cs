using CynkyHook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TechTalk.SpecFlow;

[assembly: Parallelize(Workers = 100, Scope = ExecutionScope.ClassLevel)]
namespace CurrencyCloud.Configuration
{
    [Binding]
    class Hooks
    {
        Config _Config;
        FeatureContext _FeatureContext;
        ScenarioContext _ScenarioContext;

        Hooks(ScenarioContext scenarioContext)
        {
            _FeatureContext = scenarioContext.ScenarioContainer.Resolve<FeatureContext>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
            _Config = scenarioContext.ScenarioContainer.Resolve<Config>();
        }

        [BeforeTestRun]
        static void InitializeReport()
        {
            Config.InitializeReport();
        }

        [BeforeScenario]
        void Launch()
        {
            _Config.Launch(_FeatureContext, _ScenarioContext, ConfigManager.RS_User, ConfigManager.RS_Key);
        }

        [BeforeFeature]
        static void BeforeFeature(FeatureContext featureContext)
        {
            Config.BeforeFeature(featureContext);
        }

        [AfterScenario]
        void AfterScenario()
        {
            _Config.AfterScenario(_ScenarioContext);

        }

        [AfterStep]
        void Steps()
        {
            _Config.Steps(_FeatureContext, _ScenarioContext);
        }

        [AfterTestRun]
        static void TearDownReport()
        {
            Config.TearDownReport();
        }
    }
}
