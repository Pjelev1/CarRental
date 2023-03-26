using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Pages.Rentals;

public class RentalsPageModel : PageModel
{
    public SelectList CustomerSl { get; set; }
    public SelectList VehicleSl { get; set; }

    public void PopulateSelectLists(RentalContext _context, object? selectedCustomer = null, object? selectedVehicle = null)
    {
        var customersQuery = from customer in _context.Customer orderby customer.Name select customer;
        CustomerSl = new SelectList(customersQuery.AsNoTracking(),
            nameof(Customer.Id),
            nameof(Customer.Name),
            selectedCustomer);
        
        var vehicleQuery = from vehicle in _context.Vehicle orderby vehicle.Registration select vehicle;
        VehicleSl = new SelectList(vehicleQuery.AsNoTracking(),
            nameof(Vehicle.Id),
            nameof(Vehicle.Model),
            selectedVehicle);
    }
}