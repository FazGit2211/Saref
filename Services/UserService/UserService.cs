using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Saref.Data;
using Saref.Models.User;
using System.Security.Cryptography;

namespace Saref.Services.UserService
{
    public class UserService : IUser
    {
        //Inyectar contexto de la base de datos
        private readonly ContextDB _contextDB;
        public UserService(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public async Task<User> CreateUser(User user)
        {
            try
            {
                //Buscar si existe primero
                var userExist = from u in _contextDB.Users where u.Username == user.Username select u;
                if (userExist.IsNullOrEmpty())
                {
                    return null;
                }
                User userNew = new User();
                userNew.Username = user.Username;
                //Hash password
                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }
                string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: user.Password, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 10000, numBytesRequested: 256 / 8));
                userNew.Password = hashedPassword;
                _contextDB.Users.Add(userNew);
                await _contextDB.SaveChangesAsync();
                return userNew;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUser(User user)
        {
            try
            {
                //Buscar si existe primero
                var userExist = from u in _contextDB.Users where u.Username == user.Username select u;
                if (userExist.IsNullOrEmpty())
                {
                    return null;
                }
                // Retrieve storedSalt and storedHashedPassword from your database
                User userStored = (User)userExist;
                string enteredPasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: user.Password, salt: userStored.Salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 10000, numBytesRequested: 256 / 8));
                if (enteredPasswordHash != userStored.Password)
                {
                    return null;
                }
                return userStored;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
