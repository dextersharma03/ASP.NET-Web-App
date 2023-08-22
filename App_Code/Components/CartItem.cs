using System;
using System.Collections.Generic;
using System.Xml;

public class CartItem
{
    public string Id;
    public int TableRowId;
    public Component Item;
    public IReadOnlyList<Component> SubItems;
    private readonly double _tablePrice = 0.0;
    public double TotalPrice => _tablePrice == 0.0 ? CalculateTotal() : _tablePrice;

    private readonly string _sum = "";
    public string Summary => _sum == "" ? GetSummary() : _sum;

    public int Qty = 1;

    public CartItem(Component item, List<Component> subItems)
    {
        Id = Guid.NewGuid().ToString();
        Item = item;
        SubItems = subItems;
    }

    public CartItem(int tblRow, Component item, double price, string summary, int qty)
    {
        TableRowId = tblRow;
        Item = item;
        _tablePrice = price;
        _sum = summary;
        Qty = qty;
    }

    private double CalculateTotal()
    {
        var total = Item.UnitPrice;
        foreach (var subItem in SubItems)
            total += subItem.UnitPrice;

        return total;
    }

    private string GetSummary()
    {
        var summary = $"Item: {Item.DisplayName} ({Item.Value})\r\n";
        if (SubItems.Count > 0)
            summary += $"Components:\r\n";

        foreach (var subItem in SubItems)
            summary += $"   - {subItem.DisplayName} (${subItem.UnitPrice})\r\n";

        return summary;
    }
}