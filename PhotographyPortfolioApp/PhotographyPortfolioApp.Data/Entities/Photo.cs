﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Data.Entities
{
    internal class Photo
    {
        public string Description { get; set; }
        public int Pixels { get; set; }
        public int UserId { get; set; } 
        public byte[] PhotoArray { get; set; }
    }
}