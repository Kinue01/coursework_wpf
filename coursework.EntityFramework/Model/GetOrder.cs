using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class GetOrder
{
    public int? OrderId { get; set; }

    public string? Concat { get; set; }

    public string? OrderAddress { get; set; }

    public int? OrderCost { get; set; }

    public int? OrderProductCount { get; set; }

    public DateOnly? TypeName { get; set; }

    public string? StatusName { get; set; }
}
