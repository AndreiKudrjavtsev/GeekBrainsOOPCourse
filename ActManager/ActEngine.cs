using ActManager.ActGenerators;
using ActManager.Infrastructure;
using ActManager.Models;

namespace ActManager;

public class ActEngine
{
    private readonly ConsoleLogger _logger = new ConsoleLogger();
    private readonly DataSource _dataSource = new DataSource();
    private readonly DataSaver _dataSaver = new DataSaver();
    private readonly ActGeneratorFactory _generatorFactory = new ActGeneratorFactory();

    public ActEngine() {}

    public ActEngine(
        ConsoleLogger logger, 
        DataSource dataSource, 
        DataSaver dataSaver, 
        ActGeneratorFactory generatorFactory
    )
    {
        _logger = logger;
        _dataSource = dataSource;
        _dataSaver = dataSaver;
        _generatorFactory = generatorFactory;
    }

    public BaseAct CreateAct()
    {
        _logger.Log("Starting creation of act");

        _logger.Log("Loading act data from file");
        ActDataModel actDataModel = _dataSource.GetDataFromSource();

        _logger.Log("Validating data");
        if (actDataModel.ExternalId == null)
        {
            _logger.Log("No external id given, can not form an act. \n Exiting");
            return null;
        }

        var generator = _generatorFactory.CreateGenerator(actDataModel.Type);
        var act = generator.GenerateAct(actDataModel);

        _dataSaver.SaveActData(act);

        _logger.Log("Successfully saved goods act into file");
        return act;
    }

    
}
