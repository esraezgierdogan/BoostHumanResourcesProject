﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmploymentDetails
    {
        public int EmploymentDetailsID { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime DismissalDate { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
