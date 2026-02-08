using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class CategoryTb
{
    public int IdCategory { get; set; }

    public string? NameCategory { get; set; }

    public virtual ICollection<ProductTb> ProductTbs { get; set; } = new List<ProductTb>();
}
