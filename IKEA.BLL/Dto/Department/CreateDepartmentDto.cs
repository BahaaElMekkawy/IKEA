﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto.Department
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
