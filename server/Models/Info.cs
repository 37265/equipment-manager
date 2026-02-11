namespace server.Models;

/*
Uses a primary constructor. FirstName and LastName seem to not be serialized for HTTP responses, therefore.
*/
public class Info(string? FirstName, string? LastName)
{
    public string? FullName => string.Concat(FirstName, " ", LastName);
}