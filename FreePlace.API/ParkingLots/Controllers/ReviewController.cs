using AutoMapper;
using FreePlace.API.ParkingLots.Domain.Models;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.ParkingLots.Resources;
using FreePlace.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FreePlace.API.ParkingLots.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReviewController: ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ReviewResource>> GetAllAsync()
    {
        var review = await _reviewService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(review);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var review = _mapper.Map<SaveReviewResource, Review>(resource);

        var result = await _reviewService.SaveAsync(review);

        if (!result.Success)
            return BadRequest(result.Message);

        var parkingResource = _mapper.Map<Review, ReviewResource>(review);

        return Ok(parkingResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var review = _mapper.Map<SaveReviewResource, Review>(resource);

        var result = await _reviewService.UpdateAsync(id, review);

        if (!result.Success)
            return BadRequest(result.Message);

        var parkingResource = _mapper.Map<Review, ReviewResource>(result.Resource);

        return Ok(parkingResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reviewService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

        return Ok(reviewResource);
    }

}