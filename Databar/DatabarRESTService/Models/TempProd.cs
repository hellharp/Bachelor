﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabarRESTService.Models
{
	/// <summary>
	/// 
	/// </summary>
    public class TempProd
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public decimal UnitCost { get; set; }
    }
}
