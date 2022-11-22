using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}