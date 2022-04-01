using ActManager.ExternalClients.Models;

namespace ActManager.ExternalClients.Clients;

public class GoodsApiClient
{
    public OrderApiDto GetOrderInfo(string externalId)
    {
        return new OrderApiDto()
        {
            Id = externalId,
            Client = "Some Customer",
            CreatedAt = DateTime.Now,
            Products = new List<ProductApiDto>()
            {
                new ProductApiDto()
                {
                    Id = "123129444",
                    Name = "AOC X24BH",
                    Cost = 105.00m,
                    Description = "24 inch FHD monitor 144hz",
                    Maker = "AOC"
                }
            }
        };
    }
}
