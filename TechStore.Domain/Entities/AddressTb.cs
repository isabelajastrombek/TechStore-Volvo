using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class AddressTb
{
    public int IdAddress { get; set; }

    public string? StreetAddress { get; set; }

    public string? NumberAddress { get; set; }

    public string? ComplementAddress { get; set; }

    public string? CityAddress { get; set; }

    public string? StateAddress { get; set; }

    public string? TypeAddress { get; set; }

    public int IdClient { get; set; }

    public virtual ClientTb IdClientNavigation { get; set; } = null!;

    public virtual ICollection<OrderTb> OrderTbs { get; set; } = new List<OrderTb>();
}
