﻿using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
