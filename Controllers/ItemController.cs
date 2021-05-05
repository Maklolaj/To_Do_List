using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET5_test.Data;
using NET5_test.Models;
using Microsoft.EntityFrameworkCore;

namespace NET5_test.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _db;

        public ItemController(AppDbContext db)
        {
            _db = db;


        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

       // public IActionResult Filtrated(IEnumerable<Item> objList)
       // {
       //
        //    return View("Filtrated");
       // }

        //GET Find
        public IActionResult IFind()
        {
            return View();
        }


        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filtrated(Item obj)
        {
            //Item test_object = new Item();

            IEnumerable<Item> query = _db.Items.Where(Item => Item.ItemName == obj.ItemName);

            //IEnumerable<Item> objList = _db.Items;

            return View(query);
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET Create
        public IActionResult Create()
        {
            
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _db.Items.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Borrower,Lender,ItemName")] Item item)
        {
            if (id != item.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(item);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.id))
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
            return View(item);
        }

        private bool ItemExists(int id)
        {
            return _db.Expense.Any(e => e.Id == id);
        }


        public async Task<IActionResult> IDetails(int? id)
        {
            if(id == null)
                {
                    return NotFound();
                }
            var db_item = await _db.Items.FirstOrDefaultAsync(e => e.id == id);

            if(db_item == null)
            {
                return NotFound();
            }
            return View(db_item);
        }
    }
}
