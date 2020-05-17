using JWT;
using JWT.Algorithms;
using JWT.Builder;
using System;
using UserApi.Dto;

namespace UserApi.Token
{
    public class TokenBuilder
    {
        public string Build(AuthorizeDto User)
        {
            try
            {
                string token = new JwtBuilder()
                    .WithAlgorithm(new HMACSHA512Algorithm())
                    .WithSecret(System.Environment.GetEnvironmentVariable("ASPNETCORE_TOKEN_JWT_SECRETKEY"))
                    .AddClaim("email", User.Email)
                    .AddClaim("expiration", Expiration())
                    .AddClaim("role", @"Chyba admin ¯\_(ツ)_/¯")
                    .Build();

                return token;
            }
            catch
            {
                throw new Exception("Can't build token signature");
            }
        }

        public static double Expiration()
        {
            try
            {
                IDateTimeProvider provider = new UtcDateTimeProvider();

                int tokenDurationTime = 0;

                var now = provider.GetNow();
                var durationUntil = UnixEpoch.GetSecondsSince(now) + tokenDurationTime;

                return durationUntil;
            }
            catch
            {
                throw new Exception("Can't build expiration time for token");
            }
        }
    }
}