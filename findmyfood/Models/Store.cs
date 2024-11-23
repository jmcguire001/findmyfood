using System;
using System.Collections.Generic;

namespace findmyfood.Models;

public partial class Store
{
    public int? StoreId { get; set; }

    public string? StoreName { get; set; } = null!;

    public string? StreetAddr { get; set; } = null!;

    public string? City { get; set; } = null!;

    public string? State { get; set; } = null!;

    public string? ZipCode { get; set; } = null!;

    public string? Country { get; set; } = null!;
}
