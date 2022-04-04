using ActManager;
using ActManager.ActGenerators;
using ActManager.Infrastructure;
using ActManager.Infrastructure.DataSources;
using ActManager.Infrastructure.Loggers;
using ActManager.Models;
using ActManagerTests.TestImplementations;
using System.Linq;
using Xunit;

namespace ActManagerTests
{
    public class ActEngineTests
    {
        private readonly ConsoleLogger _defaultLogger = new ConsoleLogger();
        private readonly IDataSource _defaultDataSource = new FileDataSource();
        private readonly DataSaver _defaultDataSaver = new DataSaver();
        private readonly ActGeneratorFactory _factory = new ActGeneratorFactory();

        [Fact]
        public void EngineWorks()
        {
            var engine = new ActEngine();
            var act = engine.CreateAct();

            Assert.Equal("199000292234", act.ExternalId);
        }

        [Fact]
        public void NoExternalIdLoaded_RetursEmptyResult()
        {
            // mock loading
            var testDataSource = new TestDataSource();
            testDataSource.ActDataModel = new ActDataModel()
            {
                ExternalId = null,
                Type = ActType.DeliveryAct,
            };

            var engine = new ActEngine(
                _defaultLogger,
                testDataSource, 
                _defaultDataSaver, 
                _factory
            );

            // check that result is empty
            var result = engine.CreateAct();

            Assert.Null(result);
        }

        #region Logging logic tests

        [Fact(Skip = "logging can not be mocked yet")]
        public void StandartFlowLogged()
        {
            // start logged
            // loading logged
            // validation logged
            // save logged
        }

        [Fact]
        public void NoActProducedLogged()
        {
            // last message about external id logged
            // "No external id given, can not form an act. \n Exiting"

            // mock loading
            var testDataSource = new TestDataSource();
            testDataSource.ActDataModel = new ActDataModel()
            {
                ExternalId = null,
                Type = ActType.DeliveryAct,
            };

            var testLogger = new TestLogger();

            var engine = new ActEngine(
                testLogger,
                testDataSource,
                _defaultDataSaver,
                _factory
            );

            // check that result is empty
            var result = engine.CreateAct();
            var lastLoggedMessage = testLogger.LoggedMessages.Last();

            Assert.Equal("No external id given, can not form an act. \n Exiting", lastLoggedMessage);
        }

        #endregion
    }
}