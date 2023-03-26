using CarRental.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.Pages.ContactInfos;

public class ContactPageModel : PageModel
{
    public Dictionary<int, string> contactIdToName { get; set; }
    public void LoadRelatedCustomers(RentalContext context)
    {
        contactIdToName = new Dictionary<int, string>();
        foreach (var customer in context.Customer)
        {
            if(customer.ContactInfoId == null || customer.Name == null) continue;
            contactIdToName.Add(customer.ContactInfoId, customer.Name);
        }
    }
}