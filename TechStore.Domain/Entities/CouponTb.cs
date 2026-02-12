
using System;
using System.Collections.Generic;


namespace TechStore.Domain.Entities;

public partial class CouponTb
{
    public int IdCoupon { get; set; }
    public string Code { get; set; }
    public decimal DiscountPercentage { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsActive { get; set; }
}
