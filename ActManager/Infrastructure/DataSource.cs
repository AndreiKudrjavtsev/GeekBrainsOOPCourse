using ActManager.Models;
using Newtonsoft.Json;

namespace ActManager.Infrastructure;

public class DataSource
{

    public ActDataModel GetDataFromSource()
    {
        // reading data from source
        var actData = File.ReadAllText("..\\..\\..\\act.json");

        // parsing data
        var actDataModel = JsonConvert.DeserializeObject<ActDataModel>(actData);
        return actDataModel;
    }
}
