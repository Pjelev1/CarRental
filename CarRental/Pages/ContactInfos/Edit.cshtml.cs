using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.Pages.ContactInfos
{
    public class EditModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public EditModel(CarRental.Data.RentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactInfo ContactInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ContactInfo == null)
            {
                return NotFound();
            }

            var contactinfo =  await _context.ContactInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (contactinfo == null)
            {
                return NotFound();
            }
            ContactInfo = contactinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(ContactInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactInfoExists(int id)
        {
          return (_context.ContactInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
