using Newtonsoft.Json;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace POS_Accessories.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _service;
        public IConfiguration _configuration { get; }
        public UserService(IUserRepository service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        public async Task<CommonResponse> AuthenticateUser(string email, string password)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var user = await _service.AuthenticateUser(email, password);
                if (user != null)
                {

                    var token = createToken(user);
                    response.data = new { user, token };
                    response.message = "Success";
                    response.statusCode = HttpStatusCode.OK;
                    response.status = true;
                    response.count = 1;
                }
                else
                {
                    response.message = "You have entered an invalid username or password";
                    response.statusCode = HttpStatusCode.NoContent;
                    response.status = false;
                }

            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        private string createToken(User user)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddHours(12);

            var tokenHandler = new JwtSecurityTokenHandler();
            List<Claim> userClaims = new();
            userClaims.Add(new Claim(nameof(user), JsonConvert.SerializeObject(user)));
            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims);

            //const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Issuer"],
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
