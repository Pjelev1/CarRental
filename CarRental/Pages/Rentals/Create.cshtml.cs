using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public CreateModel(CarRental.Data.RentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Customer"] = new SelectList(_context.Customer, nameof(Customer.Id), nameof(Customer.Name));
            ViewData["Vehicle"] = new SelectList(_context.Vehicle, nameof(Vehicle.Id), nameof(Vehicle.Model));
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Rental.Customer = _context.Customer.Find(Rental.CustomerId);
            Rental.Vehicle = _context.Vehicle.Find(Rental.VehicleId);
            ModelState.MarkFieldValid(nameof(Models.Rental.Customer));
            ModelState.MarkFieldValid(nameof(Models.Rental.Vehicle));
          if (/*!ModelState.IsValid ||*/ _context.Rental == null || Rental == null)
            {
                return Page();
            }

            _context.Rental.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
