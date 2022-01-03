using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Entities
{
    public class Product
    {
        public Product()
        {
            Pictures = new List<Pictures>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public IFormFile[] Dosyalar { get; set; }
        public List<Pictures> Pictures { get; set; }
    }
}
