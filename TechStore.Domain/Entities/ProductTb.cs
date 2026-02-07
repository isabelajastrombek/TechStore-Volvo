using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class ProductTb
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public decimal PriceProduct { get; set; }

    public int StockProduct { get; set; }

    public int IdCategory { get; set; }

    public string? DescriptionProduct { get; set; }

    public string? SpecsProduct { get; set; }

    public string? BrandProduct { get; set; }

    public virtual CategoryTb IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<ItemOrderTb> ItemOrderTbs { get; set; } = new List<ItemOrderTb>();
}
