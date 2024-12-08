using FruitPort.Infrastructure;

namespace FruitPort.Api.Api;

[QueryType]
public class Query
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<FruitType> GetFruitTypes(FruitContext context)
    {
        return context.FruitTypes;
    }
}
