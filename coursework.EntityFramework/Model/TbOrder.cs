using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbOrder
{
    public int OrderId { get; set; }

    public int OrderClientId { get; set; }

    public string OrderAddress { get; set; } = null!;

    public int OrderCost { get; set; }

    public int OrderProductCount { get; set; }

    public DateOnly OrderDate { get; set; }

    public int OrderPaytypeId { get; set; }

    public int OrderStatusId { get; set; }

    public virtual TbClient OrderClient { get; set; } = null!;

    public virtual TbPayType OrderPaytype { get; set; } = null!;

    public virtual TbOrderStatus OrderStatus { get; set; } = null!;

    public virtual ICollection<TbCartOrder> TbCartOrders { get; set; } = new List<TbCartOrder>();
}
