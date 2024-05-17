using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbPayType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
