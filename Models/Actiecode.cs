﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Actiecode
    {
        public int ActiecodeId { get; set; }
        public string Naam { get; set; }
        public DateTime GeldigVanDatum { get; set; }
        public DateTime GeldigTotDatum { get; set; }
        public bool IsEenmalig { get; set; }
    }
}
