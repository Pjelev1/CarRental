using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.Pages.Rentals
{
    public class DetailsModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public DetailsModel(CarRental.Data.RentalContext context)
        {
            _context = context;
        }

      public Rental Rental { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rental == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }
            else 
            {
                Rental = rental;
            }
            return Page();
        }
    }
}
