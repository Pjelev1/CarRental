using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.Pages.ContactInfos
{
    public class DeleteModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public DeleteModel(CarRental.Data.RentalContext context)
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

            var contactinfo = await _context.ContactInfo.FirstOrDefaultAsync(m => m.Id == id);

            if (contactinfo == null)
            {
                return NotFound();
            }
            else 
            {
                ContactInfo = contactinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ContactInfo == null)
            {
                return NotFound();
            }
            var contactinfo = await _context.ContactInfo.FindAsync(id);

            if (contactinfo != null)
            {
                ContactInfo = contactinfo;
                _context.ContactInfo.Remove(ContactInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
