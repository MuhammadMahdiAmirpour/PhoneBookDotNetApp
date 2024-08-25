using DatabaseAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;
using ModelClasses.ViewModels;

namespace PhoneBookNet.Controllers;

[Authorize]
public class ContactsController(IContactRepository contactRepository) : Controller {
	// GET: Contacts
	public async Task<IActionResult> Index() {
		var contacts = await contactRepository.GetAllAsync();
		return View(contacts);
	}

	// GET: Contacts/Create
	public IActionResult Create() => View();

	// POST: Contacts/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	[Authorize]
	public async Task<IActionResult> Create(ContactViewModel model) {
		if (!ModelState.IsValid) return View(model);
		var contact = new Contact {
			Name        = model.Name,
			Surname     = model.Surname,
			City        = model.City,
			PhoneNumber = model.PhoneNumber
		};

		await contactRepository.AddAsync(contact);
		return RedirectToAction(nameof(Index));
	}

	// GET: Contacts/Edit/5
	[Authorize]
	public async Task<IActionResult> Edit(int id) {
		var contact = await contactRepository.GetByIdAsync(id);
		if (contact == null) {
			return NotFound();
		}

		var model = new ContactViewModel {
			Id          = contact.Id,
			Name        = contact.Name,
			Surname     = contact.Surname,
			City        = contact.City,
			PhoneNumber = contact.PhoneNumber
		};

		return View(model);
	}

	// POST: Contacts/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	[Authorize]
	public async Task<IActionResult> Edit(ContactViewModel model) {
		if (!ModelState.IsValid) return View(model);
		var contact = new Contact {
			Id          = model.Id,
			Name        = model.Name,
			Surname     = model.Surname,
			City        = model.City,
			PhoneNumber = model.PhoneNumber
		};

		await contactRepository.UpdateAsync(contact);
		return RedirectToAction(nameof(Index));
	}

	// GET: Contacts/Delete/5
	[Authorize]
	public async Task<IActionResult> Delete(int id) {
		var contact = await contactRepository.GetByIdAsync(id);
		if (contact == null) {
			return NotFound();
		}
		return View(contact);
	}

	// POST: Contacts/Delete/5
	[HttpPost][ActionName("Delete")]
	[ValidateAntiForgeryToken]
	[Authorize]
	public async Task<IActionResult> DeleteConfirmed(int id) {
		await contactRepository.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
