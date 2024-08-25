using ModelClasses;

namespace DatabaseAccess.Repositories;

public interface IContactRepository {
	Task<List<Contact>> GetAllAsync();              // Retrieve all contacts
	Task<Contact?>       GetByIdAsync(int  id);      // Retrieve a contact by ID
	Task                 AddAsync(Contact? contact); // Add a new contact
	Task                 UpdateAsync(Contact? contact); // Update an existing contact
	Task                DeleteAsync(int     id);      // Delete a contact by ID
}
