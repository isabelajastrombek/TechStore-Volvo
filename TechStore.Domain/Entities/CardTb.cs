using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class CardTb
{
    public int IdCard { get; set; }

    public string? MaskedNumber { get; set; }

    public string? PaymentToken { get; set; }

    public string CpfCard { get; set; } = null!;

    public DateOnly ExpDateCard { get; set; }

    public string TypeCard { get; set; } = null!;

    public string? NicknameCard { get; set; }

    public string NameOnCard { get; set; } = null!;

    public int IdClient { get; set; }

    public virtual ClientTb IdClientNavigation { get; set; } = null!;

    public virtual ICollection<OrderTb> OrderTbs { get; set; } = new List<OrderTb>();
}
