using System;
using System.Collections.Generic;

namespace findmyfood.Models;

public partial class Item
{
    public int? ItemId { get; set; }

    public string? ItemName { get; set; } = null!;

    public string? ItemCat { get; set; } = null!;

    public float? Price { get; set; }

    public string? Description { get; set; }

    public int? StoreId { get; set; }

    public float? Weight { get; set; }

    public int? ItemNo { get; set; }

    public string? ImageUrl { get; set; }
}
