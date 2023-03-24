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
    public class DetailsModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public DetailsModel(CarRental.Data.RentalContext context)
        {
            _context = context;
        }

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
    }
}
