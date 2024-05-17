using System;
using System.Collections.Generic;

namespace coursework.EntityFramework.Model;

public partial class TbSupplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;

    public string SupplierPhone { get; set; } = null!;

    public string? SupplierEmail { get; set; }

    public string SupplierContact { get; set; } = null!;

    public virtual ICollection<TbIngredientsOnWarehouse> TbIngredientsOnWarehouses { get; set; } = new List<TbIngredientsOnWarehouse>();
}
