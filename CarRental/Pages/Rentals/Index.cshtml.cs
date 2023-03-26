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
    public class IndexModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public IndexModel(CarRental.Data.RentalContext context)
        {
            _context = context;
        }

        public IList<Rental> Rental { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rental != null)
            {
                Rental = await _context.Rental
                .Include(r => r.Customer)
                .Include(r => r.Vehicle).ToListAsync();
            }
        }
    }
}
