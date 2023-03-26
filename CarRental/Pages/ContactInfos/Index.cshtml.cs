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
    public class IndexModel : ContactPageModel
    {
        private readonly CarRental.Data.RentalContext _context;

        public IndexModel(CarRental.Data.RentalContext context)
        {
            _context = context;
            LoadRelatedCustomers(_context);
        }

        public IList<ContactInfo> ContactInfo { get; set; } = default!;

        public async Task OnGetAsync()
        {
            LoadRelatedCustomers(_context);
            if (_context.ContactInfo != null)
            {
                ContactInfo = await _context.ContactInfo.ToListAsync();
            }
        }
    }
}
