using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbCartOrder
{
    public int CartOrderId { get; set; }

    public int CartProductId { get; set; }

    public int CartProdCount { get; set; }

    public int? CartProdEmployeeId { get; set; }

    public DateOnly? CartProdProduceDate { get; set; }

    public virtual TbOrder CartOrder { get; set; } = null!;

    public virtual TbEmployee? CartProdEmployee { get; set; }

    public virtual TbProduct CartProduct { get; set; } = null!;
}
