using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class SalesByFilmCategory
    {
        public string Category { get; set; }
        public decimal? TotalSales { get; set; }
    }
}
