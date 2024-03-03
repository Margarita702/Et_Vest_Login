using ET_Vest.Data;
using ET_Vest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace ET_Vest.Controllers
{
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext context;

        public SaleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var sales = context.Sales
           .Include(s => s.PrintedEdition)
           .Include(t => t.TradeObject)
           .ToList();

            return View(sales);
        }

        public IActionResult Add()
        {
            ViewBag.PrintedEditions = context.PrintedEditions.ToList();
            ViewBag.TradeObjects = context.TradeObjects.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Sale sale)
        {
           
            context.Sales.Add(sale);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Owner, Employee")]
        public IActionResult Edit(int id)
        {
            var sale = context.Sales
                .Include(m => m.PrintedEdition)
                .Include(m => m.TradeObject)
                .FirstOrDefault(m => m.SalesId == id);
            if (sale == null)
            {
                return NotFound();
            }

            ViewBag.PrintedEditions = context.PrintedEditions.ToList();
            ViewBag.TradeObjects = context.TradeObjects.ToList();

            return View(sale);
        }

        [HttpPost]
        public IActionResult Edit(Sale sale)
        {
            context.Sales.Update(sale);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Owner, Employee")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sale = context.Sales.Find(id);

            if (sale == null)
            {
                return NotFound();
            }

            context.Sales.Remove(sale);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}