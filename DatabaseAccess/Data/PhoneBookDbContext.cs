// DatabaseAccess/Data/PhoneBookDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelClasses;

namespace DatabaseAccess.Data;

public class PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : IdentityDbContext<ApplicationUser>(options) {
	public DbSet<Contact> Contacts { get; set; } // Example DbSet for Contacts

	public DbSet<ApplicationUser> ApplicationUsers { get; set; }
	// Add other DbSets as needed
}
