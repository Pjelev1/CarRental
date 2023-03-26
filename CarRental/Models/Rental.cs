namespace CarRental.Models;

public class Rental
{
    public int Id { get; set; }
    public DateOnly RentDate { get; set; }
    public int Days { get; set; }
    public int CustomerId { get; set; }
    public int VehicleId { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
}