using System;
using System.Collections.Generic;

namespace Northwind.DAL.Models;

public partial class SatışRaporu
{
    public string ÇalışanAdSoyad { get; set; } = null!;

    public string ŞirketAdı { get; set; } = null!;

    public string KategoriAdı { get; set; } = null!;

    public decimal? ÜrünFiyatı { get; set; }

    public short Adet { get; set; }
}
