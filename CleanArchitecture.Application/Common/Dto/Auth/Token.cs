namespace CleanArchitecture.Application.Common.Dto.Auth
{
    public class Token
    {
        public string AuthToken { get; }
        public int ExpiresIn { get; }

        public Token(string authToken, int expiresIn)
        {
            AuthToken = authToken;
            ExpiresIn = expiresIn;
        }
    }
}
