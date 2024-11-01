using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;
using ContactModel = App.Models.Contacts.Contact;
using Microsoft.AspNetCore.Authorization;
using App.Data;

namespace App.Areas.Contact.Controllers
{
    [Area("Contact")]
    [Authorize(Roles = RoleName.Administrator)]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        [TempData]
        public string StatusMessage {set; get;}
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contact/Contact
        [HttpGet("/admin/contact")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Contact/Contact/Details/5
        [HttpGet("/admin/contact/detail/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        
        [HttpGet("/contact/")]
        [AllowAnonymous] // cho phep an danh
        public IActionResult SendContact()
        {
            return View();
        }

        // POST: Contact/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("contact/")]
        [AllowAnonymous] // cho phep an danh
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendContact([Bind("FullName,Email,Message,Phone")] ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                contact.DateSent = DateTime.Now;
                _context.Add(contact);
                await _context.SaveChangesAsync();

                StatusMessage = "Lien he cua ban da duoc gui";
                return RedirectToAction("Index","Home");
            }
            return View(contact);
        }

       
        // GET: Contact/Contact/Delete/5
        [HttpGet("/admin/contact/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Contact/Delete/5
        [HttpPost("/admin/contact/delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // private bool ContactExists(int id)
        // {
        //     return _context.Contacts.Any(e => e.Id == id);
        // }
    }
}

// ko dungf den EDIT nen bo
 // // GET: Contact/Contact/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var contact = await _context.Contacts.FindAsync(id);
        //     if (contact == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(contact);
        // }

        // // POST: Contact/Contact/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,DateSent,Message,Phone")] ContactModel contact)
        // {
        //     if (id != contact.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(contact);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ContactExists(contact.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(contact);
        // }
