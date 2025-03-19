using System;
using System.Collections.Generic;

namespace Demo_HR_Management_System.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? EmpMobile { get; set; }

    public string? EmpEmail { get; set; }

    public string? EmpCity { get; set; }

    public string? EmpDesignation { get; set; }

    public string? EmpSalary { get; set; }
}
