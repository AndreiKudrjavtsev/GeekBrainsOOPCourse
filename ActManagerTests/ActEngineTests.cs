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
    }
}