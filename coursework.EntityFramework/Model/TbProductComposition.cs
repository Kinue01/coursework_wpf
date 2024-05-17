using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbProductComposition
{
    public int CompositionProductId { get; set; }

    public int CompositionIngredientId { get; set; }

    public int CompositionIngredientCount { get; set; }

    public virtual TbProduct CompositionProduct { get; set; } = null!;
}
