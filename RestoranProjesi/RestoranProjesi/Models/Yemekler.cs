using System;
using System.Collections.Generic;

namespace RestoranProjesi.Models
{
    public partial class Yemekler
    {
        public int YemekNo { get; set; }
        public string? YemekAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public int? Porsiyon { get; set; }
        public string? ŞefAdi { get; set; }
    }
}
