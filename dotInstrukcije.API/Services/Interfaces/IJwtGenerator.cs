namespace dotInstrukcije.API.Services.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(string email, string role);
    }
}
