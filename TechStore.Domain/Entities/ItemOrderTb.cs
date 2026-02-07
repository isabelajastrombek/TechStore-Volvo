using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class ItemOrderTb
{
    public int IdItemOrder { get; set; }

    public int? IdProduct { get; set; }

    public int? QtyItemOrder { get; set; }

    public decimal? PriceUnitItem { get; set; }

    public int? IdOrder { get; set; }

    public virtual OrderTb? IdOrderNavigation { get; set; }

    public virtual ProductTb? IdProductNavigation { get; set; }
}
