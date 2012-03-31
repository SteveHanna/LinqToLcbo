﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class InventoryWhere
    {
        public InventoryWhere()
        {
            IsDead = new BoolProperty("is_dead");
            ProductId = new IntProperty("productId");
        }

        public IntProperty ProductId { get; set; }
        public BoolProperty IsDead { get; set; }
    }
}
