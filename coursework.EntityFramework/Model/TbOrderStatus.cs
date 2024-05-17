using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbOrderStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
