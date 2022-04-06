using Burakrzgr.MyForm.Entity.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Burakrzgr.MyForm.Business.Authentication
{
    public interface IUserService
    {
        UserModel Authenticate(string kullaniciAdi, string sifre);
        IEnumerable<UserModel> GetAll();
    }

    public class UserService : IUserService
    {
        // Kullanıcılar veritabanı yerine manuel olarak listede tutulamaktadır. Önerilen tabiki veritabanında hash lenmiş olarak tutmaktır.
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel { UserId = 1, UserName ="Burak" , Password ="1234" },
            new UserModel { UserId = 1, UserName ="Test" , Password ="1234" }
        };

        private readonly string Secret = "secret-of-the-magic-is-your-imagination";

        public UserService()
        {
        }

        public UserModel Authenticate(string kullaniciAdi, string sifre)
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
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Sifre null olarak gonderilir.
            user.Password = null;

            return user;
        }

        public IEnumerable<UserModel> GetAll()
        {
            // Kullanicilar sifre olmadan dondurulur.
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
