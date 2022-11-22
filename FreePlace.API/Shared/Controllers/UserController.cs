using AutoMapper;
using FreePlace.API.Security.Authorization.Attributes;
using FreePlace.API.Security.Domain.Services.Communication;
using FreePlace.API.Shared.Domain.Models;
using FreePlace.API.Shared.Domain.Services;
using FreePlace.API.Shared.Extensions;
using FreePlace.API.Shared.Resources;
using Microsoft.AspNetCore.Mvc;

namespace FreePlace.API.Shared.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<ActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }

    [AllowAnonymous]
    [HttpPost("to-suscribe")]
    public async Task<ActionResult> Suscribe(PaymentRequest request)
    {
        var response = await _userService.Payment(request);
        return Ok(response);
    }

    /*
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.SaveAsync(user);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Created(nameof(Create),userResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.UpdateAsync(id, user);
        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }
    */
}