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

        public Product(string reference, string name, decimal montant, decimal qte)
        {
            Reference = reference;
            Name = name;
            Montant = montant;
            Qte = qte;
        }
        public Product()
        {
            Reference = "";
            Name = "";
            Montant = 0;
            Qte = 0;
        }

    }
}
