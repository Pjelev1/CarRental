using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Pages.Rentals;

public class CustomerNamesPageModel : PageModel
{
    public SelectList CustomerNameSl { get; set; }

    public void PopulateCustomersSelectList(RentalContext _context,
        object selectedCustomer = null)
    {
        var customersQuery = from d in _context.Customer
            orderby d.Name
            select d;

        CustomerNameSl = new SelectList(customersQuery.AsNoTracking(),
            nameof(Customer),
            nameof(Customer.Name),
            selectedCustomer);
    }
}