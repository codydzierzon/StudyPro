using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyPro.Models.Authentication;

public class Registration
{
    [DisplayName("User Name")]
    [Required(ErrorMessage = "User name is required.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [Column("HashedPassword")]
    public string Password { get; set; }

    [DisplayName("Confirm Password")]
    [Required(ErrorMessage = "Confirm password is required.")]
    public string ConfirmPassword { get; set; }
}