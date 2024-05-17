using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class GetIngredsType
{
    public int? TypeId { get; set; }

    public string? TypeName { get; set; }

    public int? TypeStorageTemp { get; set; }

    public int? TypeStorageHumidity { get; set; }
}
