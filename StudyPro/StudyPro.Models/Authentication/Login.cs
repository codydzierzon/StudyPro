using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudyPro.Models.Authentication;

public class Login
{

    [DisplayName("User Name")]
    [Required(ErrorMessage = "User name is required.")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}