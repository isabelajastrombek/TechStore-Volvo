using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class ClientTb
{
    public int IdClient { get; set; }

    public string CpfClient { get; set; } = null!;

    public string? NameClient { get; set; }

    public DateOnly? BirthDateClient { get; set; }

    public string? PhoneClient { get; set; }

    public string? EmailClient { get; set; }

    public string? PasswordClient { get; set; }

    public virtual ICollection<AddressTb> AddressTbs { get; set; } = new List<AddressTb>();

    public virtual ICollection<CardTb> CardTbs { get; set; } = new List<CardTb>();

    public virtual ICollection<OrderTb> OrderTbs { get; set; } = new List<OrderTb>();
}
