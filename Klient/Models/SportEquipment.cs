using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klient.Models
{
    public partial class SportEquipment
    {
      
            public int Id { get; set; }

            public string? Name { get; set; }

            public int? Quantity { get; set; }
    }
}
