using Burakrzgr.MyForm.Entity.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;

namespace Burakrzgr.MyForm.Business.Authentication
{
    public interface IUserService
    {
        UserModal Authenticate(string kullaniciAdi, string sifre);
        UserModal TokenToUser(JwtSecurityToken jwt);
        IEnumerable<UserModal> GetAll();
    }

    public class UserService : IUserService
    {
        HttpContextAccessor _accessor;
        // Kullanıcılar veritabanı yerine manuel olarak listede tutulamaktadır. Önerilen tabiki veritabanında hash lenmiş olarak tutmaktır.
        private List<UserModal> _users = new List<UserModal>
        {
            new UserModal { UserId = 1, UserName ="Burak" , Password ="1234"},
            new UserModal { UserId = 2, UserName ="Test" , Password ="1234" },
            new UserModal { UserId = 2, UserName ="Admin" , Password ="1234" }
        };

        public static string Secret;

        public UserService()
        {
            _accessor = new HttpContextAccessor();
        }

        public UserModal Authenticate(string kullaniciAdi, string sifre)
        {
            var user = _users.SingleOrDefault(x => x.UserName == kullaniciAdi && x.Password == sifre);

            // Kullanici bulunamadıysa null döner.
            if (user == null)
                return null;

            // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, String.Join(";",user.Roles))
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.TokenExpiration = DateTime.UtcNow.AddHours(5);
            // Sifre null olarak gonderilir.
            user.Password = null;

            return user;
        }

        public IEnumerable<UserModal> GetAll()
        {
            // Kullanicilar sifre olmadan dondurulur.
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }

        public UserModal TokenToUser(JwtSecurityToken jwt)
        {
            var accessToken = _accessor.HttpContext?.Response.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
            {
                return new UserModal { UserId = 0, Roles = new[] { "Anonymous" } };
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken.ToString().Replace("Bearer ", string.Empty));
            Claim User = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Name);
            Claim Roles = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Role);

            return new UserModal { UserId = int.Parse(User.Value), Roles = Roles.Value.Split(';') };
        }
    }
}
