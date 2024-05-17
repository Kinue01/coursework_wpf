using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public int ProductProteins { get; set; }

    public int ProductFats { get; set; }

    public int ProductCarbohydrates { get; set; }

    public int ProductWeight { get; set; }

    public string ProductImage { get; set; }

    public virtual ICollection<TbCartOrder> TbCartOrders { get; set; } = new List<TbCartOrder>();

    public virtual ICollection<TbProductComposition> TbProductCompositions { get; set; } = new List<TbProductComposition>();
}
