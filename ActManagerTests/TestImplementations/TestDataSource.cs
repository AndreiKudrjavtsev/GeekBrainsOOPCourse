using ActManager.Infrastructure.DataSources;
using ActManager.Models;

namespace ActManagerTests.TestImplementations;

internal class TestDataSource : IDataSource
{
    public ActDataModel ActDataModel { get; set; }

    public ActDataModel GetDataFromSource()
    {
        return ActDataModel;
    }
}
