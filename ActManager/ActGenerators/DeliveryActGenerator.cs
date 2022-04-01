using ActManager.Infrastructure;
using ActManager.Models;

namespace ActManager.ActGenerators;

public class DeliveryActGenerator : BaseActGenerator
{
    public override DeliveryAct GenerateAct(ActDataModel actDataModel)
    {
        _logger.Log("Creating delivery act");

        // some external api calls
        // some logic with data mapping 
        var deliveryAct = new DeliveryAct()
        {
            Id = 0,
            ExternalId = actDataModel.ExternalId,
            Cost = 100m, // calculation logic
            PickUpPoint = "Saint-Petersburg", // data from apis can be used here
            PickUpDate = new DateTime(2022, 4, 1),
            DestinationPoint = "Moscow",
            DeliveryDate = new DateTime(2022, 4, 3),
            TransportCompany = "dpd"
        };
        return deliveryAct;
    }
}
