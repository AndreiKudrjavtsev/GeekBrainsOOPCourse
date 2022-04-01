using ActManager.Models;

namespace ActManager.ActGenerators;

public class ActGeneratorFactory
{
    public BaseActGenerator CreateGenerator(ActType type)
    {
        return type switch
        {
            ActType.GoodsAct => new GoodsActGenerator(),
            ActType.DeliveryAct => new DeliveryActGenerator(),
            _ => throw new NotImplementedException()
        };
    }
}
