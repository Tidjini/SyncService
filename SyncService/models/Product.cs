using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncService.models
{
    public class Product
    {
        public string Reference { get; set; }
        public string Name { get; set; }

        public decimal Montant { get; set; }
        public decimal Qte { get; set; }
        
    }
}
