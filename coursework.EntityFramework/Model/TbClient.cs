using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbClient
{
    public int ClientId { get; set; }

    public string ClientLastname { get; set; } = null!;

    public string ClientFirstname { get; set; } = null!;

    public string? ClientMiddlename { get; set; }

    public string ClientLogin { get; set; } = null!;

    public DateOnly ClientRegDate { get; set; }

    public DateOnly? ClientBirthday { get; set; }

    public virtual TbUser ClientLoginNavigation { get; set; } = null!;

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
