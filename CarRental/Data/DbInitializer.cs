using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RentalContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<RentalContext>>()))
        {
            if (context == null)
            {
                throw new ArgumentNullException("Null RentalContext");
            }

            if (context.Vehicle.Any())
            {
                return;
            }

            context.Vehicle.AddRange(
                new Vehicle()
                {
                    VehicleType = VehicleType.Crossover,
                    Registration = "CT5522AA",
                    Model = "VW T-Roc",
                    PricePerDay = 20
                },

                new Vehicle()
                {
                    VehicleType = VehicleType.Suv,
                    Registration = "CT0011AA",
                    Model = "Audi Q5",
                    PricePerDay = 30
                },

                new Vehicle()
                {
                    VehicleType = VehicleType.Sports,
                    Registration = "CT1111AA",
                    Model = "Mercedes C-Class AMG",
                    PricePerDay = 70
                },

                new Vehicle()
                {
                    VehicleType = VehicleType.Compact,
                    Registration = "CT5522AA",
                    Model = "Mercedes A-Class",
                    PricePerDay = 50
                }
            );
            
            context.Customer.AddRange(
                new Customer()
                {
                    Name = "Plamen Jelev",
                    ContactInfo = new ContactInfo()
                    {
                        email = "carrentals@gmail.com"
                    }
                },
                
                new Customer()
                {
                    Name = "Nikolay Stanev",
                    ContactInfo = new ContactInfo()
                    {
                        phone = "088303030"
                    }
                },
                
                new Customer()
                {
                    Name = "Mihail Mihov",
                    ContactInfo = new ContactInfo()
                    {
                        email = "mmihov@example.com",
                        phone = "088888888"
                    }
                }
            );
            context.SaveChanges();
        }
    }
}