using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Entities
{
    public class Pictures
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
    }
}
