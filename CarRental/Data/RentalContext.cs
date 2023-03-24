using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Data
{
    public class RentalContext : DbContext
    {
        public RentalContext (DbContextOptions<RentalContext> options)
            : base(options)
        {
        }

        public DbSet<CarRental.Models.Vehicle> Vehicle { get; set; } = default!;

        public DbSet<CarRental.Models.Rental> Rental { get; set; } = default!;

        public DbSet<CarRental.Models.Customer> Customer { get; set; } = default!;

        public DbSet<CarRental.Models.ContactInfo> ContactInfo { get; set; } = default!;
    }
}
