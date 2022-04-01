using ActManager.ExternalClients.Clients;
using ActManager.Models;

namespace ActManager.ActGenerators;

public class GoodsActGenerator : BaseActGenerator
{
    private readonly GoodsApiClient _goodsApiClient = new GoodsApiClient();

    public override GoodsAct GenerateAct(ActDataModel actDataModel)
    {
        _logger.Log("Creating goods act");

        // some external api call 
        var orderInfo = _goodsApiClient.GetOrderInfo(actDataModel.ExternalId);

        // some logic with data mapping 
        var goodsAct = new GoodsAct()
        {
            Id = 0,
            ExternalId = orderInfo.Id,
            OrderDate = orderInfo.CreatedAt,
            Products = orderInfo
                .Products
                .Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Cost,
                    Quantity = 1
                })
                .ToList(),
            TotalCost = 105.99m
            // some logic forming total cost can be here
            // comissions, discounts etc. (using data from apis) 
        };
        return goodsAct;
    }
}
