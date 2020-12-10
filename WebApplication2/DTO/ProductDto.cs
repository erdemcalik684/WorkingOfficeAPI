﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.DTO
{
    public class ProductDto
    {
        //Product kaydederken ki verileri yazmalısın.

        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
    }
}
