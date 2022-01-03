using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResimProjesi.Context;
using ResimProjesi.Entities;
using ResimProjesi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Controllers
{
    public class Products : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ProductDbContext _context;
        private readonly IValidator<AddProduct> _validator;
        public Products(ProductDbContext context,IValidator<AddProduct> validator, IWebHostEnvironment hostEnvironment,IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
        }
        public IActionResult CreateProduct()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateProduct(AddProduct product)
        {
            var validate = _validator.Validate(product);
          
            if (validate.IsValid)
            {

                var urun = _mapper.Map<Product>(product);
                var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "resimler");
                if (!Directory.Exists(dosyaYolu))
                {
                    Directory.CreateDirectory(dosyaYolu);
                }
                foreach(var item in urun.Dosyalar)
                {
                    var tamdosyaAdi = Path.Combine(dosyaYolu, item.FileName);
                    using(var dosyaAkisi = new FileStream(tamdosyaAdi,FileMode.Create))
                    {
                        item.CopyTo(dosyaAkisi);
                    }
                    urun.Pictures.Add(new Pictures { FileName = item.FileName });
                }
                _context.Products.Add(urun);
                _context.SaveChanges();
                //var tamdosyaAdi = Path.Combine(dosyaYolu, urun.Dosyalar);
                return RedirectToAction("ProductList");
                //var tamDosyaAdi = Path.Combine(dosyaYolu, urun.Dosyalar.FileName);
            }
            return View(product);
        }


        public IActionResult ProductList()
        {
            var urunler = _context.Products.Include(x=>x.Pictures).AsNoTracking().ToList();
            var modelurun = _mapper.Map<List<AddProduct>>(urunler);
            return View(modelurun);
        }
    }
}
