using System;
using System.Collections.Generic;

namespace WebApplication4SportZal.Models;

public partial class Client
{
    public int Id { get; set; }

    public int? Age { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public int? Phone { get; set; }
}
