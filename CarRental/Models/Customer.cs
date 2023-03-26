namespace CarRental.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ContactInfoId { get; set; }
    
    public ContactInfo ContactInfo { get; set; }
    public ICollection<Rental> Rentals { get; set; }
}