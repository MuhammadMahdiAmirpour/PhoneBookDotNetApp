using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DatabaseAccess.Data;

public class PhoneBookDbContextFactory : IDesignTimeDbContextFactory<PhoneBookDbContext> {
	public PhoneBookDbContext CreateDbContext(string[]? args = null) {
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json") // Ensure this path is correct
			.Build();

		var builder          = new DbContextOptionsBuilder<PhoneBookDbContext>();
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		builder.UseSqlServer(connectionString);

		return new PhoneBookDbContext(builder.Options);
	}
}
