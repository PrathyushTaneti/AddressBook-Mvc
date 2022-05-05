#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;
using System.Dynamic;

namespace AddressBook.Controllers
{
    public class PersonDetailsController : Controller
    {
        private readonly AddressBookContext _context;

        public PersonDetailsController(AddressBookContext context)
        {
            _context = context;
        }

        // GET: PersonDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonDetails.ToListAsync());
        }

        // GET: PersonDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.personDetail = await _context.PersonDetails
                .FirstOrDefaultAsync(m => m.Name == id);
            if (mymodel.personDetail == null)
            {
                return NotFound();
            }

            return View(mymodel.personDetail);
        }

        // GET: PersonDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Mobile,Landline,Website,Address")] PersonDetail personDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personDetail);
        }

        // GET: PersonDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personDetail = await _context.PersonDetails.FindAsync(id);
            if (personDetail == null)
            {
                return NotFound();
            }
            return View(personDetail);
        }

        // POST: PersonDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Email,Mobile,Landline,Website,Address")] PersonDetail personDetail)
        {
            if (id != personDetail.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonDetailExists(personDetail.Name))
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
            return View(personDetail);
        }

        // GET: PersonDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personDetail = await _context.PersonDetails
                .FirstOrDefaultAsync(m => m.Name == id);
            if (personDetail == null)
            {
                return NotFound();
            }

            return View(personDetail);
        }

        // POST: PersonDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personDetail = await _context.PersonDetails.FindAsync(id);
            _context.PersonDetails.Remove(personDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonDetailExists(string id)
        {
            return _context.PersonDetails.Any(e => e.Name == id);
        }
    }
}
