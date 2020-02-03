using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCore.Data;
using ShopCore.Models;

namespace ShopCore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopCoreDbContext _context;
        private readonly MapperConfiguration mapperConfiguration;
        private readonly Mapper mapper;

        public ProductsController(ShopCoreDbContext context )
        {
            _context = context;
            this.mapperConfiguration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();
            });
            this.mapper = new Mapper(mapperConfiguration);
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            List<Product> productList = await _context.Products.ToListAsync();
            var prodacts = mapper.Map<List<Product>, List<ProductModel>>(productList);
            return View(prodacts);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            var product = mapper.Map<Product, ProductModel>(model);
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ammount,Price")] ProductModel model)
        {
            var product = mapper.Map<ProductModel, Product>(model);

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Products.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            var product = mapper.Map<Product, ProductModel>(model);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ammount,Price")] ProductModel model)
        {
            var product = mapper.Map<ProductModel, Product>(model);

            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            var product = mapper.Map<Product, ProductModel>(model);
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
