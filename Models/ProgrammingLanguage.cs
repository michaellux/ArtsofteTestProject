﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ArtsofteTestProject.Models;

public partial class ProgrammingLanguage
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<EmployeePlace> EmployeePlace { get; } = new List<EmployeePlace>();
}