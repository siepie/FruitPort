using FruitPort.Infrastructure;

namespace FruitPort.Api.Model;

public class FruitTypeType : ObjectType<FruitType>
{
    protected override void Configure(IObjectTypeDescriptor<FruitType> descriptor)
    {
        descriptor.Field(f => f.Margin)
                  .ResolveWith<FruitResolvers>(r => r.GetMargin(default!))
                  .Description("The profit margin of the fruit.");
    }
}

public class FruitResolvers
{
    public decimal GetMargin(FruitType fruitType)
    {
        return fruitType.Margin;
    }
}
