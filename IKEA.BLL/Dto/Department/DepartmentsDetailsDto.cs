﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto.Department
{
    public class DepartmentsDetailsDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly? CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
