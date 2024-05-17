using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbIngredient
{
    public int IngredientId { get; set; }

    public string IngredientName { get; set; } = null!;

    public int IngredientWeight { get; set; }

    public int IngredientTypeId { get; set; }

    public virtual TbIngredientType IngredientType { get; set; } = null!;

    public virtual ICollection<TbIngredientsOnWarehouse> TbIngredientsOnWarehouses { get; set; } = new List<TbIngredientsOnWarehouse>();
}
