using System.ComponentModel.DataAnnotations;

namespace ModelClasses.ViewModels;

public class ContactViewModel {
	public int Id { get; set; }

	[Required(ErrorMessage = "Name is required.")]
	[StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "Surname is required.")]
	[StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters.")]
	public string? Surname { get; set; }

	[Required(ErrorMessage = "City is required.")]
	[StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
	public string? City { get; set; }

	[Required(ErrorMessage = "Phone Number is required.")]
	[Phone(ErrorMessage = "Invalid phone number.")]
	public string? PhoneNumber { get; set; }
}