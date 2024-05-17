using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbIngredientType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public int TypeStorageTemp { get; set; }

    public int TypeStorageHumidity { get; set; }

    public virtual ICollection<TbIngredient> TbIngredients { get; set; } = new List<TbIngredient>();
}
