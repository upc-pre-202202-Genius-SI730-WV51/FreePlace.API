using System.ComponentModel.DataAnnotations;

namespace FreePlace.API.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }
    public string Password { set; get; }
}