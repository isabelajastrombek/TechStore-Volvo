using System;
using System.Collections.Generic;

namespace TechStore.Domain.Entities;

public partial class OrderTb
{
    public int IdOrder { get; set; }

    public DateTime? DateOrder { get; set; }

    public int? IdClient { get; set; }

    public string? StatusOrder { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public int? IdCard { get; set; }

    public int? IdAddress { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? TotalShipping { get; set; }
    public int? IdCoupon { get; set; } 
    public string? ShippingCompany { get; set; }

    public int? ShippingDeliveryDays { get; set; }

    public virtual CouponTb IdCouponNavigation { get; set;}

    public virtual AddressTb? IdAddressNavigation { get; set; }

    public virtual CardTb? IdCardNavigation { get; set; }

    public virtual ClientTb? IdClientNavigation { get; set; }

    public virtual ICollection<ItemOrderTb> ItemOrderTbs { get; set; } = new List<ItemOrderTb>();
}
