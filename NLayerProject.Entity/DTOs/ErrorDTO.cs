﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Entity.DTOs
{
    public class ErrorDTO
    {
        public ErrorDTO()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int Status { get; set; }
    }
}
