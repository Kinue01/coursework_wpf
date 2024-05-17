using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbUser
{
    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string? UserEmail { get; set; }

    public string UserPhone { get; set; } = null!;

    public int UserRoleId { get; set; }

    public string UserImage { get; set; }

    public virtual ICollection<TbClient> TbClients { get; set; } = new List<TbClient>();

    public virtual ICollection<TbEmployee> TbEmployees { get; set; } = new List<TbEmployee>();

    public virtual TbRole UserRole { get; set; } = null!;
}
