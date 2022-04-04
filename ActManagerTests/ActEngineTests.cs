using ActManager;
using Xunit;

namespace ActManagerTests
{
    public class ActEngineTests
    {
        [Fact]
        public void EngineWorks()
        {
            var engine = new ActEngine();
            var act = engine.CreateAct();

            Assert.Equal("199000292234", act.ExternalId);
        }

        [Fact(Skip = "loading data can not be mocked yet")]
        public void NoExternalIdLoaded_RetursEmptyResult()
        {
            // mock loading
            // check that result is empty
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

        [Fact(Skip = "logging can not be mocked yet")]
        public void NoActProducedLogged()
        {
            // last message about external id logged
        }

        #endregion
    }
}