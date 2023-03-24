using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.Pages.Vehicles
{
    public class DetailsModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public DetailsModel(CarRental.Data.RentalContext context)
        {
            _context = context;
        }

      public Vehicle Vehicle { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            else 
            {
                Vehicle = vehicle;
            }
            return Page();
        }
    }
}
