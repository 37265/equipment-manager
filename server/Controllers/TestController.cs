using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers;

// The [ApiController] attribute can also be used on multiple controller classes at once by creating
// a custom base controller, only specifying the attribute on that, and then always deriving from it.
[ApiController]
[Route("[controller]")]
public class TestController(ITestService testService, TestContext context) : ControllerBase
{
    /* It seems that a class property and constructor are not necessary (anymore) for Dependency 
    Injection if you use a primary constructor (i.e. params in class signature). */
    // private readonly ITestService _TestService;
    // public TestController(ITestService TestService)
    // {
    //     _TestService = TestService;
    // }

    /* Specifies the HTTP action and known HTTP status codes that can be returned
    Other examples of attributes are: [Route], [Bind], [Consumes], [Produces] */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)] // Example of [Produces] attribute
    [Consumes("application/json")] // Limits the allowed request content; see other types
    // [Consumes] can also be used to create two different actions at the same endpoint with the 
    // same HTTP verb, by creating two actions with different [Consumes] types.
    public async Task<ActionResult<IEnumerable<TestDTO>>> GetAll(
        // I can put things like 
        // [FromQuery] dataType paramName
        // here to specify where the values will come from
        // See also [FromHeader], [FromBody], [FromForm], [FromRoute], [FromService], [AsParameters]
    )
    {
        var test = await context.Tests
            .Select(test => ItemToDTO(test))
            .ToListAsync();

        return Ok(test);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TestDTO>> Get(int id)
    {
        var result = await context.Tests.FindAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return ItemToDTO(result);
    }

    [HttpPost]
    public async Task<ActionResult<TestDTO>> PostTest(TestDTO testDTO)
    {
        var testItem = new Test
        {
            Title = testDTO.Title,
            Description = testDTO.Description
        };

        context.Tests.Add(testItem);
        await context.SaveChangesAsync();

        // CreatedAtAction creates a Status201Created response 
        return CreatedAtAction(
            // The URL that would normally be used to call the Get() endpoint is used to generate 
            // the Location URL for the newly created Test object (i.e. [base URL]/id)
            nameof(Get), 
            // This then sets the 'id' parameter in the URL for the Get() endpoint to the Id of the 
            // newly created Test object
            new { 
                id = testItem.Id
                // I suppose you could fill as many route parameters as you want here
                }, 
            // Lastly, the newly created Test object is added to the response body
            ItemToDTO(testItem)); 
    }

    // Requires sending the entire entity. For just the changes, use PATCH
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTest(int id, TestDTO testDTO)
    {
        if (id != testDTO.Id) 
        {
            return BadRequest();
        }

        var testItem = await context.Tests.FindAsync(id);
        if (testItem == null)
        {
            return NotFound();
        }

        testItem.Description = testDTO.Description;
        testItem.Title = testDTO.Title;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TestExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTest(int id)
    {
        var testItem = await context.Tests.FindAsync(id);
        if (testItem == null)
        {
            return NotFound();
        }

        context.Tests.Remove(testItem);
        await context.SaveChangesAsync();

        return NoContent();
    }

    // Check whether an object of Test exists with the given ID
    private bool TestExists(int id)
    {
        return context.Tests.Any(e => e.Id == id);
    }

    // Turns a Test object into a TestDTO object; can probably be generalized
    private static TestDTO ItemToDTO(Test test) =>
        new()
        {
            Id = test.Id,
            Title = test.Title,
            Description = test.Description
        };
}

