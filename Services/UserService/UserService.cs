using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
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
        //Inyectar el  servicio para hashear password
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(ContextDB contextDB, IPasswordHasher<User> passwordHasher)
        {
            _contextDB = contextDB;
            _passwordHasher = passwordHasher;
        }
        public async Task<User> CreateUser(User user)
        {
            try
            {
                //Buscar si existe primero
                var userExist = from u in _contextDB.Users where u.Username.Equals(user.Username) select u;
                if (!userExist.IsNullOrEmpty())
                {
                    return null;
                }
                User userNew = new User();
                userNew.Username = user.Username;
                //Hash password
                string hashedPassword = _passwordHasher.HashPassword(user, user.Password);
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
                User userStored = new User();
                foreach(User us in userExist) {
                    userStored = us;
                }
                // Retrieve storedSalt and storedHashedPassword from your database
                var verificationResult = _passwordHasher.VerifyHashedPassword(userStored, userStored.Password, user.Password);
                if (verificationResult == PasswordVerificationResult.Success) { 
                    return userStored;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
