using server.Interfaces;
using server.Models;

namespace server.Services;

public class TestService : ITestService
{
    public Test Get()
    {
        return new Test()
        {
            Title = "bla",
            Description = "bla"
        };
    }
}