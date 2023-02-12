using System;
using System.Collections.Generic;

namespace AutoWebSovellus.Models
{
    public partial class Autot
    {
        public int AutoId { get; set; }
        public string Merkki { get; set; } = null!;
        public string Malli { get; set; } = null!;
        public int Vuosimalli { get; set; }
        public string Rekisterinumero { get; set; } = null!;
    }
}
