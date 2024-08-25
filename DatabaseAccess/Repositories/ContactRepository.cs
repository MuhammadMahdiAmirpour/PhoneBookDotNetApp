// DatabaseAccess/Repositories/ContactRepository.cs
using DatabaseAccess.Data; // Ensure this is the correct namespace
using Microsoft.EntityFrameworkCore;
using ModelClasses; // Ensure this is the correct namespace for your models

namespace DatabaseAccess.Repositories;

public class ContactRepository(PhoneBookDbContext context) : IContactRepository {
	public async Task<List<Contact>> GetAllAsync() => await context.Contacts.ToListAsync();

	public async Task<Contact?> GetByIdAsync(int id) => await context.Contacts.FindAsync(id);

	public async Task AddAsync(Contact? contact) {
		if (contact != null) await context.Contacts.AddAsync(contact);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Contact? contact) {
		if (contact != null) context.Contacts.Update(contact);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id) {
		var contact = await context.Contacts.FindAsync(id);
		if (contact != null) {
			context.Contacts.Remove(contact);
			await context.SaveChangesAsync();
		}
	}
}
