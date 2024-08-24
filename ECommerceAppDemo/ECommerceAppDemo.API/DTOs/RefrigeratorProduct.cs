﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceAppDemo.API.DTOs
{
    public class RefrigeratorProduct
    {
        public int PID { get; set; }
        public string Category_Name { get; set; }
        public int? Category_Id { get; set; }
        public decimal? Price { get; set; }
        public string BrandName { get; set; }
        public int? Model_Year { get; set; }
        public string Refrigerator_Capacity { get; set; }
        public string Refrigerator_Type { get; set; }
        public int? Refrigerator_Star { get; set; }
        public string Refrigerator_Feature { get; set; }
    }
}