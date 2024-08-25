using System.ComponentModel.DataAnnotations;

namespace ModelClasses.ViewModels;

public class LoginViewModel {
	[Required(ErrorMessage = "Email is required.")]
	[EmailAddress(ErrorMessage = "Invalid email address.")]
	[DataType(DataType.EmailAddress)]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Password is required.")]
	[DataType(DataType.Password)]
	public string? Password { get; set; }

	[Display(Name = "Remember Me")]
	public bool RememberMe { get; set; } = false;

	public string? LoginStatus { get; set; }
}
