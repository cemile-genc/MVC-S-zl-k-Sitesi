﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(100)]
        public string AdminName { get; set; }
        [StringLength(100)]

        public string AdminPassword { get; set; }
        [StringLength(200)]

        public string AdminRole { get; set; }
		public bool AdminStatus { get; set; }
	}
}
