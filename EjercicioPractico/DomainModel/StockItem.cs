﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class StockItem
    {
        public Producto producto { get; set; }

        public int cantidad { get; set; }
    }
}
