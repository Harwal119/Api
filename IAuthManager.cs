namespace batch15webAPI;

public interface IAuthManager
{
    public string GenerateToken(User user);
}