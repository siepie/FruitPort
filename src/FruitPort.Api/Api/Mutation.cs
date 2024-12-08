using FruitPort.Api.Exceptions;
using FruitPort.Api.Model;
using FruitPort.Infrastructure;

namespace FruitPort.Api.Api;

[MutationType]
public class Mutation
{
    [Error<ValidationException>]
    public async Task<FruitCreated> CreateFruitType(FruitContext context, NewFruitType fruitType)
    {
        if (fruitType.PurchasePrice < 0) throw new ValidationException("Price can't be negative", nameof(fruitType.PurchasePrice));
        if (fruitType.SalePrice < 0) throw new ValidationException("Price can't be negative", nameof(fruitType.SalePrice));

        var dbFruitType = new FruitType
        {
            Name = fruitType.Name,
            Origin = fruitType.Origin,
            ExpiryDate = fruitType.ExpiryDate,
            PurchasePrice = fruitType.PurchasePrice,
            SalePrice = fruitType.SalePrice
        };

        context.FruitTypes.Add(dbFruitType);

        await context.SaveChangesAsync();

        return new FruitCreated(dbFruitType.Name);
    }

    [Error<RecordNotFoundException>]
    [Error<ValidationException>]
    public async Task<StockChanged> RemoveFromStock(FruitContext context, StockMutation stockMutation)
    {
        int quantity = 0;

        var existingStock = context.FruitStocks.SingleOrDefault(fruit => fruit.FruitTypeId == stockMutation.FruitTypeId) ?? throw new RecordNotFoundException("Fruittype was not found.");

        if (existingStock.Quantity < stockMutation.Quantity) throw new ValidationException("Not enough items in stock", nameof(existingStock.Quantity));

        quantity = existingStock.Quantity - stockMutation.Quantity;
        existingStock.Quantity -= stockMutation.Quantity;
        await context.SaveChangesAsync();

        return new StockChanged("New stock count is ", quantity);
    }

    public async Task<StockChanged> AddToStock(FruitContext context, StockMutation stockMutation)
    {
        int quantity = stockMutation.Quantity;
        var existingStock = context.FruitStocks.SingleOrDefault(fruit => fruit.FruitTypeId == stockMutation.FruitTypeId);
        if (existingStock != null)
        {
            existingStock.Quantity = stockMutation.Quantity;
            existingStock.ActionDate = DateTime.Now;
            quantity = existingStock.Quantity + stockMutation.Quantity;
        }
        else
        {
            var dbFruitStock = new FruitStock
            {
                FruitTypeId = stockMutation.FruitTypeId,
                Quantity = stockMutation.Quantity,
                ActionDate = DateTime.Now
            };
            context.FruitStocks.Add(dbFruitStock);
        }

        await context.SaveChangesAsync();

        return new StockChanged("New stock count is ", quantity);
    }
}
