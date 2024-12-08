namespace FruitPort.Api.Model;

public record NewFruitType(string Name, string Origin, DateTime ExpiryDate, decimal PurchasePrice, decimal SalePrice);
