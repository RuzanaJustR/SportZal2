﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klient.Models
{
    public partial class Client
    {
        public int Id { get; set; }

        public int? Age { get; set; }

        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public int? Phone { get; set; }
    }
}
