using server.Models;

namespace server.Services;

public static class InfoService
{
    static readonly Info info = new("Frank", "Oud");

    public static Info GetInfo() => info;
}